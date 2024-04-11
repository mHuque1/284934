using Excepcion;
namespace ExcepcionTest
{
    [TestClass]
    public class DepositoLogicExcepcionTest
    {

        [TestMethod]
        public void CrearExcepcion_ConMensaje_MensajeCorrecto()
        {
            // Arrange
            string mensaje = "Este es un mensaje de prueba";

            // Act
            DepositoLogicExcepcion excepcion = new(mensaje);

            // Assert
            Assert.AreEqual(mensaje, excepcion.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(DepositoLogicExcepcion))]
        public void LanzarExcepcion_CuandoOcurre()
        {
            // Act
            // Realizar una acci�n que deber�a lanzar la excepci�n
            throw new DepositoLogicExcepcion("Mensaje de prueba");
        }
    }
}
