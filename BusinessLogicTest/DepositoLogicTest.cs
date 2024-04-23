using BusinessLogic;
using Dominio;
using Excepcion;
using Repositorio;

namespace BusinessLogicTest
{
    [TestClass]
    public class DepositoLogicTest
    {

        private static IRepository<Deposito> _depositos = new DepositoRepository();
        private DepositoLogic _logica = new(_depositos);

        [TestInitialize]
        public void Inicializar()
        {
            _depositos = new DepositoRepository();
            _logica = new DepositoLogic(_depositos);
        }

        [TestMethod]
        public void Verificar_Logica_No_Es_Null()
        {
            // Assert
            Assert.IsNotNull(_logica);
        }


        [TestMethod]
        public void Verificar_Alta_De_Deposito()
        {
            // Arrange
            Deposito depositoA = new('A', 'S', true);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);
            // Act
            _logica.AddDeposito(depositoA, user);
            Deposito resultado = _logica.GetDeposito(0);

            // Assert
            Assert.AreEqual(depositoA, resultado);
        }

        [TestMethod]
        public void Verificar_Alta_De_Deposito_Null()
        {
            // Arrange
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);
            // Act
            DepositoLogicExcepcion ex = Assert.ThrowsException<DepositoLogicExcepcion>(() => _logica.AddDeposito(null, user));

            //Assert
            Assert.AreEqual("El deposito ingresado fue null", ex.Message);


        }

        [TestMethod]
        public void Verificar_Alta_De_Deposito_Usuario_Null()
        {
            // Arrange
            Deposito depositoA = new('A', 'S', true);

            // Act
            DepositoLogicExcepcion ex = Assert.ThrowsException<DepositoLogicExcepcion>(() => _logica.AddDeposito(depositoA, null));

            //Assert
            Assert.AreEqual("El user ingresado fue null", ex.Message);

        }

        [TestMethod]
        public void Solo_Admin_Alta_De_Deposito()
        {
            // Arrange
            Deposito depositoA = new('A', 'S', true);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", false);

            // Act
            DepositoLogicExcepcion ex = Assert.ThrowsException<DepositoLogicExcepcion>(() => _logica.AddDeposito(depositoA, user));

            //Assert
            Assert.AreEqual("El alta de depósitos solamente puede ser efectuada por el Administrador", ex.Message);
        }
        [TestMethod]
        public void Verificar_Baja_De_Deposito()
        {
            // Arrange
            Deposito depositoA = new('A', 'S', true);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);
            _logica.AddDeposito(depositoA, user);

            // Act
            _logica.DeleteDeposito(depositoA, user);
            IList<Deposito> depositos = _logica.GetDepositos();

            // Assert
            Assert.AreEqual(0, depositos.Count);
        }

        [TestMethod]
        public void Verificar_Baja_De_Deposito_Null()
        {
            // Arrange
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);

            // Act
            DepositoLogicExcepcion ex = Assert.ThrowsException<DepositoLogicExcepcion>(() => _logica.DeleteDeposito(null, user));

            //Assert
            Assert.AreEqual("El deposito en DeleteDeposito no puede ser null", ex.Message);
            
        }

        [TestMethod]
        public void Verificar_Baja_De_Deposito_Usuario_Null()
        {
            // Arrange
            Deposito depositoA = new('A', 'S', true);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);
            _logica.AddDeposito(depositoA, user);

            // Act
            DepositoLogicExcepcion ex = Assert.ThrowsException<DepositoLogicExcepcion>(() => _logica.DeleteDeposito(depositoA, null));

            //Assert
            Assert.AreEqual("El user en DeleteDeposito no puede ser null", ex.Message);
        }

        [TestMethod]
        public void Verificar_Baja_De_Deposito_Usuario_No_Admin()
        {
            // Arrange
            Deposito depositoA = new('A', 'S', true);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);
            _logica.AddDeposito(depositoA, user);
            Usuario user1 = new("Pedro", "pedro@gmail.com", "Pedro1234!", false);
            // Act
            DepositoLogicExcepcion ex = Assert.ThrowsException<DepositoLogicExcepcion>(() => _logica.DeleteDeposito(depositoA, user1));
            Assert.AreEqual("La baja de depósitos solamente puede ser efectuada por el Administrador", ex.Message);
        }

        [TestMethod]
        public void Verificar_Get_Depositos()
        {
            // Arrange
            Deposito depositoA = new('A', 'S', true);
            Deposito depositoB = new('B', 'S', true);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);


            _logica.AddDeposito(depositoA, user);
            _logica.AddDeposito(depositoB, user);

            // Act
            IList<Deposito> depositos = _logica.GetDepositos();

            // Assert
            Assert.AreEqual(2, depositos.Count);
            Assert.IsTrue(depositos.Contains(depositoA));
            Assert.IsTrue(depositos.Contains(depositoB));
        }
    }
}