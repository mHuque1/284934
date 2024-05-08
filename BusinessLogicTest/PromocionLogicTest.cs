using BusinessLogic;
using Dominio;
using Excepcion;
using Repositorio;


namespace BusinessLogicTest
{
    [TestClass]
    public class PromocionLogicTest
    {
        private static IRepository<Promocion> _promocion = new PromocionRepository();
        private PromocionLogic _logica = new(_promocion);


        [TestInitialize]
        public void Setup()
        {
            _promocion = new PromocionRepository();
            _logica = new PromocionLogic(_promocion);
        }

        [TestMethod]
        public void Verificar_Logica_No_Es_Null()
        {
            // Assert
            Assert.IsNotNull(_logica);

        }

        [TestMethod]
        public void Verificar_Alta_Promocion()
        {
            // Arrange
            Promocion promo = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10));
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", true);
            // Act
            _logica.AddPromocion(promo, user);
            Promocion resultado = _logica.GetPromocion(0);

            // Assert
            Assert.AreEqual(promo, resultado);

        }

        [TestMethod]
        public void No_Deberia_Permitir_Agregar_Promocion_Null()
        {
            //Arrange
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", true);
            //Act
            PromocionLogicExcepcion ex = Assert.ThrowsException<PromocionLogicExcepcion>(() => _logica.AddPromocion(null, user));
            //Assert
            Assert.AreEqual("Una promocion en AddPromocion no puede ser null", ex.Message);
        }



        [TestMethod]
        public void No_Deberia_Permitir_Agregar_Promocion_Usuario_Null()
        {
            //Arrange
            Promocion promo1 = new("promo1", 10, DateTime.Today, DateTime.Today.AddDays(10));
            //Act
            PromocionLogicExcepcion ex = Assert.ThrowsException<PromocionLogicExcepcion>(() => _logica.AddPromocion(promo1, null));
            //Assert
            Assert.AreEqual("Un user en AddPromocion no puede ser null", ex.Message);
        }

        [TestMethod]
        public void No_Deberia_Permitir_Agregar_Promocion_Usuario_No_Admin()
        {
            //Arrange
            Promocion promo1 = new("promo1", 10, DateTime.Today, DateTime.Today.AddDays(10));
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", false);
            //Act

            PromocionLogicExcepcion ex = Assert.ThrowsException<PromocionLogicExcepcion>(() => _logica.AddPromocion(promo1, user));
            Assert.AreEqual("Solo un Admin puede agregar una promocion", ex.Message);
        }

        [TestMethod]
        public void Verificar_Get_Promociones()
        {
            // Arrange
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", true);
            Promocion promo1 = new("promo1", 10, DateTime.Today, DateTime.Today.AddDays(10));
            Promocion promo2 = new("promo2", 10, DateTime.Today, DateTime.Today.AddDays(10));
            Promocion promo3 = new("promo2", 10, DateTime.Today, DateTime.Today.AddDays(10));
            _logica.AddPromocion(promo1, user);
            _logica.AddPromocion(promo2, user);
            _logica.AddPromocion(promo3, user);
            // Act
            IList<Promocion> resultado = _logica.GetPromociones();

            // Assert
            Assert.IsTrue(resultado.Contains(promo1));
            Assert.IsTrue(resultado.Contains(promo2));
            Assert.IsTrue(resultado.Contains(promo3));

        }





        [TestMethod]
        public void Verificar_Baja_Promocion_Null()
        {
            // Arrange
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", true);

            // Act
            PromocionLogicExcepcion ex = Assert.ThrowsException<PromocionLogicExcepcion>(() => _logica.DeletePromocion(0, null, user));

            //Assert
            Assert.AreEqual("Una promocion en DeletePromocion no puede ser null", ex.Message);

        }

        [TestMethod]
        public void Verificar_Baja_Promocion()
        {
            // Arrange
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", true);
            Promocion promo = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10));
            _logica.AddPromocion(promo, user);
            // Act
            _logica.DeletePromocion(0, promo, user);
            IList<Promocion> promociones = _logica.GetPromociones();

            // Assert
            Assert.IsFalse(promociones.Contains(promo));

        }

        [TestMethod]
        public void Verificar_Baja_Promocion_User_Null()
        {
            // Arrange
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", true);
            Promocion promo = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10));
            _logica.AddPromocion(promo, user);

            // Act
            PromocionLogicExcepcion ex = Assert.ThrowsException<PromocionLogicExcepcion>(() => _logica.DeletePromocion(0, promo, null));

            //Assert
            Assert.AreEqual("Un usuario en DeletePromocion no puede ser null", ex.Message);


        }

        [TestMethod]

        public void Verificar_Baja_Promocion_User_No_Admin()
        {
            // Arrange
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", true);
            Promocion promo = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10));
            _logica.AddPromocion(promo, user);
            Usuario user1 = new("nombre", "asd@gmail.com", "ASDasd123!", false);
            // Act

            PromocionLogicExcepcion ex = Assert.ThrowsException<PromocionLogicExcepcion>(() => _logica.DeletePromocion(0, promo, user1));
            Assert.AreEqual("Solo un Admin puede dar de baja una promocion", ex.Message);

        }

        [TestMethod]
        public void Verificar_Modificacion_Promocion()
        {
            // Arrange
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", true);
            Promocion promocion = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10));
            _logica.AddPromocion(promocion, user);

            // Act
            promocion = new Promocion("promooo", 15, DateTime.Today.AddDays(10), DateTime.Today.AddDays(15));
            _logica.ModificarPromocion(0, promocion, user);
            Promocion resultado = _logica.GetPromocion(0);

            // Assert
            Assert.AreNotEqual("promo", resultado.Etiqueta);
            Assert.AreNotEqual(10, resultado.Descuento);
            Assert.AreNotEqual(DateTime.Today, resultado.Comienzo);
            Assert.AreNotEqual(DateTime.Today.AddDays(10), resultado.Fin);
        }

        [TestMethod]
        public void Verificar_Modificacion_Promocion_Null()
        {
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", true);

            PromocionLogicExcepcion ex = Assert.ThrowsException<PromocionLogicExcepcion>(() => _logica.ModificarPromocion(0, null, user));
            Assert.AreEqual("Una promocion en ModificarPromocion no puede ser null", ex.Message);
        }

        [TestMethod]
        public void Verificar_Modificacion_Promocion_User_Null()
        {
            Promocion promocion = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10));
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", true);
            _logica.AddPromocion(promocion, user);

            PromocionLogicExcepcion ex = Assert.ThrowsException<PromocionLogicExcepcion>(() => _logica.ModificarPromocion(0, promocion, null));
            Assert.AreEqual("El usuario en ModificarPromocion no puede ser null", ex.Message);
        }

        [TestMethod]
        public void Verificar_Modificacion_Promocion_User_No_Admin()
        {
            Promocion promocion = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10));
            Usuario user = new("nombre", "asd@gmail.com", "ASDasd123!", true);
            _logica.AddPromocion(promocion, user);
            Usuario user1 = new("nombre", "asd@gmail.com", "ASDasd123!", false);
            PromocionLogicExcepcion ex = Assert.ThrowsException<PromocionLogicExcepcion>(() => _logica.ModificarPromocion(0, promocion, user1));
            Assert.AreEqual("Solamente un admin puede modificar una promocion", ex.Message);
        }

    }
}
