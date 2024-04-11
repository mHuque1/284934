using Excepcion;
namespace ExcepcionTest
{
    [TestClass]
    public class DominioReservaExcepcionTest
    {

        [TestMethod]
        public void CrearExcepcion_ConMensaje_MensajeCorrecto()
        {
            // Arrange
            string mensaje = "Este es un mensaje de prueba";

            // Act
            DominioReservaExcepcion excepcion = new(mensaje);

            // Assert
            Assert.AreEqual(mensaje, excepcion.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioReservaExcepcion))]
        public void LanzarExcepcion_CuandoOcurre()
        {
            // Act
            // Realizar una acci�n que deber�a lanzar la excepci�n
            throw new DominioReservaExcepcion("Mensaje de prueba");
        }
    }
}
