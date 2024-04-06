using BusinessLogic;
using Dominio;
using Repositorio;


namespace BusinessLogicTest;

public class DepositoLogicTest
{
    private IRepository<Deposito> _depositos;

        [TestInitialize]
        public void Inicializar()
        {
            _depositos = new DepositoRepository();
        }
}
