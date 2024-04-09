using Dominio;
using Repositorio;

namespace RepositorioTest
{
    [TestClass]
    public class PromocionRepositoryTest
    {
        private IRepository<Promocion> _promocion;
        private Promocion promo;

        [TestInitialize]
        public void Setup()
        {
            promo = new Promocion(1, "asd", 10,DateTime.Today,DateTime.Today.AddDays(5));
            _promocion = new PromocionRepository();
        }


        [TestMethod]
        public void Deberia_Verificar_Alta_De_Promocion()
        {

            // Act
            _promocion.Add(promo);
            IList<Promocion> Promociones = _promocion.GetAll();

            // Assert
            Assert.IsTrue(Promociones.Contains(promo));
        }
    

        [TestMethod]
        public void Deberia_Verificar_Baja_De_Promocion()
        {
            // Arrange
            _promocion.Add(promo);

            // Act

            _promocion.Delete(promo);
            var Promocions = _promocion.GetAll();
            

            // Assert
            Assert.IsFalse(Promocions.Contains(promo));
        }



        [TestMethod]
        public void Deberia_Actualizar_Descuento_Promocion()
        {
            // Arrange
            _promocion.Add(promo);
            
            // Act
            promo.Descuento = 15;
            _promocion.Update(promo);
            Promocion PromocionModificada = _promocion.Find(d => d.Id == 1);

            // Assert
            Assert.IsNotNull(PromocionModificada);
            Assert.AreEqual(15, PromocionModificada.Descuento);
        }

        [TestMethod]
        public void Deberia_Actualizar_Fin_Promocion()
        {
            // Arrange
            _promocion.Add(promo);

            // Act
            promo.Fin = DateTime.Today.AddDays(2);
            _promocion.Update(promo);
            Promocion PromocionModificada = _promocion.Find(d => d.Id == 1);

            // Assert
            Assert.IsNotNull(PromocionModificada);
            Assert.AreEqual(DateTime.Today.AddDays(2), PromocionModificada.Fin);
        }


    }
}
