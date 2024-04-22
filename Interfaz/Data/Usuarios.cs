using BusinessLogic;
using Dominio;
using Repositorio;

namespace Interfaz.Data
{
    public class Usuarios
    {
        private static readonly UsuarioRepository Repositorio = new();
        private readonly UsuarioLogic Logica = new(Repositorio);
        private Usuario? currentUser;

        public Usuario GetCurrentUser { get => currentUser ?? throw new NullReferenceException(); private set => currentUser = value; }
        public bool SignIn(string email, string pass)
        {
            bool result = false;

            if (Logica.ValidarInicioSesion(email, pass))
            {
                currentUser = Logica.GetUsuario(email);
                result = true;
            }
            return result;
        }

        public bool ExisteAdmin {get => Logica.ExisteAdmin();}

        public bool SignUp(string nombre, string email, string pass)
        {
            bool result = false;
            if (Logica.GetUsuario(email) == null)
            {
                bool esAdmin = !Logica.ExisteAdmin();
                Usuario user = new(nombre, email, pass, esAdmin);
                Logica.AddUsuario(user);
                result = true;
            }
            return result;

        }

        public void SignOut() => currentUser = null;

        public bool IsSignedIn { get => currentUser != null; }
    }
}
