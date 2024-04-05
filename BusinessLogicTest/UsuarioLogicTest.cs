using BusinessLogic;
using Dominio;

namespace BusinessLogicTest;

[TestClass]
public class UsuarioLogicTest
{

    private Usuar _usuarios;

    [TestInitialize]
        public void Initialize() 
        { 
            _service = new ActorService(TestContextFactory.CreateContext());
        }

}
