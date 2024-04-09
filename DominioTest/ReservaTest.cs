using Dominio;
using Excepcion;

namespace DominioTest
{
    [TestClass]
    public class ReservaTest
    {
        private Deposito deposito;
        private Reserva reserva;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'S', false);
            reserva = new Reserva(1,deposito, DateTime.Today, DateTime.Today.AddDays(1));
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
            // Arrange
            bool confirmacion = true;

            // Act
            reserva.Aprobada = confirmacion;

            // Assert
            Assert.IsTrue(reserva.Aprobada);
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
        public void Reserva_Esta_en_espera()
        {
            // Arrange
            reserva.EnEspera = true;

            // Assert
            Assert.IsTrue(reserva.EnEspera);
        }

        [TestMethod]
        public void Acepta_Maximo_Mensaje_300_Caracteres()
        {
            // Arrange
            string esperado = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec lobortis nisi vitae lorem auctor tempus. Phasellus vehicula, nunc a mattis sollicitudin, sapien est varius ante, ut efficitur leo dui sodales purus. Phasellus dapibus lacinia eros nec tristique. Vestibulum ut vestibulum elit. Fusce a ex.";

            // Act
            reserva.Mensaje = esperado;
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

            // Act
            reserva.Mensaje = msg;
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_1()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'S', false);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(1));
            double costoEsperado = 50.0;

            // Act & Assert
            Assert.AreEqual(reserva.Costo, costoEsperado);

        }

        [TestMethod]
        public void Calculo_Precio_Deposito_2()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'M', false);
            reserva = new Reserva(1,deposito, DateTime.Today, DateTime.Today.AddDays(1));
            double costoEsperado = 75.0;

            // Act & Assert
            Assert.AreEqual(reserva.Costo, costoEsperado);

        }

        [TestMethod]
        public void Calculo_Precio_Deposito_3()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'L', false);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(1));
            double costoEsperado = 100.0;

            // Act & Assert
            Assert.AreEqual(costoEsperado,reserva.Costo);

        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Climatizado_1()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'S', true);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(5));
            double costoEsperado = 70.0;

            // Act & Assert
            Assert.AreEqual(costoEsperado,reserva.Costo);

        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Climatizado_2()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'M', true);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(5));
            double costoEsperado = 95.0;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);

        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Climatizado_3()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'L', true);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(5));
            double costoEsperado = 120.0;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }


        [TestMethod]
        public void Calculo_Precio_Deposito_Sin_Climatizacion_Una_Semana_1()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'S', false);
            reserva = new Reserva(1,deposito, DateTime.Today, DateTime.Today.AddDays(6));
            double costoEsperado = 47.5;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Sin_Climatizacion_Una_Semana_2()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'M', false);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(6));
            double costoEsperado = 71.25;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Sin_Climatizacion_Una_Semana_3()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'L', false);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(6));
            double costoEsperado = 95.0;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Con_Climatizacion_Una_Semana_1()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'S', true);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(6));
            double costoEsperado = 66.5;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Con_Climatizacion_Una_Semana_2()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'M', true);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(6));
            double costoEsperado = 90.25;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Con_Climatizacion_Una_Semana_3()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'L', true);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(6));
            double costoEsperado = 114.0;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Sin_Climatizacion_Tres_Semanas_1()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'S', false);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(20));
            double costoEsperado = 45;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Sin_Climatizacion_Tres_Semanas_2()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'M', false);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(20));
            double costoEsperado = 67.5;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Sin_Climatizacion_Tres_Semanas_3()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'L', false);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(20));
            double costoEsperado = 90.0;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Con_Climatizacion_Tres_Semanas_1()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'S', true);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(20));
            double costoEsperado = 63.0;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }


        [TestMethod]
        public void Calculo_Precio_Deposito_Con_Climatizacion_Tres_Semanas_2()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'M', true);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(20));
            double costoEsperado = 85.5;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Con_Climatizacion_Tres_Semanas_3()
        {
            // Arrange
            deposito = new Deposito(1, 'A', 'L', true);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(20));
            double costoEsperado = 108.0;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

        [TestMethod]
        public void Calculo_Precio_Deposito_Con_Promocion()
        {
            // Arrange
            Promocion promo = new Promocion(1,"promo",20,DateTime.Today,DateTime.Today.AddDays(5));
            deposito = new Deposito(1, 'A', 'S', false);
            deposito.AgregarPromocion(promo);
            reserva = new Reserva(1, deposito, DateTime.Today, DateTime.Today.AddDays(5));
            double costoEsperado = 40.0;

            // Act & Assert
            Assert.AreEqual(costoEsperado, reserva.Costo);
        }

    }
}
