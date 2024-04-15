using BusinessLogic;
using Repositorio;
namespace Interfaz.Data
{
    public class Reservas
    {
        private static ReservasRepository Repositorio = new ReservasRepository();
        public ReservasLogic Logica = new ReservasLogic(Repositorio);
    }
}
