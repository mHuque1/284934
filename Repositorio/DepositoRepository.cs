using Dominio;
namespace Repositorio;

public class DepositoRepository : IRepository<Deposito>
{
    private readonly IList<Deposito> _depositos;

    public DepositoRepository()
    {
        _depositos = new List<Deposito>();
    }

    public void Add(Deposito item)
    {
        _depositos.Add(item);
    }

    public void Delete(Deposito depo)
    {
        _depositos.Remove(depo);
    }

    public Deposito Find(Func<Deposito, bool> filter)
    {
        return _depositos.FirstOrDefault(filter);
    }


    public IList<Deposito> GetAll()
    {
        return _depositos;
    }

    public void Update(Deposito updatedItem)
    {
        Deposito existingItem = _depositos.FirstOrDefault(d => d.ID == updatedItem.ID);
        if (existingItem != null)
        {
            existingItem.Area = updatedItem.Area;
            existingItem.Tamano = updatedItem.Tamano;
            existingItem.TieneClimatizacion = updatedItem.TieneClimatizacion;
            existingItem.Promociones = updatedItem.Promociones;
        }
    }


}
