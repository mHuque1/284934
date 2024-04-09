using System.Data.Common;
using Dominio;
using Repositorio;

namespace RepositorioTest
{
    [TestClass]
    public class DepositoRepositoryTest
    {
        private IRepository<Deposito> _depositos;
        private Deposito depo;

        [TestInitialize]
        public void Setup()
        {
            depo = new Deposito(1, 'A', 'S', true);
            _depositos = new DepositoRepository();
        }


        [TestMethod]
        public void Deberia_Verificar_Alta_De_Deposito()
        {

            // Act
            _depositos.Add(depo);
            var depositos = _depositos.GetAll();

            // Assert
            Assert.IsTrue(depositos.Contains(depo));
        }
    

        [TestMethod]
        public void Deberia_Verificar_Baja_De_Deposito()
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
        public void Deberia_Actualizar_Tamano_Deposito()
        {
            // Arrange
            _depositos.Add(depo);

            // Act
            depo.Tamano = 'M';
            _depositos.Update(depo);
            var usuarioModificado = _depositos.Find(d => d.ID == 1);

            // Assert
            Assert.IsNotNull(usuarioModificado);
            Assert.AreEqual('M', usuarioModificado.Tamano);
        }

        [TestMethod]
        public void Deberia_Actualizar_Area_Deposito()
        {
            // Arrange
            _depositos.Add(depo);

            // Act
            depo.Area = 'A';
            _depositos.Update(depo);
            var usuarioModificado = _depositos.Find(d => d.ID == 1);

            // Assert
            Assert.IsNotNull(usuarioModificado);
            Assert.AreEqual('A', usuarioModificado.Area);
        }

        [TestMethod]
        public void Deberia_Actualizar_Climatizacion_Deposito()
        {
            // Arrange
            _depositos.Add(depo);

            // Act
            depo.TieneClimatizacion = false;
            _depositos.Update(depo);
            var usuarioModificado = _depositos.Find(d => d.ID == 1);

            // Assert
            Assert.IsNotNull(usuarioModificado);
            Assert.AreEqual(false, usuarioModificado.TieneClimatizacion);
        }


    }
}
