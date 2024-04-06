using Dominio;
namespace Repositorio;

public class UsuarioRepository : IRepository<Usuario>
{
    private List<Usuario> _usuarios;

    public UsuarioRepository()
    {
        _usuarios = new List<Usuario>();
    }

    public void Add(Usuario item)
    {
        _usuarios.Add(item);
    }

    public void Update(Usuario updatedItem)
    {
        int index = _usuarios.FindIndex(u => u.Email == updatedItem.Email);
        if (index != -1)
        {
            _usuarios[index] = updatedItem;
        }
    }

    public void Delete(int Email)
    {
        _usuarios.RemoveAll(u => u.Email == Email);
    }

    public Usuario Find(Func<Usuario, bool> filter)
    {
        return _usuarios.FirstOrDefault(filter);
    }

    public IList<Usuario> GetAll()
    {
        return _usuarios.ToList();
    }
}

