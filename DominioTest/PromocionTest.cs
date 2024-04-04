using Dominio;
using Excepcion;

namespace DominioTest
{
    [TestClass]
    public class PromocionTest
    {
        [TestMethod]
        public void Deberia_Crear_Un_Usuario()
        {
            // Arrange
            var usuario = new Usuario();

            // Assert
            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        
        public void Etiqueta_Deberia_Tener_Maximo_Veinte_Caracteres()
        {
            // Arrange
            var unaPromocion = new Promocion { Etiqueta = "abcdefghijklmnopqrstu" };

            // Act
            var resultado = unaPromocion.ValidarEtiqueta();

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Descuento_Deberia_Tener_Minimo_Cinco()
        {
            // Arrange
            var unaPromocion = new Promocion { Descuento = 4 };

            // Act
            var resultado = unaPromocion.ValidarDescuento();

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Descuento_Deberia_Tener_Maximo_Setenta_Y_Cinco()
        {
            // Arrange
            var unaPromocion = new Promocion { Descuento = 76 };

            // Act
            var resultado = unaPromocion.ValidarDescuento();

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Promocion_Deberia_Ser_Valida()
        {
            // Arrange
            var unaPromocion = new Promocion
            {
                Desde = DateTime.Today,
                Hasta = DateTime.Today.AddDays(10)
            };

            // Act
            var resultado = unaPromocion.ValidarPromocion();

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Promocion_Deberia_Ser_Invalida()
        {
            // Arrange
            var unaPromocion = new Promocion
            {
                Desde = DateTime.Today.AddDays(-20),
                Hasta = DateTime.Today.AddDays(-10)
            };

            // Act
            var resultado = unaPromocion.ValidarPromocion();

            // Assert
            Assert.IsFalse(resultado);
        }
    }
}
