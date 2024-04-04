using Dominio;
using Excepcion;

namespace DominioTest
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void Deberia_Crear_Nuevo_Usuario()
        {
            // Arrange
            var usuario = new Usuario();

            // Act - No action needed for constructor

            // Assert
            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Deberia_Lanzar_Excepcion_Si_Nombre_Usuario_Vacio()
        {
            // Arrange
            Usuario unUsuario = new Usuario();

            // Act
            unUsuario.Nombre = "";

            // Assert - Exception expected
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Deberia_Lanzar_Excepcion_Si_Nombre_Usuario_Excede_Limite()
        {
            // Arrange
            Usuario unUsuario = new Usuario();

            // Act
            unUsuario.Nombre = "Valentina Alexandra Beatriz Carolina Daniela Estefanía Florencia Gabriela Helena Isabel Jimena Karina";

            // Assert - Exception expected
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Deberia_Lanzar_Excepcion_Si_Formato_Email_No_Valido()
        {
            // Arrange
            Usuario unUsuario = new Usuario();

            // Act
            unUsuario.Email = "usuario@dominio";

            // Assert - Exception expected
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Tener_Minimo_Ocho_Caracteres()
        {
            // Arrange
            Usuario unUsuario = new Usuario();
            unUsuario.Contrasena = "Pass1!";

            // Act
            string contrasena = unUsuario.Contrasena;
            bool resultado = unUsuario.Validar_Contrasena(contrasena);

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Tener_Un_Simbolo()
        {
            // Arrange
            Usuario unUsuario = new Usuario();
            unUsuario.Contrasena = "Contrasena123";

            // Act
            string contrasena = unUsuario.Contrasena;
            bool resultado = unUsuario.Validar_Contrasena(contrasena);

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Contener_Mayuscula()
        {
            // Arrange
            Usuario unUsuario = new Usuario();
            unUsuario.Contrasena = "contrasena1!";

            // Act
            string contrasena = unUsuario.Contrasena;
            bool resultado = unUsuario.Validar_Contrasena(contrasena);

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Contener_Minuscula()
        {
            // Arrange
            Usuario unUsuario = new Usuario();
            unUsuario.Contrasena = "CONTRASENA1!";

            // Act
            string contrasena = unUsuario.Contrasena;
            bool resultado = unUsuario.Validar_Contrasena(contrasena);

            // Assert
            Assert.IsFalse(resultado);
        }
    }
}
