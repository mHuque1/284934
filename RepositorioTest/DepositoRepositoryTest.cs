using Dominio;
using Repositorio;

namespace RepositorioTest
{
    [TestClass]
    public class DepositoRepositoryTest
    {
        private IRepository<Deposito> _depositos = new DepositoRepository();
        private Deposito depo = new('A', 'S', true);

        [TestInitialize]
        public void Setup()
        {
            depo = new Deposito('A', 'S', true);
            _depositos = new DepositoRepository();
        }


        [TestMethod]
        public void Verifico_Que_Funcione_El_Alta_De_Deposito()
        {

            // Act
            _depositos.Add(depo);
            var depositos = _depositos.GetAll();

            // Assert
            Assert.IsTrue(depositos.Contains(depo));
        }


        [TestMethod]
        public void Verifico_Que_Funcione_La_Baja_De_Deposito()
        {
            // Arrange
            _depositos.Add(depo);

            // Act
            _depositos.Delete(depo);
            var depositos = _depositos.GetAll();


            // Assert
            Assert.IsFalse(depositos.Contains(depo));
        }



        [TestMethod]
        public void Verifico_Que_Funcione_La_Modificacion_De_Deposito()
        {
            // Arrange
            _depositos.Add(depo);
            depo = new('B', 'M', false) { ID=0};
            // Act
            _depositos.Update(depo);
            var usuarioModificado = _depositos.Find(d => d.ID == 0);

            // Assert
            Assert.IsNotNull(usuarioModificado);
            Assert.AreEqual('B', usuarioModificado.Area);
            Assert.AreEqual('M', usuarioModificado.Tamano);
            Assert.AreEqual(false, usuarioModificado.TieneClimatizacion);
        }
    }
}
