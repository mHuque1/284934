using Dominio;
namespace Repositorio;

public class UsuarioRepository : IRepository<Usuario>
{
    private IList<Usuario> _usuarios;

    public UsuarioRepository()
    {
        _usuarios = new List<Usuario>();
    }

    public void Add(Usuario item)
    {
        _usuarios.Add(item);
    }


    public void Delete(Usuario item)
    {
        _usuarios.Remove(item);
    }

    public Usuario Find(Func<Usuario, bool> filter)
    {
        return _usuarios.FirstOrDefault(filter);
    }

    public IList<Usuario> GetAll()
    {
        return _usuarios;
    }

    public void Update(Usuario updatedItem)
    {
        Usuario existingItem = _usuarios.FirstOrDefault(d => d.Email == updatedItem.Email);
        if (existingItem != null)
        {
            existingItem.Nombre = updatedItem.Nombre;
            existingItem.Contrasena = updatedItem.Contrasena;
            existingItem.Reservas = updatedItem.Reservas;
        }
    }
}

