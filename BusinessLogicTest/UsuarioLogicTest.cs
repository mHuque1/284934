using BusinessLogic;
using Dominio;
using Repositorio;

namespace BusinessLogicTest
{
    [TestClass]
    public class UsuarioLogicTest
    {
        private IRepository<Usuario> _usuarios;
        private UsuarioLogic _logica;

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
            UsuarioLogic logica = new UsuarioLogic(_usuarios);

            // Assert
            Assert.IsNotNull(logica);
        }

        [TestMethod]
        public void Deberia_Agregar_Usuario()
        {
            // Arrange
            Usuario usuario = new Usuario("Pedro Gomez", "Hola@user.com", "holaPedroGomez123!", false);

            // Act
            _logica.AddUsuario(usuario);

            // Assert
            Assert.IsTrue(_usuarios.GetAll().Contains(usuario));
        }

        [TestMethod]
        public void No_Deberia_Agregar_Mas_de_Un_Admin()
        {
            // Arrange
            Usuario admin1 = new Usuario("Pedro Gomez", "admin1@user.com", "holaPedroGomez123!", true);
            Usuario admin2 = new Usuario("Pedro Gomez", "admin2@user.com", "holaPedroGomez123!", true);

            // Act
            _logica.AddUsuario(admin1);
            _logica.AddUsuario(admin2);

            // Assert
            Assert.IsFalse(_usuarios.GetAll().Contains(admin2));
        }

        [TestMethod]
        public void No_Deberia_Permitir_Agregar_Usuario_Con_Igual_Email()
        {
            // Arrange
            Usuario user1 = new Usuario("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);

            // Act
            _logica.AddUsuario(user1);
            _logica.AddUsuario(user1);

            // Assert
            Assert.AreEqual(1, _usuarios.GetAll().Count);
        }

        [TestMethod]
        public void Validar_Contrasena_incorrecta()
        {
            // Arrange
            Usuario user1 = new Usuario("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(user1);

            // Act
            bool resultado = _logica.ValidarInicioSesion("User1@user.com", "holaPedroGomez125!");

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Validar_Contrasena_Correcta()
        {
            // Arrange
            Usuario user1 = new Usuario("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);
            _logica.AddUsuario(user1);

            // Act
            bool resultado = _logica.ValidarInicioSesion("User1@user.com", "holaPedroGomez123!");

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Alta_De_Reserva_Correcta()
        {
            // Arrange
            Usuario user1 = new Usuario("Pedro Gomez", "User1@user.com", "holaPedroGomez123!", false);
            Deposito deposito = new Deposito(1, 'A', 'S', false);
            Reserva reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(1));

            _logica.AddUsuario(user1);
            _logica.AddReservaUsuario(reserva, user1);

            // Act
            IList<Reserva> reservas = _logica.GetReservasUsuario(user1);

            // Assert
            Assert.IsTrue(reservas.Contains(reserva));
        }
    }
}
