using BusinessLogic;
using Dominio;
using Repositorio;

namespace BusinessLogicTest
{
    [TestClass]
    public class UsuarioLogicTest
    {
        private IRepository<Usuario> _usuarios;

        [TestInitialize]
        public void Inicializar()
        {
            _usuarios = new UsuarioRepository();
        }

        [TestMethod]
        public void Deberia_Crear_Logica_Usuario()
        {
            // Arrange
            UsuarioLogic logica = new UsuarioLogic(_usuarios);

            // Assert
            Assert.IsNotNull(logica);
        }

        [TestMethod]
        public void Deberia_Agregar_Usuario()
        {
            // Arrange
            Usuario usuario = new Usuario
            {
                Email = "Hola@user.com",
                Nombre = "Pedro Gomez",
                Contrasena = "holaPedroGomez123!",
                EsAdmin = false
            };
            UsuarioLogic logica = new UsuarioLogic(_usuarios);

            // Act
            logica.AgregarUsuario(usuario);

            // Assert
            Assert.IsTrue(_usuarios.GetAll().Contains(usuario));
        }

        [TestMethod]
        public void No_Deberia_Agregar_Mas_de_Un_Admin()
        {
            // Arrange
            Usuario admin1 = new Usuario
            {
                Email = "admin1@user.com",
                Nombre = "Pedro Gomez",
                Contrasena = "holaPedroGomez123!",
                EsAdmin = true
            };

            Usuario admin2 = new Usuario
            {
                Email = "admin2@user.com",
                Nombre = "Pedro Gomez",
                Contrasena = "holaPedroGomez123!",
                EsAdmin = true
            };
            UsuarioLogic logica = new UsuarioLogic(_usuarios);

            // Act
            logica.AgregarUsuario(admin1);
            logica.AgregarUsuario(admin2);

            // Assert
            Assert.IsFalse(_usuarios.GetAll().Contains(admin2));
        }

        [TestMethod]
        public void No_Deberia_Permitir_Agregar_Usuario_Con_Igual_Email()
        {
            // Arrange
            Usuario user1 = new Usuario
            {
                Email = "User1@user.com",
                Nombre = "Pedro Gomez",
                Contrasena = "holaPedroGomez123!",
                EsAdmin = false
            };
            UsuarioLogic logica = new UsuarioLogic(_usuarios);

            // Act
            logica.AgregarUsuario(user1);
            logica.AgregarUsuario(user1);

            // Assert
            Assert.AreEqual(1, _usuarios.GetAll().Count());
        }

        [TestMethod]
        public void Validar_Contrasena_incorrecta()
        {
            // Arrange
            Usuario user1 = new Usuario
            {
                Email = "user3@user.com",
                Nombre = "Pedro Gomez",
                Contrasena = "holaPedroGomez123!",
                EsAdmin = false
            };
            UsuarioLogic logica = new UsuarioLogic(_usuarios);
            logica.AgregarUsuario(user1);

            // Act
            bool resultado = logica.ValidarInicioSesion("user3@user.com", "holaPedroGomez125!");

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Validar_Contrasena_Correcta()
        {
            // Arrange
            Usuario user1 = new Usuario
            {
                Email = "user3@user.com",
                Nombre = "Pedro Gomez",
                Contrasena = "holaPedroGomez123!",
                EsAdmin = false
            };
            UsuarioLogic logica = new UsuarioLogic(_usuarios);
            logica.AgregarUsuario(user1);

            // Act
            bool resultado = logica.ValidarInicioSesion("user3@user.com", "holaPedroGomez123!");

            // Assert
            Assert.IsTrue(resultado);
        }
    }
}
