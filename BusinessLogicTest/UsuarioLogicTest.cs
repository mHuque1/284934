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
            // Arrange
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
            Usuario user1 = new Usuario
            {
                Email = "User1@user.com",
                Nombre = "Pedro Gomez",
                Contrasena = "holaPedroGomez123!",
                EsAdmin = false
            };


            // Act
            _logica.AddUsuario(user1);
            _logica.AddUsuario(user1);

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

            _logica.AddUsuario(user1);

            // Act
            bool resultado = _logica.ValidarInicioSesion("user3@user.com", "holaPedroGomez125!");

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
            _logica.AddUsuario(user1);

            // Act
            bool resultado = _logica.ValidarInicioSesion("user3@user.com", "holaPedroGomez123!");

            // Assert
            Assert.IsTrue(resultado);
        }

        


           

    }

        [TestMethod]
        public void Alta_De_Reserva_Correcta()
        {
            Usuario user1 = new Usuario
            {
                Email = "user3@user.com",
                Nombre = "Pedro Gomez",
                Contrasena = "holaPedroGomez123!",
                EsAdmin = false
            };

            Deposito deposito = new Deposito
            {
                id = 1,
                Area = 'A',
                Tamano = 'S',
                Climatizacion = true
            };

            Reserva reserva = new Reserva {
                id = 1,
                Comienzo = DateTime.Today,
                Fin = DateTime.Today.AddDays(1),
                Depo = deposito
            };

            _logica.AddUsuario(user1);
            _logica.AddReservaUsuario(reserva, user1);


            IList<Reserva> Reservas = _logica.GetReservasUsuario(user1);

            Assert.IsTrue(Reservas.Contains(reserva));









        }
    }
}