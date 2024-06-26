﻿using Dominio;
using Excepcion;
using Repositorio;

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

        public void AddPromocion(Promocion promo, Usuario user)
        {
            if (promo == null)
            {
                throw new PromocionLogicExcepcion("Una promocion en AddPromocion no puede ser null");
            }

            if (user == null)
            {
                throw new PromocionLogicExcepcion("Un user en AddPromocion no puede ser null");
            }

            if (!user.EsAdmin)
            {
                throw new PromocionLogicExcepcion("Solo un Admin puede agregar una promocion");
            }

            promo.Id = contador;
            _repository.Add(promo);
            contador++;
        }

        public void DeletePromocion(int id, Promocion promo, Usuario user)
        {
            if (promo == null)
            {
                throw new PromocionLogicExcepcion("Una promocion en DeletePromocion no puede ser null");
            }
            if (user == null)
            {
                throw new PromocionLogicExcepcion("Un usuario en DeletePromocion no puede ser null");
            }
            if (!user.EsAdmin)
            {
                throw new PromocionLogicExcepcion("Solo un Admin puede dar de baja una promocion");
            }
            promo.Id = id;
            _repository.Delete(promo);
        }

        public Promocion GetPromocion(int id)
        {
            return _repository.Find(p => p.Id == id);
        }

        public void ModificarPromocion(int id, Promocion promo, Usuario user)
        {
            if (promo == null)
            {
                throw new PromocionLogicExcepcion("Una promocion en ModificarPromocion no puede ser null");
            }
            if (user == null)
            {
                throw new PromocionLogicExcepcion("El usuario en ModificarPromocion no puede ser null");
            }

            if (!user.EsAdmin)
            {
                throw new PromocionLogicExcepcion("Solamente un admin puede modificar una promocion");
            }

            Promocion promocion = promo;
            promocion.Id = id;
            _repository.Update(promocion);
        }

        public IList<Promocion> GetPromociones()
        {
            return _repository.GetAll();
        }
    }
}
