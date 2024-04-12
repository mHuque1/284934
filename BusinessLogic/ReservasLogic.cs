using Dominio;
using Repositorio;
using Excepcion;

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
            if(reserva == null)
            {
                throw new ReservaLogicExcepcion("No se puede agregar una reserva null");
            }
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
            if (reserva == null)
            {
                throw new ReservaLogicExcepcion("La reserva en ModifcarReserva no puede ser null");
            }
            reserva.ID = v;
            _repository.Update(reserva);
        }

        public IList<Reserva> GetReservasUsuario(Usuario usuario)
        {
            if(usuario == null)
            {
                throw new ReservaLogicExcepcion("El usuario en getReservasUsuario no puede ser null.");
            }

            IList<Reserva> Reservas = _repository.GetAll();
            IList<Reserva> res = new List<Reserva>();
            foreach (Reserva reserva in Reservas)
            {
                if (reserva.Usuario.Email == usuario.Email)
                {
                    res.Add(reserva);
                }
            }
            return res;
        }

        public bool TieneDepositoReservas(int id)
        {
            IList<Reserva> Reservas = _repository.GetAll();
            bool resultado = false;
            for (int i = 0; i < Reservas.Count && !resultado; i++)
            {
                Reserva reserva = Reservas[i];
                if (reserva.Deposito.ID == id)
                {
                    resultado = true;
                }
            }
            return resultado;
        }
    }
}
