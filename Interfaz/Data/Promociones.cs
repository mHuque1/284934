using BusinessLogic;
using Repositorio;
namespace Interfaz.Data
{
    public class Promociones
    {
        private static PromocionRepository Repositorio = new PromocionRepository();
        public  PromocionLogic Logica = new PromocionLogic(Repositorio);
    }
}
