using Dominio;
using Excepcion;

namespace DominioTest
{
    [TestClass]
    public class PromocionTest
    {
        [TestMethod]
        public void Deberia_Crear_Una_Promocion()
        {
            var promo = new Promocion();
            Assert.IsNotNull(promo);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioPromocionExcepcion))]
        public void Etiqueta_No_Deberia_Tener_Mas_de_Veinte_Caracteres()
        {
            var unaPromocion = new Promocion { Etiqueta = "abcdefghijklmnopqrstu" };
        }

        [TestMethod]
        public void Etiqueta_Puede_Tener_Veinte_Caracteres()
        {
            var unaPromocion = new Promocion { Etiqueta = "abcdefghijklmnopqrst" };
            Assert.AreEqual("abcdefghijklmnopqrst", unaPromocion.Etiqueta);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioPromocionExcepcion))]
        public void Descuento_Deberia_Ser_Minimo_Cinco()
        {
            var unaPromocion = new Promocion { Descuento = 4 };
        }

        [TestMethod]
        public void Descuento_Puede_Ser_Cinco()
        {
            var unaPromocion = new Promocion { Descuento = 5 };
            Assert.AreEqual(5, unaPromocion.Descuento);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioPromocionExcepcion))]
        public void Descuento_Deberia_Ser_Maximo_Setenta_Y_Cinco()
        {
            var unaPromocion = new Promocion { Descuento = 76 };
        }

        [TestMethod]
        public void Descuento_Puede_Ser_Setenta_Y_Cinco()
        {
            var unaPromocion = new Promocion { Descuento = 75 };
            Assert.AreEqual(75, unaPromocion.Descuento);
        }

        [TestMethod]
        public void Promocion_Deberia_Ser_Valida()
        {
            var unaPromocion = new Promocion
            {
                Desde = DateTime.Today,
                Hasta = DateTime.Today.AddDays(10)
            };
            var resultado = unaPromocion.ValidarPromocion();
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Promocion_Deberia_Ser_Invalida()
        {
            var unaPromocion = new Promocion
            {
                Desde = DateTime.Today.AddDays(-20),
                Hasta = DateTime.Today.AddDays(-10)
            };
            var resultado = unaPromocion.ValidarPromocion();
            Assert.IsFalse(resultado);
        }
    }
}
