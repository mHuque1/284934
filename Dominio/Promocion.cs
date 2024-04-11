using Excepcion;

namespace Dominio
{
    public class Promocion
    {
        private int _id;
        private string _etiqueta;
        private int _descuento;
        private DateTime _comienzo;
        private DateTime _fin;
        private char _tipoDeposito; //A que tipo (tamaño) de depositos va dirigida la promocion. ej: 'S'

        // Propiedad para el ID
        public int Id { get => _id; set => _id = value; }

        // Propiedad para la Etiqueta
        public string Etiqueta
        {
            get => _etiqueta;
            set => _etiqueta = ValidarEtiqueta(value);
        }

        // Propiedad para el Descuento
        public int Descuento
        {
            get => _descuento;
            set => _descuento = ValidarDescuento(value);
        }

        // Propiedad para la fecha de comienzo de la promocion
        public DateTime Comienzo
        {
            get => _comienzo;
            set => _comienzo = value;
        }

        // Propiedad para la fecha de fin de la promocion
        public DateTime Fin
        {
            get => _fin;
            set => _fin = value;
        }
        public char TipoDeposito
        {
            get => _tipoDeposito;
            set => _tipoDeposito = ValidarTamano(value);
        }

        private char ValidarTamano(char tamano)
        {
            char[] TamanosValidos = new char[] { 'S', 'M', 'L' };
            if (!TamanosValidos.Contains(tamano))
            {
                throw new DominioDepositoExcepcion($"El Tamaño {tamano} no es válido");
            }
            return tamano;
        }


        // Constructor de la clase Usuario que recibe id, etiqueta, descuento, fecha Comienzo, fecha fin y tipoDeposito
        public Promocion(string etiqueta, int descuento, DateTime comienzo, DateTime fin, char tipoDeposito)
        {
            Etiqueta = etiqueta;
            Descuento = descuento;
            Comienzo = comienzo;
            Fin = fin;
            TipoDeposito = tipoDeposito;
        }

        // Método estático para validar y limpiar la etiqueta
        private static string ValidarEtiqueta(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new DominioPromocionExcepcion("La etiqueta no ser vacia.");

            string etiquetaTrimmed = texto.Trim();
            if (etiquetaTrimmed.Length > 20)
                throw new DominioPromocionExcepcion("La etiqueta no puede tener más de 20 caracteres.");

            return etiquetaTrimmed;
        }

        // Método estático para validar el descuento
        private static int ValidarDescuento(int value)
        {
            if (value < 5 || value > 75)
                throw new DominioPromocionExcepcion("El porcentaje de descuento debe estar entre 5% y 75%.");

            return value;
        }


        // Método para validar la vigencia de la promocion
        public bool EstaVigente()
        {
            DateTime hoy = DateTime.Today;
            return Comienzo <= hoy && Fin >= hoy;
        }
    }
}
