using BusinessLogic;
using Repositorio;
namespace Interfaz.Data
{
    public class Depositos
    {
        private static DepositoRepository Repositorio = new DepositoRepository();
        public DepositoLogic Logica = new DepositoLogic(Repositorio);
    }
}
