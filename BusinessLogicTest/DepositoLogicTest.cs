using BusinessLogic;
using Dominio;
using Repositorio;

namespace BusinessLogicTest
{
    [TestClass]
    public class DepositoLogicTest
    {
        private DepositoLogic _logica;
        private IRepository<Deposito> _depositos;

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
            Deposito depositoA = new Deposito { Id = 1, Area = 'A', Tamano = 'S', Climatizacion = true };

            // Act
            _logica.AddDeposito(depositoA);
            Deposito resultado = _logica.GetDeposito(1);

            // Assert
            Assert.AreEqual(depositoA, resultado);
        }

        [TestMethod]
        public void Verificar_Baja_De_Deposito()
        {
            // Arrange
            Deposito depositoA = new Deposito { Id = 1, Area = 'A', Tamano = 'S', Climatizacion = true };
            _logica.AddDeposito(depositoA);

            // Act
            _logica.DeleteDeposito(depositoA);
            IList<Deposito> depositos = _logica.GetDepositos();

            // Assert
            Assert.AreEqual(0, depositos.Count);
        }

        [TestMethod]
        public void Verificar_Get_Depositos()
        {
            // Arrange
            Deposito depositoA = new Deposito { Id = 1, Area = 'A', Tamano = 'S', Climatizacion = true };
            Deposito depositoB = new Deposito { Id = 2, Area = 'B', Tamano = 'S', Climatizacion = true };

            _logica.AddDeposito(depositoA);
            _logica.AddDeposito(depositoB);

            // Act
            IList<Deposito> depositos = _logica.GetDepositos();

            // Assert
            Assert.AreEqual(2, depositos.Count);
            Assert.IsTrue(depositos.Contains(depositoA));
            Assert.IsTrue(depositos.Contains(depositoB));
        }


        [TestMethod]
        public void Verificar_Alta_De_Promocion()
        {
            // Arrange
            Deposito depositoA = new Deposito { Id = 1, Area = 'A', Tamano = 'S', Climatizacion = true };
            Promocion promocion = new Promocion { Etiqueta = "Promo", Descuento = 10, Desde = DateTime.Today, Hasta = DateTime.Today.AddDays(10) };

            // Act
            _logica.AddPromocionDeposito(depositoA, promocion);
            Deposito resultado = _logica.GetDeposito(1);

            // Assert
            Assert.AreEqual(promocion, resultado.GetPromociones()[0]);
        }

        [TestMethod]
        public void Verificar_Modificacion_De_Promocion()
        {
            // Arrange
            Deposito depositoA = new Deposito { Id = 1, Area = 'A', Tamano = 'S', Climatizacion = true };
            Promocion promocion = new Promocion { Etiqueta = "Promo", Descuento = 10, Desde = DateTime.Today, Hasta = DateTime.Today.AddDays(10) };

            // Act
            _logica.AddPromocionDeposito(depositoA, promocion);
            promocion.Descuento = 20;
            _logica.UpdatePromocionDeposito(depositoA, promocion);
            Deposito resultado = _logica.GetDeposito(1);

            // Assert
            Assert.AreEqual(promocion, resultado.GetPromociones()[0]);
        }




    }
}
