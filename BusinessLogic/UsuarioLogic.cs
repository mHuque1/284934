using Dominio;
using Repositorio;

namespace BusinessLogic;

public class UsuarioLogic
{
    public UsuarioLogic(IRepository<Usuario> _repositorio) {

    }

    public void AddReservaUsuario(Reserva reserva, Usuario user1)
    {
        throw new NotImplementedException();
    }

    public void AddUsuario(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public IList<Reserva> GetReservasUsuario(Usuario user1)
    {
        throw new NotImplementedException();
    }

    public bool ValidarInicioSesion(string v1, string v2)
    {
        throw new NotImplementedException();
    }
}
