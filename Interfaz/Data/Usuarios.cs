using BusinessLogic;
using Repositorio;

namespace Interfaz.Data
{
    public class Usuarios
    {
        private static readonly UsuarioRepository Repositorio = new();
        public UsuarioLogic Logica = new(Repositorio);

    }
}
