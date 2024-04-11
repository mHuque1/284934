using Dominio;
namespace Repositorio;

public class ReservasRepository : IRepository<Reserva>
{
    private readonly IList<Reserva> _reservas;

    public ReservasRepository()
    {
        _reservas = new List<Reserva>();
    }

    public void Add(Reserva item)
    {
        _reservas.Add(item);
    }

    public void Delete(Reserva depo)
    {
        _reservas.Remove(depo);
    }

    public Reserva? Find(Func<Reserva, bool> filter)
    {
        return _reservas.FirstOrDefault(filter);
    }


    public IList<Reserva> GetAll()
    {
        return _reservas;
    }

    public void Update(Reserva updatedItem)
    {
        Reserva? existingItem = _reservas.FirstOrDefault(d => d.ID == updatedItem.ID);
        if (existingItem != null)
        {
            existingItem.Comienzo = updatedItem.Comienzo;
            existingItem.Fin = updatedItem.Fin;
            existingItem.Deposito = updatedItem.Deposito;
            existingItem.Usuario = updatedItem.Usuario;
            existingItem.Deposito = updatedItem.Deposito;
            existingItem.Aprobada = updatedItem.Aprobada;
            existingItem.EnEspera = updatedItem.EnEspera;
            if (!existingItem.EnEspera && !existingItem.Aprobada)
            {
                existingItem.Mensaje = updatedItem.Mensaje;
            }

        }
    }


}
