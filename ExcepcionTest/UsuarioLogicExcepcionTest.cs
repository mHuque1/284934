using Excepcion;
namespace ExcepcionTest
{
    [TestClass]
    public class UsuarioLogicExcepcionTest
    {

        [TestMethod]
        public void CrearExcepcion_ConMensaje_MensajeCorrecto()
        {
            // Arrange
            string mensaje = "Este es un mensaje de prueba";

            // Act
            UsuarioLogicExcepcion excepcion = new(mensaje);

            // Assert
            Assert.AreEqual(mensaje, excepcion.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioLogicExcepcion))]
        public void LanzarExcepcion_CuandoOcurre()
        {
            // Act
            // Realizar una acción que debería lanzar la excepción
            throw new UsuarioLogicExcepcion("Mensaje de prueba");
        }
    }
}
