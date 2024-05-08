using Dominio;
using Excepcion;
using Repositorio;

namespace BusinessLogic
{
    public class DepositoLogic
    {
        private int _contadorID = 0;
        private readonly IRepository<Deposito> _repository;
        public DepositoLogic(IRepository<Deposito> depositos)
        {
            _repository = depositos;
        }

        public void AddDeposito(Deposito depositoA, Usuario user)
        {

            if (depositoA == null)
            {
                throw new DepositoLogicExcepcion("El deposito ingresado fue null");

            }

            if (user == null)
            {
                throw new DepositoLogicExcepcion("El user ingresado fue null");
            }


            if (user.EsAdmin)
            {
                depositoA.ID = _contadorID;
                _contadorID++;
                _repository.Add(depositoA);
            }
            else
            {
                throw new DepositoLogicExcepcion("El alta de depósitos solamente puede ser efectuada por el Administrador");
            }

        }

        public void DeleteDeposito(Deposito depositoA, Usuario user)
        {
            if (depositoA == null)
            {
                throw new DepositoLogicExcepcion("El deposito en DeleteDeposito no puede ser null");
            }

            if (user == null)
            {
                throw new DepositoLogicExcepcion("El user en DeleteDeposito no puede ser null");
            }

            if (user.EsAdmin)
            {
                _repository.Delete(depositoA);
            }
            else
            {
                throw new DepositoLogicExcepcion("La baja de depósitos solamente puede ser efectuada por el Administrador");
            }

        }

        public Deposito GetDeposito(int id)
        {
            return _repository.Find(d => d.ID == id);
        }

        public IList<Deposito> GetDepositos()
        {
            return _repository.GetAll();
        }

        public void BorrarPromocionDepositos(Promocion promo, Usuario user1)
        {
            if (promo == null)
            {
                throw new DepositoLogicExcepcion("La promo en BorrarPromocionDepositos no puede ser null");
            }

            if (user1 == null)
            {
                throw new DepositoLogicExcepcion("El user en BorrarPromocionDepositos no puede ser null");
            }

            if (!user1.EsAdmin)
            {
                throw new DepositoLogicExcepcion("Solo un administrador puede borrar promociones");
            }

            foreach (Deposito depo in _repository.GetAll())
            {
                if (depo.Promociones.Contains(promo))
                {
                    depo.Promociones.Remove(promo);
                }
            }
        }

        public void ModificarPromocionDepositos(int id, Promocion promo, Usuario user)
        {
            if (promo == null)
            {
                throw new DepositoLogicExcepcion("La promo en ModificarPromocionDepositos no puede ser null");
            }
            if (user == null)
            {
                throw new DepositoLogicExcepcion("El usuario en ModificarPromocionDepositos no puede ser null");
            }

            foreach (Deposito depo in _repository.GetAll())
            {
                depo.ActualizarPromocion(id, promo);
            }
        }
    }
}
