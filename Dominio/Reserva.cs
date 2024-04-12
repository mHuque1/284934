using Excepcion;

namespace Dominio;

public class Reserva
{
    private int _id;
    private DateTime _comienzo;
    private DateTime _fin;
    private bool _aprobada = false;
    private bool _enEspera = true;
    private string _mensaje = "";
    private Deposito _deposito;
    private Usuario _usuario;
    private readonly DateTime _fechaReserva = DateTime.Today;
    private readonly double _costo;

    public DateTime Comienzo
    {
        get => _comienzo;
        set => _comienzo = value;
    }

    public int ID
    {
        get => _id;
        set => _id = value;
    }

    public DateTime FechaReserva
    {
        get => _fechaReserva;
    }

    public DateTime Fin
    {
        get => _fin;
        set => _fin = value;
    }

    public bool Aprobada
    {
        get => _aprobada;
        set => _aprobada = value;
    }

    public double Costo
    {
        get => _costo;
    }

    public bool EnEspera
    {
        get => _enEspera;
        set => _enEspera = value;
    }

    public string Mensaje
    {
        get => _mensaje;
        set => _mensaje = ValidarMensaje(value);
    }

    public Usuario Usuario
    {
        get => _usuario;
        set => _usuario = value;
    }

    private static string ValidarMensaje(string mensaje)
    {
        if (string.IsNullOrWhiteSpace(mensaje))
        {
            throw new DominioReservaExcepcion("El mensaje no puede ser vacio");
        }

        if (mensaje.Trim().Length > 300)
        {
            throw new DominioReservaExcepcion("El mensaje no puede tener mas de 300 caracteres");
        }

        return mensaje.Trim();
    }

    public Deposito Deposito
    {
        get => _deposito;
        set => _deposito = value;
    }
    public Reserva(Deposito depo, Usuario user, DateTime comienzo, DateTime fin)
    {
        _deposito = depo;
        _usuario = user;
        _comienzo = comienzo;
        _fin = fin;
        _costo = CalcularCosto();
    }


    private double CalcularCosto()
    {
        double costoBase = 0;

        // Calcular el costo base según el tamaño del depósito
        if (Deposito.Tamano == 'S') { costoBase = 50.0; }
        else if (Deposito.Tamano == 'M') { costoBase = 75.0; }
        else if (Deposito.Tamano == 'L') { costoBase = 100.0; }

        // Aplicar suplemento por climatización si es necesario
        double costoClimatizacion = Deposito.TieneClimatizacion ? 20.0 : 0.0;

        // Calcular el costo total sin descuentos ni promociones
        double costoTotal = costoBase + costoClimatizacion;

        // Calcular la duración del alquiler en días
        TimeSpan diferencia = Fin - Comienzo;
        int cantDias = (int)diferencia.TotalDays + 1;

        // Aplicar descuentos por duración del alquiler
        if (cantDias >= 7 && cantDias <= 14) { costoTotal *= 0.95; }
        else if (cantDias > 14) { costoTotal *= 0.90; }

        // Aplicar promociones vigentes
        foreach (Promocion promo in Deposito.Promociones)
        {
            if (promo.EstaVigente())
            {
                costoTotal *= 1.0 - (promo.Descuento * 0.01);
            }
        }

        return costoTotal;
    }

    public void Aprobar(Usuario usuario)
    {
        if (usuario.EsAdmin)
        {
            EnEspera = false;
            _aprobada = true;
        }
        else
        {
            throw new DominioReservaExcepcion("Una reserva solo puede ser aprobada por un administrador");
        }

    }

    public void Rechazar(Usuario usuario, string msg)
    {
        if (usuario.EsAdmin)
        {
            EnEspera = false;
            Mensaje = msg;
        }
        else
        {
            throw new DominioReservaExcepcion("Una reserva solo puede ser rechazada por un administrador");
        }

    }

}