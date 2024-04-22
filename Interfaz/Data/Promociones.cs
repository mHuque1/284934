using BusinessLogic;
using Dominio;
using Repositorio;
namespace Interfaz.Data
{
    public class Promociones
    {
        private static readonly PromocionRepository Repositorio = new();
        private readonly PromocionLogic Logica = new(Repositorio);

        public void ModificarPromocion(int id, Promocion promo, Usuario user) => Logica.ModificarPromocion(id, promo, user);

        public void DeletePromocion(int id, Promocion promo, Usuario user) => Logica.DeletePromocion(id, promo, user);

        public void AddPromocion(Promocion promo, Usuario user) => Logica.AddPromocion(promo, user);

        public IList<Promocion> listaPromociones { get => Logica.GetPromociones(); }
    }
}
