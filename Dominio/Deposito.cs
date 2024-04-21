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

        // Propiedad ID para acceder al id del depósito
        public int ID
        {
            get => _id;
            set => _id = value;
        }

        // Propiedad TipoDeArea para acceder al tipo de área del depósito
        public char Area
        {
            get => _area;
            set => _area = ValidarArea(value);
        }

        // Propiedad Tamano para acceder al tamaño del depósito
        public char Tamano
        {
            get => _tamano;
            set => _tamano = ValidarTamano(value);
        }

        // Propiedad TieneClimatizacion para acceder a si el depósito tiene climatización
        public bool TieneClimatizacion
        {
            get => _tieneClimatizacion;
            set => _tieneClimatizacion = value;
        }

        // Propiedad Promociones para acceder a las promociones del depósito
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

        // Método para validar el área
        private char ValidarArea(char area)
        {
            char[] areasValidas = new char[] { 'A', 'B', 'C', 'D', 'E' };
            if (!areasValidas.Contains(area))
            {
                throw new DominioDepositoExcepcion($"El área {area} no es válida");
            }
            return area;
        }

        // Método para validar el tamaño
        private char ValidarTamano(char tamano)
        {
            char[] TamanosValidos = new char[] { 'S', 'M', 'L' };
            if (!TamanosValidos.Contains(tamano))
            {
                throw new DominioDepositoExcepcion($"El Tamaño {tamano} no es válido");
            }
            return tamano;
        }

        // Método para agregar una promoción al depósito
        public void AgregarPromocion(Promocion promo)
        {

            _promociones.Add(promo);

        }

        // Método para Borrar una promoción del depósito
        public void EliminarPromocion(Promocion promo)
        {
            _promociones.Remove(promo);
        }


    }
}
