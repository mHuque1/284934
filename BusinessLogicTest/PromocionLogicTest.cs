using BusinessLogic;
using Dominio;
using Repositorio;


namespace BusinessLogicTest
{
    [TestClass]
    internal class PromocionLogicTest
    {
        private PromocionLogic _logica;
        private IRepository<Promocion> _promocion;

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
            Promocion promo = new Promocion(1,"promo",10,DateTime.Today,DateTime.Today.AddDays(10));
            // Act
            _logica.AddPromocion(promo);
            Promocion resultado = _logica.GetPromocion(1);

            // Assert
            Assert.AreEqual(promo, resultado);

        }

    }
}
