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

            //Assert
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

        [TestMethod]
        public void Verificar_BorrarPromocionDepositos()
        {
            // Arrange
            Deposito depositoA = new('A', 'S', true);
            Deposito depositoB = new('B', 'S', true);
            Promocion promo = new("promo", 30, DateTime.Today, DateTime.Today);
            depositoA.AgregarPromocion(promo);
            depositoB.AgregarPromocion(promo);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);
            _logica.AddDeposito(depositoA, user);
            _logica.AddDeposito(depositoB, user);

            //Act
            _logica.BorrarPromocionDepositos(promo, user);
            IList<Deposito> depositos = _logica.GetDepositos();

            //Assert
            foreach (Deposito deposito in depositos)
            {
                Assert.IsFalse(deposito.Promociones.Contains(promo));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DepositoLogicExcepcion))]
        public void Verificar_BorrarPromocionDepositos_Usuario_No_Admin()
        {
            // Arrange
            Promocion promo = new("promo", 30, DateTime.Today, DateTime.Today);
            Usuario user1 = new("Pedro", "pedro@gmail.com", "Pedro1234!", false);
            //Act
            _logica.BorrarPromocionDepositos(promo, user1);
        }
        [TestMethod]
        public void Verificar_BorrarPromocionDepositos_Usuario_Null()
        {
            // Arrange
            Promocion promo = new("promo", 30, DateTime.Today, DateTime.Today);
            Usuario user1 = new("Pedro", "pedro@gmail.com", "Pedro1234!", false);
            //Act


            // Act
            DepositoLogicExcepcion ex = Assert.ThrowsException<DepositoLogicExcepcion>(() => _logica.BorrarPromocionDepositos(promo, null));

            //Assert
            Assert.AreEqual("El user en BorrarPromocionDepositos no puede ser null", ex.Message);

        }

        [TestMethod]
        public void Verificar_BorrarPromocionDepositos_Promocion_Null()
        {
            // Arrange
            Promocion promo = new("promo", 30, DateTime.Today, DateTime.Today);
            Usuario user1 = new("Pedro", "pedro@gmail.com", "Pedro1234!", false);
            //Act


            // Act
            DepositoLogicExcepcion ex = Assert.ThrowsException<DepositoLogicExcepcion>(() => _logica.BorrarPromocionDepositos(null, user1));

            //Assert
            Assert.AreEqual("La promo en BorrarPromocionDepositos no puede ser null", ex.Message);

        }

        [TestMethod]
        public void Verificar_ModificarPromocionDepositos()
        {
            Promocion promo = new("promo", 30, DateTime.Today, DateTime.Today) { Id = 1 };
            Deposito depo1 = new('A', 'S', false);
            Deposito depo2 = new('A', 'S', false);
            depo1.AgregarPromocion(promo);
            depo2.AgregarPromocion(promo);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);
            _logica.AddDeposito(depo1, user);
            _logica.AddDeposito(depo2, user);
            Promocion promo1 = new("asd", 33, DateTime.Today, DateTime.Today) { Id = 1 };
            //Act
            _logica.ModificarPromocionDepositos(1, promo1, user);
            Promocion obtenido1 = _logica.GetDeposito(0).Promociones[0];
            Promocion obtenido2 = _logica.GetDeposito(1).Promociones[0];

            //Assert
            Assert.AreEqual(promo1.Etiqueta, obtenido1.Etiqueta);
            Assert.AreEqual(promo1.Descuento, obtenido1.Descuento);
            Assert.AreEqual(promo1.Comienzo, obtenido1.Comienzo);
            Assert.AreEqual(promo1.Fin, obtenido1.Fin);
            Assert.AreEqual(promo1.Etiqueta, obtenido2.Etiqueta);
            Assert.AreEqual(promo1.Descuento, obtenido2.Descuento);
            Assert.AreEqual(promo1.Comienzo, obtenido2.Comienzo);
            Assert.AreEqual(promo1.Fin, obtenido2.Fin);
        }


        [TestMethod]
        public void Verificar_ModificarPromocionDepositos_Deposito_Null()
        {
            Promocion promo = new("promo", 30, DateTime.Today, DateTime.Today) { Id = 1 };
            Deposito depo1 = new('A', 'S', false);
            Deposito depo2 = new('A', 'S', false);
            depo1.AgregarPromocion(promo);
            depo2.AgregarPromocion(promo);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);
            _logica.AddDeposito(depo1, user);
            _logica.AddDeposito(depo2, user);
            Promocion promo1 = new("asd", 33, DateTime.Today, DateTime.Today) { Id = 1 };

            // Act
            DepositoLogicExcepcion ex = Assert.ThrowsException<DepositoLogicExcepcion>(() => _logica.ModificarPromocionDepositos(1, null, user));

            //Assert
            Assert.AreEqual("La promo en ModificarPromocionDepositos no puede ser null", ex.Message);


        }

        [TestMethod]
        public void Verificar_ModificarPromocionDepositos_user_Null()
        {
            Promocion promo = new("promo", 30, DateTime.Today, DateTime.Today) { Id = 1 };
            Deposito depo1 = new('A', 'S', false);
            Deposito depo2 = new('A', 'S', false);
            depo1.AgregarPromocion(promo);
            depo2.AgregarPromocion(promo);
            Usuario user = new("Pedro", "pedro@gmail.com", "Pedro1234!", true);
            _logica.AddDeposito(depo1, user);
            _logica.AddDeposito(depo2, user);
            Promocion promo1 = new("asd", 33, DateTime.Today, DateTime.Today) { Id = 1 };

            // Act
            DepositoLogicExcepcion ex = Assert.ThrowsException<DepositoLogicExcepcion>(() => _logica.ModificarPromocionDepositos(1, promo1, null));

            //Assert
            Assert.AreEqual("El usuario en ModificarPromocionDepositos no puede ser null", ex.Message);


        }
    }
}