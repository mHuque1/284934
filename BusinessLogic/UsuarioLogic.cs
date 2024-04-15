using Dominio;
using Excepcion;
using Repositorio;
namespace BusinessLogic;

public class UsuarioLogic
{
    private readonly IRepository<Usuario> _repository;
    public UsuarioLogic(IRepository<Usuario> usuarios)
    {
        _repository = usuarios;
        AddUsuario(new("Mathias", "mathiashuque2004@gmail.com", "Escuela7!", true));
    }

    public bool ExisteAdmin()
    {
        Usuario admin = _repository.Find(u => u.EsAdmin);
        return admin != null;
    }

    private bool EmailYaRegistrado(string email)
    {
        Usuario user = GetUsuario(email);
        return user != null;
    }


    public void AddUsuario(Usuario usuario)
    {
        if (usuario == null)
        {
            throw new UsuarioLogicExcepcion("El usuario no puede ser null");
        }
        if (usuario.EsAdmin && ExisteAdmin())
        {
            throw new UsuarioLogicExcepcion("No se permite agregar un administrador cuando ya existe uno");
        }

        if (EmailYaRegistrado(usuario.Email))
        {
            throw new UsuarioLogicExcepcion("Ya existe un usuario con el email ingresado");
        }
        else
        {
            _repository.Add(usuario);
        }

    }

    public Usuario GetUsuario(string Email)
    {
        if (!string.IsNullOrEmpty(Email))
        {
            return _repository.Find(u => u.Email == Email);
        }
        else
        {
            throw new UsuarioLogicExcepcion("Se necesita el email para el getUsuario");
        }

    }

    public bool ValidarInicioSesion(string email, string contrasena)
    {
        if (!string.IsNullOrEmpty(email))
        {
            if (!string.IsNullOrEmpty(contrasena))
            {
                Usuario user = GetUsuario(email);
                return user != null && user.Contrasena == contrasena;
            }
            else
            {
                throw new UsuarioLogicExcepcion("La contraseña no puede ser null");
            }

        }
        else
        {
            throw new UsuarioLogicExcepcion("El email no puede ser null");
        }

    }
}