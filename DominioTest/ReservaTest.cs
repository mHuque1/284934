using Dominio;
using Excepcion;

namespace DominioTest
{
    [TestClass]
    public class ReservaTest
    {
        private static Deposito deposito = new('A', 'S', false);
        private static Usuario usuario = new("Pedro", "Pedro@gmail.com", "Pedro1234!", true);
        private static Reserva reserva = new(deposito, usuario, DateTime.Today, DateTime.Today.AddDays(1));

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            usuario = new Usuario("Pedro", "Pedro@gmail.com", "Pedro1234!", true);
            deposito = new Deposito('A', 'S', false);
            reserva = new Reserva(deposito, usuario, DateTime.Today, DateTime.Today.AddDays(1));
        }

        [TestMethod]
        public void Deberia_Crear_Una_Reserva()
        {
            // Act
            Assert.IsNotNull(reserva);
        }

        [TestMethod]
        public void Deberia_Obtener_Comienzo()
        {
            // Arrange
            DateTime esperado = DateTime.Today.AddDays(1);

            // Act
            reserva.Comienzo = esperado;
            DateTime obtenido = reserva.Comienzo;

            // Assert
            Assert.AreEqual(esperado, obtenido);
        }

        [TestMethod]
        public void Deberia_Obtener_Fin()
        {
            // Arrange
            DateTime esperado = DateTime.Today;

            // Act
            reserva.Fin = esperado;
            DateTime obtenido = reserva.Fin;

            // Assert
            Assert.AreEqual(esperado, obtenido);
        }

        [TestMethod]
        public void Deberia_Obtener_Confirmacion()
        {
            // Act
            reserva.Aprobar(usuario);

            // Assert
            Assert.IsTrue(reserva.Aprobada);
            Assert.IsFalse(reserva.EnEspera);
        }

        [TestMethod]
        public void Deberia_Rechazar_Confirmacion()
        {
            // Arrange
            string msg = "Reserva rechazada";

            // Act
            reserva.Rechazar(usuario, msg);

            // Assert
            Assert.IsFalse(reserva.Aprobada);
            Assert.IsFalse(reserva.EnEspera);
            Assert.AreEqual(msg, reserva.Mensaje);
        }

        [TestMethod]
        public void Deberia_Obtener_Fecha_Reserva()
        {
            // Arrange
            DateTime esperado = DateTime.Today;

            // Act
            DateTime obtenido = reserva.FechaReserva;

            // Assert
            Assert.AreEqual(esperado, obtenido);
        }

        [TestMethod]
        public void Acepta_Maximo_Mensaje_300_Caracteres()
        {
            // Arrange
            string esperado = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec lobortis nisi vitae lorem auctor tempus. Phasellus vehicula, nunc a mattis sollicitudin, sapien est varius ante, ut efficitur leo dui sodales purus. Phasellus dapibus lacinia eros nec tristique. Vestibulum ut vestibulum elit. Fusce a ex.";
            reserva.Rechazar(usuario, esperado);

            // Act
            string obtenido = reserva.Mensaje;

            // Assert
            Assert.AreEqual(esperado, obtenido);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioReservaExcepcion))]
        public void Excepcion_Mensaje_Largo()
        {
            // Arrange
            string msg = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus massa diam, pharetra et tempor id, elementum eu est. Maecenas eget ex a lorem auctor aliquam. Nunc fringilla suscipit quam ut tristique. Proin vel orci a augue bibendum pulvinar. Proin eget facilisis lorem, vitae vulputate purus biam.";
            reserva.Rechazar(usuario, msg);

            // Act
            reserva.Rechazar(usuario, msg);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioReservaExcepcion))]
        public void Solo_Admin_Puede_Rechazar()
        {
            Usuario user = new("Juan", "Juan@gmail.com", "Juan12345!", false);

            reserva.Rechazar(user, "rechazado");
        }

        [TestMethod]
        [ExpectedException(typeof(DominioReservaExcepcion))]
        public void Solo_Admin_Puede_Aprobar()
        {
            Usuario user = new("Juan", "Juan@gmail.com", "Juan12345!", false);

            reserva.Aprobar(user);
        }

        [TestMethod]
        [DataRow('S', false, 6, 50.0)] // Size = S, Climtatization = false, Days <7, price = 50
        [DataRow('M', false, 6, 75.0)] // Size = M, Climtatization = false, Days <7, price = 75
        [DataRow('L', false, 6, 100.0)] // Size = L, Climtatization = false, Days <7, price = 100
        [DataRow('S', true, 6, 70.0)] // Size = S, Climtatization = true, Days <7, price = 70
        [DataRow('M', true, 6, 95.0)] // Size = M, Climtatization = true, Days <7, price = 95
        [DataRow('L', true, 6, 120.0)] // Size = L, Climtatization = true, Days 7, price = 120
        [DataRow('S', false, 7, 47.5)] // Size = S, Climtatization = false, Days 7, price = 47.5
        [DataRow('M', false, 7, 71.25)] // Size = M, Climtatization = false, Days 7, price = 71.25
        [DataRow('L', false, 7, 95.0)] // Size = L, Climtatization = false, Days 7, price = 95.0
        [DataRow('S', true, 7, 66.5)] // Size = S, Climtatization = true, Days 7, price = 66.5
        [DataRow('M', true, 7, 90.25)] // Size = M, Climtatization = true, Days 7, price = 90.25
        [DataRow('L', true, 7, 114.0)] // Size = L, Climtatization = true, Days 7, price = 114.0
        [DataRow('S', false, 14, 47.5)] // Size = S, Climtatization = false, Days 14, price = 47.5
        [DataRow('M', false, 14, 71.25)] // Size = M, Climtatization = false, Days 14, price = 71.25
        [DataRow('L', false, 14, 95.0)] // Size = L, Climtatization = false, Days 14, price = 95.0
        [DataRow('S', true, 14, 66.5)] // Size = S, Climtatization = true, Days 14, price = 66.5
        [DataRow('M', true, 14, 90.25)] // Size = M, Climtatization = true, Days 14, price = 90.25
        [DataRow('L', true, 14, 114.0)] // Size = L, Climtatization = true, Days 14, price = 114.0
        [DataRow('S', false, 15, 45.0)] // Size = S, Climtatization = false, Days >14, price = 45
        [DataRow('M', false, 15, 67.5)] // Size = M, Climtatization = false, Days >14, price = 67.5
        [DataRow('L', false, 15, 90.0)] // Size = L, Climtatization = false, Days >14, price = 90.0
        [DataRow('S', true, 15, 63.0)] // Size = S, Climtatization = false, Days >14, price = 63.0
        [DataRow('M', true, 15, 85.5)] // Size = M, Climtatization = false, Days >14, price = 85.5
        [DataRow('L', true, 15, 108.0)] // Size = L, Climtatization = false, Days >14, price = 108.0
        public void Calculo_Precio_Sin_Descuento(char Tamano, bool climatization, int days, double expectedPrice)
        {
            // Arrange
            deposito = new Deposito('A', Tamano, climatization);
            reserva = new Reserva(deposito, usuario, DateTime.Today, DateTime.Today.AddDays(days - 1));

            //Act
            double actual = reserva.Costo;

            // Act & Assert
            Assert.AreEqual(expectedPrice, actual);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Con_Promocion()
        {
            // Arrange
            Promocion promo = new("promo", 20, DateTime.Today, DateTime.Today.AddDays(5));
            deposito = new Deposito('A', 'S', false);
            deposito.AgregarPromocion(promo);
            reserva = new Reserva(deposito, usuario, DateTime.Today, DateTime.Today.AddDays(5));
            double costoEsperado = 40.0;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

    }
}
