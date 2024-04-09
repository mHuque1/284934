using Excepcion;
namespace ExcepcionTest
{
    [TestClass]
    public class DominioUsuarioExcepcionTest
    {

        [TestMethod]
        public void CrearExcepcion_ConMensaje_MensajeCorrecto()
        {
            // Arrange
            string mensaje = "Este es un mensaje de prueba";

            // Act
            DominioUsuarioExcepcion excepcion = new DominioUsuarioExcepcion(mensaje);

            // Assert
            Assert.AreEqual(mensaje, excepcion.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void LanzarExcepcion_CuandoOcurre()
        {
            // Act
            // Realizar una acción que debería lanzar la excepción
            throw new DominioUsuarioExcepcion("Mensaje de prueba");
        }
    }
}
