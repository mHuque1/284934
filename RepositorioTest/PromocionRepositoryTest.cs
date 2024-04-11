using Dominio;
using Repositorio;

namespace RepositorioTest
{
    [TestClass]
    public class PromocionRepositoryTest
    {
        private IRepository<Promocion> _promocion = new PromocionRepository();
        private readonly Promocion promo = new("asd", 10, DateTime.Today, DateTime.Today.AddDays(5), 'S');

        [TestInitialize]
        public void Setup()
        {
            _promocion = new PromocionRepository();
        }

        [TestMethod]
        public void Verifico_Que_Funcione_El_Alta_De_Promocion()
        {
            // Act
            _promocion.Add(promo);
            IList<Promocion> promociones = _promocion.GetAll();

            // Assert
            Assert.IsTrue(promociones.Contains(promo));
        }

        [TestMethod]
        public void Verifico_Que_Funcione_La_Baja_De_Promocion()
        {
            // Arrange
            _promocion.Add(promo);

            // Act
            _promocion.Delete(promo);
            IList<Promocion> promociones = _promocion.GetAll();

            // Assert
            Assert.IsFalse(promociones.Contains(promo));
        }

        [TestMethod]
        public void Verifico_Que_Funcione_La_Modificacion_De_Promocion()
        {
            // Arrange
            _promocion.Add(promo);

            // Act
            Promocion promocionModificada = new("ddd", 15, DateTime.Today.AddDays(5), DateTime.Today.AddDays(10), 'M') { Id = promo.Id };
            _promocion.Update(promocionModificada);
            Promocion promocionActualizada = _promocion.Find(d => d.Id == promo.Id);

            // Assert
            Assert.IsNotNull(promocionActualizada);
            Assert.AreEqual("ddd", promocionActualizada.Etiqueta);
            Assert.AreEqual(15, promocionActualizada.Descuento);
            Assert.AreEqual(DateTime.Today.AddDays(5), promocionActualizada.Comienzo);
            Assert.AreEqual(DateTime.Today.AddDays(10), promocionActualizada.Fin);
        }
    }
}
