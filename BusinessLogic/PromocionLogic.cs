using Dominio;
using Repositorio;
using Excepcion;

namespace BusinessLogic
{
    public class PromocionLogic
    {
        int contador = 0;
        readonly IRepository<Promocion> _repository;
        public PromocionLogic(IRepository<Promocion> promocion)
        {
            _repository = promocion;
        }

        public void AddPromocion(Promocion promo)
        {
            if(promo == null)
            {
                throw new PromocionLogicExcepcion("Una promocion en AddPromocion no puede ser null");
            }

            promo.Id = contador;
            _repository.Add(promo);
            contador++;
        }

        public void DeletePromocion(int id, Promocion promo)
        {
            if (promo == null)
            {
                throw new PromocionLogicExcepcion("Una promocion en DeletePromocion no puede ser null");
            }
            promo.Id = id;
            _repository.Delete(promo);
        }

        public Promocion GetPromocion(int id)
        {
            return _repository.Find(p => p.Id == id);
        }

        public void ModificarPromocion(int id, Promocion promo)
        {
            if (promo == null)
            {
                throw new PromocionLogicExcepcion("Una promocion en ModificarPromocion no puede ser null");
            }
            Promocion promocion = promo;
            promocion.Id = id;
            _repository.Update(promocion);
        }

        public IList<Promocion> GetPromocionesPorTipo(char tipo)
        {
            IList<Promocion> Promociones = _repository.GetAll();
            IList<Promocion> res = new List<Promocion>();
            foreach (Promocion promocion in Promociones)
            {
                if (promocion.TipoDeposito == tipo)
                {
                    res.Add(promocion);
                }
            }
            return res;
        }

        public IList<Promocion> GetPromociones()
        {
            return _repository.GetAll();
        }
    }
}
