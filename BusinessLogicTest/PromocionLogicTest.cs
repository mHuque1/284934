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
            Promocion promo = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10), 'S');
            // Act
            _logica.AddPromocion(promo);
            Promocion resultado = _logica.GetPromocion(0);

            // Assert
            Assert.AreEqual(promo, resultado);

        }

        [TestMethod]
        [ExpectedException(typeof(PromocionLogicExcepcion))]
        public void No_Deberia_Permitir_Agregar_Reserva_Null()
        {
            //Act
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _logica.AddPromocion(null);
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        public void Verificar_Get_Promociones()
        {
            // Arrange
            Promocion promo1 = new("promo1", 10, DateTime.Today, DateTime.Today.AddDays(10), 'S');
            Promocion promo2 = new("promo2", 10, DateTime.Today, DateTime.Today.AddDays(10), 'M');
            Promocion promo3 = new("promo2", 10, DateTime.Today, DateTime.Today.AddDays(10), 'S');
            _logica.AddPromocion(promo1);
            _logica.AddPromocion(promo2);
            _logica.AddPromocion(promo3);
            // Act
            IList<Promocion> resultado = _logica.GetPromociones();

            // Assert
            Assert.IsTrue(resultado.Contains(promo1));
            Assert.IsTrue(resultado.Contains(promo2));
            Assert.IsTrue(resultado.Contains(promo3));

        }

        [TestMethod]
        public void Verificar_Get_Promociones_Por_Tipo()
        {
            // Arrange
            Promocion promo1 = new("promo1", 10, DateTime.Today, DateTime.Today.AddDays(10), 'S');
            Promocion promo2 = new("promo2", 10, DateTime.Today, DateTime.Today.AddDays(10), 'M');
            Promocion promo3 = new("promo2", 10, DateTime.Today, DateTime.Today.AddDays(10), 'S');
            _logica.AddPromocion(promo1);
            _logica.AddPromocion(promo2);
            _logica.AddPromocion(promo3);
            // Act
            IList<Promocion> resultado = _logica.GetPromocionesPorTipo('S');

            // Assert
            Assert.IsTrue(resultado.Contains(promo1));
            Assert.IsFalse(resultado.Contains(promo2));
            Assert.IsTrue(resultado.Contains(promo3));

        }



        [TestMethod]
        [ExpectedException(typeof(PromocionLogicExcepcion))]
        public void Verificar_Baja_Promocion_Null()
        {
            // Act
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _logica.DeletePromocion(0, null);
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        }

        [TestMethod]
        public void Verificar_Baja_Promocion()
        {
            // Arrange
            Promocion promo = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10), 'S');
            _logica.AddPromocion(promo);
            // Act
            _logica.DeletePromocion(0, promo);
            IList<Promocion> promociones = _logica.GetPromociones();

            // Assert
            Assert.IsFalse(promociones.Contains(promo));

        }

        [TestMethod]
        public void Verificar_Modificacion_Promocion()
        {
            // Arrange
            Promocion promocion = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10), 'S');
            _logica.AddPromocion(promocion);

            // Act
            promocion = new Promocion("promooo", 15, DateTime.Today.AddDays(10), DateTime.Today.AddDays(15), 'M');
            _logica.ModificarPromocion(0, promocion);
            Promocion resultado = _logica.GetPromocion(0);

            // Assert
            Assert.AreNotEqual("promo", resultado.Etiqueta);
            Assert.AreNotEqual(10, resultado.Descuento);
            Assert.AreNotEqual(DateTime.Today, resultado.Comienzo);
            Assert.AreNotEqual(DateTime.Today.AddDays(10), resultado.Fin);
            Assert.AreNotEqual('S', resultado.TipoDeposito);
        }

        [TestMethod]
        [ExpectedException(typeof(PromocionLogicExcepcion))]
        public void Verificar_Modificacion_Promocion_Null()
        {
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _logica.ModificarPromocion(0, null);
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

    }
}
