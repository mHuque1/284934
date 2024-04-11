using BusinessLogic;
using Dominio;
using Repositorio;


namespace BusinessLogicTest
{
    [TestClass]
    internal class PromocionLogicTest
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
        public void Verificar_Baja_Promocion()
        {
            // Arrange
            Promocion promo = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10), 'S');
            _logica.AddPromocion(promo);
            // Act
            _logica.DeletePromocion(promo);
            Promocion resultado = _logica.GetPromocion(0);

            // Assert
            Assert.AreEqual(promo, resultado);

        }

        [TestMethod]
        public void Verificar_Modificacion_Promocion()
        {
            // Arrange
            Promocion promo = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(10), 'S');
            _logica.AddPromocion(promo);

            // Act
            promo = new Promocion("promooo", 15, DateTime.Today.AddDays(10), DateTime.Today.AddDays(15), 'M');
            _logica.ModificarPromocion(0, promo);
            Promocion resultado = _logica.GetPromocion(0);

            // Assert
            Assert.AreNotEqual(promo.Etiqueta, resultado.Etiqueta);
            Assert.AreNotEqual(promo.Descuento, resultado.Descuento);
            Assert.AreNotEqual(promo.Comienzo, resultado.Comienzo);
            Assert.AreNotEqual(promo.Fin, resultado.Fin);
            Assert.AreNotEqual(promo.TipoDeposito, resultado.TipoDeposito);
        }

    }
}
