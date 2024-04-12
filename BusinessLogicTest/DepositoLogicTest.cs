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
        [ExpectedException(typeof(DepositoLogicExcepcion))]
        public void Verificar_Alta_De_Deposito_Null()
        {
            // Arrange
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);
            // Act
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _logica.AddDeposito(null, user);
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        }

        [TestMethod]
        [ExpectedException(typeof(DepositoLogicExcepcion))]
        public void Verificar_Alta_De_Deposito_Usuario_Null()
        {
            // Arrange
            Deposito depositoA = new('A', 'S', true);

            // Act
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _logica.AddDeposito(depositoA, null);
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        }

        [TestMethod]
        [ExpectedException(typeof(DepositoLogicExcepcion))]
        public void Solo_Admin_Alta_De_Deposito()
        {
            // Arrange
            Deposito depositoA = new('A', 'S', true);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", false);
            // Act
            _logica.AddDeposito(depositoA, user);
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
        [ExpectedException(typeof(DepositoLogicExcepcion))]
        public void Verificar_Baja_De_Deposito_Null()
        {
            // Arrange
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);

            // Act
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _logica.DeleteDeposito(null, user);
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        [ExpectedException(typeof(DepositoLogicExcepcion))]
        public void Verificar_Baja_De_Deposito_Usuario_Null()
        {
            // Arrange
            Deposito depositoA = new('A', 'S', true);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);
            _logica.AddDeposito(depositoA, user);

            // Act
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _logica.DeleteDeposito(depositoA, null);
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
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