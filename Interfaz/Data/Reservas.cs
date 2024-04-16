using BusinessLogic;
using Repositorio;
namespace Interfaz.Data
{
    public class Reservas
    {
        private static readonly ReservasRepository Repositorio = new();
        public ReservasLogic Logica = new(Repositorio);
    }
}
