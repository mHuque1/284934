using Excepcion;

namespace Dominio
{
    public class Promocion
    {
        private int _id;
        private string _etiqueta;
        private double _descuento;
        private DateTime _comienzo;
        private DateTime _fin;

        // Propiedad para el ID
        public int Id { get => _id; set => _id = value; }

        // Propiedad para la Etiqueta
        public string Etiqueta
        {
            get => _etiqueta;
            set => _etiqueta = ValidarEtiqueta(value);
        }

        // Propiedad para el Descuento
        public double Descuento
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


        // Constructor de la clase Usuario que recibe id, etiqueta, descuento, fecha Comienzo, fecha fin y tipoDeposito
        public Promocion(string etiqueta, double descuento, DateTime comienzo, DateTime fin)
        {
            Etiqueta = etiqueta;
            Descuento = descuento;
            Comienzo = comienzo;
            Fin = fin;
        }

        // M�todo est�tico para validar y limpiar la etiqueta
        private static string ValidarEtiqueta(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new DominioPromocionExcepcion("La etiqueta no puede ser vacia.");

            string etiquetaTrimmed = texto.Trim();
            if (etiquetaTrimmed.Length > 20)
                throw new DominioPromocionExcepcion("La etiqueta no puede tener m�s de 20 caracteres.");

            return etiquetaTrimmed;
        }

        // M�todo est�tico para validar el descuento
        private static double ValidarDescuento(double value)
        {
            if (value < 5.0 || value > 75.0)
                throw new DominioPromocionExcepcion("El porcentaje de descuento debe estar entre 5% y 75%.");

            return value;
        }


        // M�todo para validar la vigencia de la promocion
        public bool EstaVigente()
        {
            DateTime hoy = DateTime.Today;
            return Comienzo <= hoy && Fin >= hoy;
        }
    }
}
