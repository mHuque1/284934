using Excepcion;
using System;

namespace Dominio
{
    public class Promocion
    {
        private int _id;
        private string _etiqueta;
        private int _descuento;
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
        // Constructor de la clase Usuario que recibe id, etiqueta, descuento, fecha Comienzo y fin
        public Promocion(int id, string etiqueta, int descuento, DateTime comienzo, DateTime fin)
        {
            _id = id;
            Etiqueta = etiqueta;
            Descuento = descuento;
            Comienzo = comienzo;
            Fin = fin;
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
