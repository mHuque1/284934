using Dominio;
namespace Repositorio;

public class PromocionRepository : IRepository<Promocion>
{
    private readonly IList<Promocion> _Promociones;

    public PromocionRepository()
    {
        _Promociones = new List<Promocion>();
    }

    public void Add(Promocion item)
    {
        _Promociones.Add(item);
    }


    public void Delete(Promocion item)
    {
        _Promociones.Remove(item);
    }

    public Promocion Find(Func<Promocion, bool> filter)
    {
        return _Promociones.FirstOrDefault(filter);
    }

    public IList<Promocion> GetAll()
    {
        return _Promociones;
    }

    public void Update(Promocion updatedItem)
    {
        Promocion? existingItem = _Promociones.FirstOrDefault(d => d.Id == updatedItem.Id);
        if (existingItem != null)
        {
            existingItem.Descuento = updatedItem.Descuento;
            existingItem.Etiqueta = updatedItem.Etiqueta;
            existingItem.Comienzo = updatedItem.Comienzo;
            existingItem.Fin = updatedItem.Fin;
            existingItem.TipoDeposito = updatedItem.TipoDeposito;
        }
    }
}

