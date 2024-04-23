using Excepcion;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Usuario
    {

        private string _nombre;
        private bool _esAdmin;
        private string _email;
        private string _contrasena;

        // Propiedad para el nombre del usuario
        public string Nombre
        {
            get => _nombre;
            set => _nombre = ValidarNombre(value);  // Valida y asigna el valor del nombre
        }

        // Propiedad verificadora de administrador
        public bool EsAdmin
        {
            get => _esAdmin;
            set => _esAdmin = value;
        }

        // Propiedad para el correo electr�nico del usuario
        public string Email
        {
            get => _email;
            set => _email = ValidarEmail(value);  // Valida y asigna el valor del correo electr�nico
        }

        // Propiedad para la contrase�a del usuario
        public string Contrasena
        {
            get => _contrasena;
            set => _contrasena = ValidarContrasena(value);  // Valida y asigna el valor de la contrase�a
        }

        // Propiedad para las reservas del usuario
 

        // Constructor de la clase Usuario que recibe nombre, correo electr�nico y contrase�a
        public Usuario(string nombre, string email, string contrasena, bool esAdmin)
        {
            Nombre = nombre;
            Email = email;
            Contrasena = contrasena;
            EsAdmin = esAdmin;
        }

        // M�todo est�tico para validar y limpiar el nombre
        private static string ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new DominioUsuarioExcepcion("El Nombre no puede estar vac�o.");
            }

            if (nombre.Trim().Length > 100)
            {
                throw new DominioUsuarioExcepcion("El Nombre no puede tener m�s de 100 caracteres.");
            }

            return nombre.Trim();
        }

        // M�todo est�tico para validar y limpiar un correo electr�nico
        private static string ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DominioUsuarioExcepcion("El correo electr�nico no puede ser null ni vac�o.");
            }

            if (!Regex.IsMatch(email.Trim(), @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                throw new DominioUsuarioExcepcion("El correo electr�nico no tiene un formato v�lido.");
            }

            return email.Trim();  // Retorna el correo electr�nico limpio
        }

        // M�todo est�tico para validar y limpiar una contrase�a
        private static string ValidarContrasena(string contrasena)
        {
            if (string.IsNullOrWhiteSpace(contrasena))
            {
                throw new DominioUsuarioExcepcion("La contrase�a no puede estar vac�a.");
            }

            if (contrasena.Trim().Length < 8)
            {
                throw new DominioUsuarioExcepcion("La contrase�a debe tener m�nimo 8 caracteres.");
            }

            if (!TieneMayusculas(contrasena))
            {
                throw new DominioUsuarioExcepcion("La contrase�a debe tener al menos una may�scula.");
            }

            if (!TieneMinusculas(contrasena))
            {
                throw new DominioUsuarioExcepcion("La contrase�a debe tener al menos una min�scula.");
            }

            if (!TieneDigitos(contrasena))
            {
                throw new DominioUsuarioExcepcion("La contrase�a debe tener al menos un d�gito.");
            }

            if (!TieneSimbolos(contrasena))
            {
                throw new DominioUsuarioExcepcion("La contrase�a debe tener al menos un car�cter especial.");
            }

            return contrasena.Trim();  // Retorna la contrase�a limpia
        }

        // M�todo est�tico para verificar si una cadena tiene al menos una may�scula
        private static bool TieneMayusculas(string texto)
        {
            return texto != texto.ToLower();
        }

        // M�todo est�tico para verificar si una cadena tiene al menos una min�scula
        private static bool TieneMinusculas(string texto)
        {
            return texto != texto.ToUpper();
        }

        // M�todo est�tico para verificar si una cadena tiene al menos un d�gito
        private static bool TieneDigitos(string texto)
        {
            return texto.Any(char.IsDigit);
        }

        // M�todo est�tico para verificar si una cadena tiene al menos un car�cter especial
        private static bool TieneSimbolos(string texto)
        {
            return texto.Any(ch => !char.IsLetterOrDigit(ch));
        }

    }
}
