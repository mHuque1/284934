using BusinessLogic;
using Dominio;
using Excepcion;
using Repositorio;
using System.Runtime.Intrinsics.X86;

namespace BusinessLogicTest
{
    [TestClass]
    public class UsuarioLogicTest
    {
        private static IRepository<Usuario> _usuarios = new UsuarioRepository();
        private UsuarioLogic _logica = new(_usuarios);

        [TestInitialize]
        public void Inicializar()
        {
            _usuarios = new UsuarioRepository();
            _logica = new UsuarioLogic(_usuarios);
        }

        [TestMethod]
        public void Deberia_Crear_Logica_Usuario()
        {
            // Act
            UsuarioLogic logica = new(_usuarios);

            // Assert
            Assert.IsNotNull(logica);
        }


        [TestMethod]
        public void Deberia_Agregar_Usuario()
        {
            // Arrange
            Usuario usuario = new("Pedro Gomez", "Hola@user.com", "holaPedroGomez123!", false);

            // Act
            _logica.AddUsuario(usuario);

            // Assert
            Assert.IsTrue(_usuarios.GetAll().Contains(usuario));
        }

        [TestMethod]
        public void Validar_Existencia_Admin()
        {

            // Arrange
            Usuario admin1 = new("Pedro Gomez", "admin1@user.com", "holaPedroGomez123!", true);
            _logica.AddUsuario(admin1);

            // Act
            bool resultado = _logica.ExisteAdmin();

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Validar_No_Existencia_Admin()
        {

            // Arrange
            Usuario admin1 = new("Pedro Gomez", "admin1@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(admin1);

            // Act
            bool resultado = _logica.ExisteAdmin();

            //Assert
            Assert.IsFalse(resultado);
        }


        [TestMethod]
        [ExpectedException(typeof(UsuarioLogicExcepcion))]
        public void No_Deberia_Agregar_Mas_de_Un_Admin()
        {
            // Arrange
            Usuario admin1 = new("Pedro Gomez", "admin1@user.com", "holaPedroGomez123!", true);
            Usuario admin2 = new("Pedro Gomez", "admin2@user.com", "holaPedroGomez123!", true);

            // Act
            _logica.AddUsuario(admin1);
            _logica.AddUsuario(admin2);
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioLogicExcepcion))]
        public void No_Deberia_Permitir_Agregar_Usuario_Con_Igual_Email()
        {
            // Arrange
            Usuario user1 = new("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);

            // Act
            _logica.AddUsuario(user1);
            _logica.AddUsuario(user1);
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioLogicExcepcion))]
        public void No_Deberia_Permitir_Agregar_Usuario_Null()
        {
            // Arrange
            Usuario? user1 = null;
            
            //Act
            #pragma warning disable CS8604 // Possible null reference argument.
            _logica.AddUsuario(user1);
            #pragma warning restore CS8604 // Possible null reference argument.
        }

        [TestMethod]
        public void Validar_Contrasena_incorrecta()
        {
            // Arrange
            Usuario user1 = new("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(user1);

            // Act
            bool resultado = _logica.ValidarInicioSesion("User1@user.com", "holaPedroGomez125!");

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioLogicExcepcion))]
        public void Validar_Email_Null()
        {
            // Arrange
            Usuario user1 = new("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(user1);

            // Act
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _logica.ValidarInicioSesion(null, "holaPedroGomez125!");
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioLogicExcepcion))]
        public void Validar_Contrasena_Null()
        {
            // Arrange
            Usuario user1 = new("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(user1);

            // Act
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _logica.ValidarInicioSesion("User1@user.com", null);
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        }

        [TestMethod]
        public void Validar_Contrasena_Correcta()
        {
            // Arrange
            Usuario user1 = new("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(user1);

            // Act
            bool resultado = _logica.ValidarInicioSesion("User1@user.com", "holaPedroGomez123!");

            // Assert
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void Validar_Get_Usuario()
        {
            // Arrange
            Usuario usuario = new("Pedro Gomez", "Hola@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(usuario);

            // Act
            Usuario Encontrado = _logica.GetUsuario(usuario.Email);

            // Assert
            Assert.IsNotNull(Encontrado);
            Assert.AreEqual(usuario, Encontrado);

        }

        [TestMethod]
        [ExpectedException(typeof(UsuarioLogicExcepcion))]
        public void Validar_Get_Usuario_Null()
        {
            // Arrange
            Usuario usuario = new("Pedro Gomez", "Hola@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(usuario);

            // Act
            #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _logica.GetUsuario(null);
            #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.


        }

        [TestMethod]
        public void Retornar_Null_Cuando_No_Se_Encuentra_El_Usuario()
        {
            // Act
            Usuario? Encontrado = _logica.GetUsuario("Usuario@hola.com");

            // Assert
            Assert.IsNull(Encontrado);

        }
    }
}
