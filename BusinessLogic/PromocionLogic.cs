using Dominio;

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
            promo.Id = contador;
            _repository.Add(promo);
            contador++;
        }

        public void DeletePromocion(Promocion promo)
        {
            _repository.Delete(promo);
        }

        public Promocion GetPromocion(int id)
        {
            return _repository.Find(p => p.Id == id);
        }

        public void ModificarPromocion(int id, Promocion promo)
        {
            Promocion promocion = promo;
            promocion.Id = id;
            _repository.Update(promocion);
        }
    }
}
