using Dominio;
using Excepcion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DominioTest
{
    [TestClass]
    public class PromocionTest
    {
        private Promocion promocion;

        [TestInitialize]
        public void Setup()
        {
            // Arrange: Configuración inicial para cada prueba
            promocion = new Promocion(
                id: 1,
                etiqueta: "Promocion1",
                descuento: 10,
                comienzo: DateTime.Today,
                fin: DateTime.Today.AddDays(3)
            );
        }

        [TestMethod]
        public void Deberia_Crear_Una_Promocion()
        {
            // Act: Ejecutar la acción que se quiere probar
            // Assert: Verificar que se haya realizado la acción correctamente
            Assert.IsNotNull(promocion);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioPromocionExcepcion))]
        public void Etiqueta_No_Deberia_Tener_Mas_de_Veinte_Caracteres()
        {
            // Arrange
            // Act & Assert
            promocion.Etiqueta = "abcdefghijklmnopqrstu";
        }

        [TestMethod]
        public void Etiqueta_Puede_Tener_Veinte_Caracteres()
        {
            // Arrange
            string esperado = "abcdefghijklmnopqrst";
            // Act
            promocion.Etiqueta = esperado;
            string obtenido = promocion.Etiqueta;

            // Assert
            Assert.AreEqual(esperado, obtenido);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioPromocionExcepcion))]
        public void Descuento_Deberia_Ser_Minimo_Cinco()
        {
            // Arrange
            // Act & Assert
            promocion.Descuento = 4;
        }

        [TestMethod]
        public void Descuento_Puede_Ser_Cinco()
        {   
            // Arrange
            int esperado = 5;
           
            // Act
            promocion.Descuento = esperado;
            int obtenido = promocion.Descuento;

            // Assert
            Assert.AreEqual(esperado, obtenido);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioPromocionExcepcion))]
        public void Descuento_Deberia_Ser_Maximo_Setenta_Y_Cinco()
        {
            // Arrange
            // Act & Assert
            promocion.Descuento = 76;
        }

        [TestMethod]
        public void Descuento_Puede_Ser_Setenta_Y_Cinco()
        {
            // Arrange
            int esperado = 75;

            // Act
            promocion.Descuento = esperado;
            int obtenido = promocion.Descuento;

            // Assert
            Assert.AreEqual(esperado, obtenido);
        }

        [TestMethod]
        public void Promocion_Deberia_Ser_Valida()
        {
            // Arrange & Act
            bool resultado = promocion.EstaVigente();

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Promocion_Deberia_Ser_Invalida()
        {
            // Arrange
            promocion.Comienzo = DateTime.Today.AddDays(-10);
            promocion.Fin = DateTime.Today.AddDays(-3);

            // Act
            bool resultado = promocion.EstaVigente();

            // Assert
            Assert.IsFalse(resultado);
        }
    }
}
