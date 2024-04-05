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
    }
}
