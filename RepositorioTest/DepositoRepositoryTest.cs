using System.Data.Common;
using Dominio;
using Repositorio;

namespace RepositorioTest
{
    [TestClass]
    public class DepositoRepositoryTest
    {
        private IRepository<Deposito> _depositos;

        [TestInitialize]
        public void Setup()
        {
            _depositos = new DepositoRepository();
        }


        [TestMethod]
        public void Deberia_Verificar_Alta_De_Deposito()
        {
            // Arrange
            IRepository<Deposito> _depositos = new DepositoRepository();
            Deposito depo = new Deposito
            {
                Area = 'A',
                Tamano = 'S',
                Climatizacion = true
            };

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
            IRepository<Deposito> _depositos = new DepositoRepository();
            Deposito depo = new Deposito
            {
                Area = 'A',
                Tamano = 'S',
                Climatizacion = true
            };

            // Act
            _depositos.Add(depo);
            var depositos = _depositos.GetAll();

            // Assert
            Assert.IsFalse(depositos.Contains(depo));
        }



        [TestMethod]
        public void Deberia_Actualizar_Deposito()
        {
            // Arrange
            IRepository<Deposito> _depositos = new DepositoRepository();
            Deposito depo = new Deposito
            {   
                id = 1,
                Area = 'A',
                Tamano = 'S',
                Climatizacion = true
            };

            _depositos.Add(depo);

            // Act
            depo.Tamano = 'M';
            _depositos.Update(depo);
            var usuarioModificado = _depositos.Find(d => d.id == 1);

            // Assert
            Assert.IsNotNull(usuarioModificado);
            Assert.AreEqual('M', usuarioModificado.tamano);
        }


    }
}
