using Excepcion;
namespace ExcepcionTest
{
    [TestClass]
    public class DominioPromocionExcepcionTest
    {

        [TestMethod]
        public void CrearExcepcion_ConMensaje_MensajeCorrecto()
        {
            // Arrange
            string mensaje = "Este es un mensaje de prueba";

            // Act
            DominioPromocionExcepcion excepcion = new DominioPromocionExcepcion(mensaje);

            // Assert
            Assert.AreEqual(mensaje, excepcion.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioPromocionExcepcion))]
        public void LanzarExcepcion_CuandoOcurre()
        {
            // Act
            // Realizar una acción que debería lanzar la excepción
            throw new DominioPromocionExcepcion("Mensaje de prueba");
        }
    }
}
