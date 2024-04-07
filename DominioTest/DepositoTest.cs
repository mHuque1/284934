using Dominio;
using Excepcion;

namespace DominioTest
{
    [TestClass]
    public class DepositoTest
    {
        [TestMethod]
        public void Deberia_Crear_Un_Deposito()
        {
            var deposito = new Deposito();
            Assert.IsNotNull(deposito);
        }

        [TestMethod]
        public void Deberia_Obtener_Area()
        {
            var deposito = new Deposito { Area = 'A' };
            Assert.AreEqual('A', deposito.Area);
        }

        [TestMethod]
        public void Deberia_Obtener_Tamano()
        {
            var deposito = new Deposito { Tamano = 'S' };
            Assert.AreEqual('S', deposito.Tamano);
        }

        [TestMethod]
        public void Deberia_Obtener_Climatizacion()
        {
            var deposito = new Deposito { Climatizacion = true };
            Assert.IsTrue(deposito.Climatizacion);
        }

        [TestMethod]
        public void Deberia_Tener_Las_Promociones_Agregadas()
        {
            var deposito = new Deposito
            {
                Area = 'A',
                Tamano = 'S',
                Climatizacion = true
            };

            var promocion = new Promocion
            {
                Etiqueta = "AAA",
                Descuento = 10,
                Desde = DateTime.Today,
                Hasta = DateTime.Today.AddDays(10)
            };

            deposito.AgregarPromocion(promocion);

            Assert.AreEqual(1, deposito.Promociones.Count);
            Assert.AreEqual(promocion, deposito.Promociones[0]);
        }

        [TestMethod]
        public void Areas_ABCDE_Validas_Para_Registro()
        {
            // Arrange: Configurar el entorno de prueba
            Deposito depositoA = new Deposito { id = 1, Area = 'A', Tamano = 'S', climatizacion = true };
            Deposito depositoB = new Deposito { id = 2, Area = 'B', Tamano = 'S', climatizacion = true };
            Deposito depositoC = new Deposito { id = 3, Area = 'C', Tamano = 'S', climatizacion = true };
            Deposito depositoD = new Deposito { id = 4, Area = 'D', Tamano = 'S', climatizacion = true };
            Deposito depositoE = new Deposito { id = 5, Area = 'E', Tamano = 'S', climatizacion = true };

            // Act: Ejecutar la acción que se va a probar
            depositoLogic.addDeposito(depositoA);
            depositoLogic.addDeposito(depositoB);
            depositoLogic.addDeposito(depositoC);
            depositoLogic.addDeposito(depositoD);
            depositoLogic.addDeposito(depositoE);

            // Assert: Verificar que el resultado es el esperado
            Assert.IsTrue(_depositos.GetAll().Contains(depositoA));
            Assert.IsTrue(_depositos.GetAll().Contains(depositoB));
            Assert.IsTrue(_depositos.GetAll().Contains(depositoC));
            Assert.IsTrue(_depositos.GetAll().Contains(depositoD));
            Assert.IsTrue(_depositos.GetAll().Contains(depositoE));
        }

        [TestMethod]
        public void Tamanos_SML_Validas_Para_Registro()
        {
            // Arrange: Configurar el entorno de prueba
            Deposito depositoS = new Deposito { id = 1, Area = 'A', Tamano = 'S', climatizacion = true };
            Deposito depositoM = new Deposito { id = 2, Area = 'A', Tamano = 'M', climatizacion = true };
            Deposito depositoL = new Deposito { id = 3, Area = 'A', Tamano = 'L', climatizacion = true };

            // Act: Ejecutar la acción que se va a probar
            depositoLogic.addDeposito(depositoS);
            depositoLogic.addDeposito(depositoM);
            depositoLogic.addDeposito(depositoL);

            // Assert: Verificar que el resultado es el esperado
            Assert.IsTrue(_depositos.GetAll().Contains(depositoS));
            Assert.IsTrue(_depositos.GetAll().Contains(depositoM));
            Assert.IsTrue(_depositos.GetAll().Contains(depositoL));
        }
    }
}
