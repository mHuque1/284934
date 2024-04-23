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

        // Propiedad para el correo electrónico del usuario
        public string Email
        {
            get => _email;
            set => _email = ValidarEmail(value);  // Valida y asigna el valor del correo electrónico
        }

        // Propiedad para la contraseña del usuario
        public string Contrasena
        {
            get => _contrasena;
            set => _contrasena = ValidarContrasena(value);  // Valida y asigna el valor de la contraseña
        }

        // Propiedad para las reservas del usuario
 

        // Constructor de la clase Usuario que recibe nombre, correo electrónico y contraseña
        public Usuario(string nombre, string email, string contrasena, bool esAdmin)
        {
            Nombre = nombre;
            Email = email;
            Contrasena = contrasena;
            EsAdmin = esAdmin;
        }

        // Método estático para validar y limpiar el nombre
        private static string ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new DominioUsuarioExcepcion("El Nombre no puede estar vacío.");
            }

            if (nombre.Trim().Length > 100)
            {
                throw new DominioUsuarioExcepcion("El Nombre no puede tener más de 100 caracteres.");
            }

            return nombre.Trim();
        }

        // Método estático para validar y limpiar un correo electrónico
        private static string ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DominioUsuarioExcepcion("El correo electrónico no puede ser null ni vacío.");
            }

            if (!Regex.IsMatch(email.Trim(), @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                throw new DominioUsuarioExcepcion("El correo electrónico no tiene un formato válido.");
            }

            return email.Trim();  // Retorna el correo electrónico limpio
        }

        // Método estático para validar y limpiar una contraseña
        private static string ValidarContrasena(string contrasena)
        {
            if (string.IsNullOrWhiteSpace(contrasena))
            {
                throw new DominioUsuarioExcepcion("La contraseña no puede estar vacía.");
            }

            if (contrasena.Trim().Length < 8)
            {
                throw new DominioUsuarioExcepcion("La contraseña debe tener mínimo 8 caracteres.");
            }

            if (!TieneMayusculas(contrasena))
            {
                throw new DominioUsuarioExcepcion("La contraseña debe tener al menos una mayúscula.");
            }

            if (!TieneMinusculas(contrasena))
            {
                throw new DominioUsuarioExcepcion("La contraseña debe tener al menos una minúscula.");
            }

            if (!TieneDigitos(contrasena))
            {
                throw new DominioUsuarioExcepcion("La contraseña debe tener al menos un dígito.");
            }

            if (!TieneSimbolos(contrasena))
            {
                throw new DominioUsuarioExcepcion("La contraseña debe tener al menos un carácter especial.");
            }

            return contrasena.Trim();  // Retorna la contraseña limpia
        }

        // Método estático para verificar si una cadena tiene al menos una mayúscula
        private static bool TieneMayusculas(string texto)
        {
            return texto != texto.ToLower();
        }

        // Método estático para verificar si una cadena tiene al menos una minúscula
        private static bool TieneMinusculas(string texto)
        {
            return texto != texto.ToUpper();
        }

        // Método estático para verificar si una cadena tiene al menos un dígito
        private static bool TieneDigitos(string texto)
        {
            return texto.Any(char.IsDigit);
        }

        // Método estático para verificar si una cadena tiene al menos un carácter especial
        private static bool TieneSimbolos(string texto)
        {
            return texto.Any(ch => !char.IsLetterOrDigit(ch));
        }

    }
}
