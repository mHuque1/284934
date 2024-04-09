using Dominio;
using Excepcion;

namespace DominioTest
{
    [TestClass]
    public class UsuarioTest
    {
        private Usuario usuario;

        [TestInitialize]
        public void Setup()
        {
            usuario = new Usuario
            (
                nombre: "Juan Gomez",
                email: "JuanGomez@gmail.com",
                contrasena: "JuanGomez123!",
                esAdmin: true
            ) ;
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
            Reserva reserva = new Reserva
            (
                id: 1,
                depo: new Deposito(1,'A','S',false),
                comienzo: DateTime.Today,
                fin: DateTime.Today.AddDays(10)
            );

            usuario.AgregarReserva(reserva);

            Assert.AreEqual(1, usuario.Reservas.Count);
            Assert.AreEqual(reserva, usuario.Reservas[0]);
        }

    }
}
