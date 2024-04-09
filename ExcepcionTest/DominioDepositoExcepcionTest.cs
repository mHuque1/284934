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
            // Realizar una acción que debería lanzar la excepción
            throw new DominioDepositoExcepcion("Mensaje de prueba");
        }
    }
}
