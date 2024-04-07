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
                contrasena: "JuanGomez123!"
            );
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
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Deberia_Lanzar_Excepcion_Si_Nombre_Usuario_Vacio()
        {
            Usuario usuario = new Usuario
            (
                nombre: "Juan Gomez",
                email: "JuanGomez@gmail.com",
                contrasena: "JuanGomez123!"
            );
            usuario.Nombre = "";
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Deberia_Lanzar_Excepcion_Si_Nombre_Usuario_Excede_Limite()
        {
            Usuario usuario = new Usuario
            (
                nombre: "Juan Gomez",
                email: "JuanGomez@gmail.com",
                contrasena: "JuanGomez123!"
            );
            usuario.Nombre = "Valentina Alexandra Beatriz Carolina Daniela Estefanía Florencia Gabriela Helena Isabel Jimena Karina";
        }

        [TestMethod]
        public void Deberia_Obtener_Email()
        {
            var usuario = new Usuario { Email = "nombre@dominio.com" };
            Assert.AreEqual("nombre@dominio.com", usuario.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Deberia_Lanzar_Excepcion_Si_Email_Vacio()
        {
            var usuario = new Usuario { Email = "" };
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Deberia_Lanzar_Excepcion_Si_Formato_Email_No_Valido()
        {
            var usuario = new Usuario { Email = "usuario@asd" };
        }

        [TestMethod]
        public void Deberia_Obtener_Contrasena()
        {
            var usuario = new Usuario { Contrasena = "Contrasena123!" };
            Assert.AreEqual("Contrasena123!", usuario.Contrasena);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Tener_Minimo_Ocho_Caracteres()
        {
            var usuario = new Usuario { Contrasena = "Pass1!" };
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Tener_Un_Simbolo()
        {
            var usuario = new Usuario { Contrasena = "Contrasena123" };
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Contener_Mayuscula()
        {
            var usuario = new Usuario { Contrasena = "contrasena1!" };
        }

        [TestMethod]
        [ExpectedException(typeof(DominioUsuarioExcepcion))]
        public void Contrasena_Deberia_Contener_Minuscula()
        {
            var usuario = new Usuario { Contrasena = "CONTRASENA1!" };
        }

        [TestMethod]
        public void Deberia_Obtener_Las_Reservas_Agregadas()
        {
            var usuario = new Usuario
            {
                Nombre = "Juan Gomez",
                Email = "JuanGomez@gmail.com",
                Contrasena = "JuanGomez!1234"
            };

            var reserva = new Reserva
            {
                Aprobada = true,
                Comienzo = DateTime.Today,
                Fin = DateTime.Today.AddDays(10)
            };

            usuario.AgregarReserva(reserva);

            Assert.AreEqual(1, usuario.Reservas.Count);
            Assert.AreEqual(reserva, usuario.Reservas[0]);
        }
    }
}
