using Excepcion;
namespace ExcepcionTest
{
    [TestClass]
    public class DominioDepositoExcepcionTest
    {

        [TestMethod]
        public void CrearExcepcion_ConMensaje_MensajeCorrecto()
        {
            // Arrange
            string mensaje = "Este es un mensaje de prueba";

            // Act
            DominioDepositoExcepcion excepcion = new DominioDepositoExcepcion(mensaje);

            // Assert
            Assert.AreEqual(mensaje, excepcion.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioDepositoExcepcion))]
        public void LanzarExcepcion_CuandoOcurre()
        {
            // Act
            // Realizar una acci�n que deber�a lanzar la excepci�n
            throw new DominioDepositoExcepcion("Mensaje de prueba");
        }
    }
}
