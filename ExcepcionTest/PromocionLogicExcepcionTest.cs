using Excepcion;
namespace ExcepcionTest
{
    [TestClass]
    public class PromocionLogicExcepcionTest
    {

        [TestMethod]
        public void CrearExcepcion_ConMensaje_MensajeCorrecto()
        {
            // Arrange
            string mensaje = "Este es un mensaje de prueba";

            // Act
            PromocionLogicExcepcion excepcion = new(mensaje);

            // Assert
            Assert.AreEqual(mensaje, excepcion.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(PromocionLogicExcepcion))]
        public void LanzarExcepcion_CuandoOcurre()
        {
            // Act
            // Realizar una acci�n que deber�a lanzar la excepci�n
            throw new PromocionLogicExcepcion("Mensaje de prueba");
        }
    }
}
