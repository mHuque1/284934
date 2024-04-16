using BusinessLogic;
using Repositorio;
namespace Interfaz.Data
{
    public class Depositos
    {
        private static readonly DepositoRepository Repositorio = new();
        public DepositoLogic Logica = new(Repositorio);
    }
}
