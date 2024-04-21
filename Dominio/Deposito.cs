using Excepcion;

namespace Dominio
{
    public class Deposito
    {
        private int _id;
        private char _area;
        private char _tamano;
        private bool _tieneClimatizacion;
        private IList<Promocion> _promociones = new List<Promocion>();

        // Propiedad ID para acceder al id del dep�sito
        public int ID
        {
            get => _id;
            set => _id = value;
        }

        // Propiedad TipoDeArea para acceder al tipo de �rea del dep�sito
        public char Area
        {
            get => _area;
            set => _area = ValidarArea(value);
        }

        // Propiedad Tamano para acceder al tama�o del dep�sito
        public char Tamano
        {
            get => _tamano;
            set => _tamano = ValidarTamano(value);
        }

        // Propiedad TieneClimatizacion para acceder a si el dep�sito tiene climatizaci�n
        public bool TieneClimatizacion
        {
            get => _tieneClimatizacion;
            set => _tieneClimatizacion = value;
        }

        // Propiedad Promociones para acceder a las promociones del dep�sito
        public IList<Promocion> Promociones
        {
            get => _promociones;
            set => _promociones = value;
        }

        // Constructor de la clase Deposito
        public Deposito(char area, char tamano, bool tieneClimatizacion)
        {
            Area = area;
            Tamano = tamano;
            TieneClimatizacion = tieneClimatizacion;
        }

        // M�todo para validar el �rea
        private char ValidarArea(char area)
        {
            char[] areasValidas = new char[] { 'A', 'B', 'C', 'D', 'E' };
            if (!areasValidas.Contains(area))
            {
                throw new DominioDepositoExcepcion($"El �rea {area} no es v�lida");
            }
            return area;
        }

        // M�todo para validar el tama�o
        private char ValidarTamano(char tamano)
        {
            char[] TamanosValidos = new char[] { 'S', 'M', 'L' };
            if (!TamanosValidos.Contains(tamano))
            {
                throw new DominioDepositoExcepcion($"El Tama�o {tamano} no es v�lido");
            }
            return tamano;
        }

        // M�todo para agregar una promoci�n al dep�sito
        public void AgregarPromocion(Promocion promo)
        {

            _promociones.Add(promo);

        }

        // M�todo para Borrar una promoci�n del dep�sito
        public void EliminarPromocion(Promocion promo)
        {
            _promociones.Remove(promo);
        }


    }
}
