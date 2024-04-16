using BusinessLogic;
using Repositorio;
namespace Interfaz.Data
{
    public class Promociones
    {
        private static readonly PromocionRepository Repositorio = new();
        public PromocionLogic Logica = new(Repositorio);
    }
}
