using BusinessLogic;
using Dominio;
using Excepcion;
using Repositorio;

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
        public void No_Deberia_Agregar_Mas_de_Un_Admin()
        {
            // Arrange
            Usuario admin1 = new("Pedro Gomez", "admin1@user.com", "holaPedroGomez123!", true);
            Usuario admin2 = new("Pedro Gomez", "admin2@user.com", "holaPedroGomez123!", true);

            // Act
            _logica.AddUsuario(admin1);
            UsuarioLogicExcepcion ex = Assert.ThrowsException<UsuarioLogicExcepcion>(() => _logica.AddUsuario(admin2));

            //Assert
            Assert.AreEqual("No se permite agregar un administrador cuando ya existe uno", ex.Message);
        }

        [TestMethod]
        public void No_Deberia_Permitir_Agregar_Usuario_Con_Igual_Email()
        {
            // Arrange
            Usuario user1 = new("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);

            // Act
            _logica.AddUsuario(user1);
            UsuarioLogicExcepcion ex = Assert.ThrowsException<UsuarioLogicExcepcion>(() => _logica.AddUsuario(user1));

            //Assert
            Assert.AreEqual("Ya existe un usuario con el email ingresado", ex.Message);
        }

        [TestMethod]
        public void No_Deberia_Permitir_Agregar_Usuario_Null()
        {
            // Arrange
            Usuario? user1 = null;

            // Act
            UsuarioLogicExcepcion ex = Assert.ThrowsException<UsuarioLogicExcepcion>(() => _logica.AddUsuario(user1));

            //Assert
            Assert.AreEqual("El usuario no puede ser null", ex.Message);
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
        public void Validar_Email_Null()
        {
            // Arrange
            Usuario user1 = new("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(user1);

            // Act
            UsuarioLogicExcepcion ex = Assert.ThrowsException<UsuarioLogicExcepcion>(() => _logica.ValidarInicioSesion(null, "holaPedroGomez125!"));

            //Assert
            Assert.AreEqual("El email no puede ser null", ex.Message);

        }

        [TestMethod]
        public void Validar_Contrasena_Null()
        {
            // Arrange
            Usuario user1 = new("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(user1);

            // Act
            UsuarioLogicExcepcion ex = Assert.ThrowsException<UsuarioLogicExcepcion>(() => _logica.ValidarInicioSesion("User1@user.com", null));

            //Assert
            Assert.AreEqual("La contrase�a no puede ser null", ex.Message);

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
        public void Validar_Get_Usuario_Null()
        {
            // Arrange
            Usuario usuario = new("Pedro Gomez", "Hola@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(usuario);

            // Act
            UsuarioLogicExcepcion ex = Assert.ThrowsException<UsuarioLogicExcepcion>(() => _logica.GetUsuario(null));

            //Assert
            Assert.AreEqual("Se necesita el email para el getUsuario", ex.Message);


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
