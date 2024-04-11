using Dominio;

namespace BusinessLogic
{
    public class ReservasLogic
    {
        private int _contadorID = 0;
        private readonly IRepository<Reserva> _repository;

        public ReservasLogic(IRepository<Reserva> reservas)
        {
            _repository = reservas;

        }
        public void AddReserva(Reserva reserva)
        {
            reserva.ID = _contadorID;
            _repository.Add(reserva);
            _contadorID++;
        }


        public void DeleteReserva(int v)
        {
            _repository.Delete(GetReserva(v));
        }

        public Reserva GetReserva(int id)
        {
            return _repository.Find(r => r.ID == id);
        }

        public IList<Reserva> GetReservas()
        {
            return _repository.GetAll();
        }

        public void ModificarReserva(int v, Reserva reserva)
        {
            reserva.ID = v;
            _repository.Update(reserva);
        }
    }
}
