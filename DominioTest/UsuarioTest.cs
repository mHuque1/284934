using Dominio;
using Excepcion;

namespace DominioTest
{
    [TestClass]
    public class UsuarioTest
    {
        private Usuario usuario = new("Juan Gomez", "JuanGomez@gmail.com", "JuanGomez123!", false);

        [TestInitialize]
        public void Setup()
        {
            usuario = new("Juan Gomez", "JuanGomez@gmail.com", "JuanGomez123!", true);
        }

        [TestMethod]
        public void Deberia_Crear_Nuevo_Usuario()
        {
            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        public void Deberia_Obtener_Nombre()
        {
            Assert.AreEqual("Juan Gomez", usuario.Nombre);
        }

        [TestMethod]
        public void Deberia_Obtener_Si_Es_Admin()
        {
            usuario.EsAdmin = true;


            Assert.IsTrue(usuario.EsAdmin);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Deberia_Lanzar_Excepcion_Si_Nombre_Usuario_Vacio()
        {
            usuario.Nombre = "";
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Deberia_Lanzar_Excepcion_Si_Nombre_Usuario_Excede_Limite()
        {
            usuario.Nombre = "Valentina Alexandra Beatriz Carolina Daniela Estefanía Florencia Gabriela Helena Isabel Jimena Karina";
        }

        [TestMethod]
        public void Deberia_Obtener_Email()
        {
            Assert.AreEqual("JuanGomez@gmail.com", usuario.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Deberia_Lanzar_Excepcion_Si_Email_Vacio()
        {
            usuario.Email = "";
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Deberia_Lanzar_Excepcion_Si_Formato_Email_No_Valido()
        {
            usuario.Email = "usuario@Dominio";
        }

        [TestMethod]
        public void Deberia_Obtener_Contrasena()
        {
            Assert.AreEqual("JuanGomez123!", usuario.Contrasena);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Tener_Minimo_Ocho_Caracteres()
        {
            usuario.Contrasena = "Pass1!";
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Tener_Un_Simbolo()
        {
            usuario.Contrasena = "Contrasena123";
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Contener_Mayuscula()
        {
            usuario.Contrasena = "contrasena1!";
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Contener_Minuscula()
        {
            usuario.Contrasena = "CONTRASENA1!";
        }

        [TestMethod]
        public void Deberia_Obtener_Las_Reservas_Agregadas()
        {
            //Arrange
            Deposito deposito = new('A', 'S', false);
            Usuario usuario = new("Pedro", "pedro@gmail.com", "Pedro12345!", false);
            Reserva reserva = new(deposito, usuario, DateTime.Today, DateTime.Today.AddDays(10));

            //Act
            usuario.AgregarReserva(reserva);

            //Assert
            Assert.AreEqual(1, usuario.Reservas.Count);
            Assert.AreEqual(reserva, usuario.Reservas[0]);
        }

    }
}
