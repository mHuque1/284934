using Dominio;
using Excepcion;

namespace DominioTest
{
    [TestClass]
    public class ReservaTest
    {
        [TestMethod]
        public void Deberia_Crear_Una_Reserva()
        {
            var reserva = new Reserva();
            Assert.IsNotNull(reserva);
        }

        [TestMethod]
        public void Deberia_Obtener_Comienzo()
        {
            DateTime hoy = DateTime.Today;
            var unaReserva = new Reserva { Comienzo = hoy };
            Assert.AreEqual(hoy, unaReserva.Comienzo);
        }

        [TestMethod]
        public void Deberia_Obtener_Fin()
        {
            DateTime hoy = DateTime.Today;
            var unaReserva = new Reserva { Fin = hoy };
            Assert.AreEqual(hoy, unaReserva.Fin);
        }

        [TestMethod]
        public void Deberia_Obtener_Confirmacion()
        {
            var unaReserva = new Reserva { Aprobada = true };
            Assert.IsTrue(unaReserva.Aprobada);
        }

        [TestMethod]
        public void Reserva_No_Fue_Revisada()
        {
            var unaReserva = new Reserva();
            bool fueRevisada = unaReserva.FueRevisada();
            Assert.IsFalse(fueRevisada);
        }

        [TestMethod]
        public void Reserva_Fue_Revisada_Y_Aprobada()
        {
            var unaReserva = new Reserva { Aprobada = true };
            bool fueRevisada = unaReserva.FueRevisada();
            Assert.IsTrue(fueRevisada);
        }

        [TestMethod]
        public void Reserva_Fue_Revisada_Y_Rechazada()
        {
            var unaReserva = new Reserva { Aprobada = false };
            bool fueRevisada = unaReserva.FueRevisada();
            Assert.IsTrue(fueRevisada);
        }

        [TestMethod]
        public void Acepta_Maximo_Mensaje_300_Caracteres()
        {
            string msg = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec lobortis nisi vitae lorem auctor tempus. Phasellus vehicula, nunc a mattis sollicitudin, sapien est varius ante, ut efficitur leo dui sodales purus. Phasellus dapibus lacinia eros nec tristique. Vestibulum ut vestibulum elit. Fusce a ex.";
            var unaReserva = new Reserva { Mensaje = msg };
            Assert.AreEqual(msg, unaReserva.Mensaje);
        }

        [TestMethod]
        [ExpectedException(typeof(DominioReservaExcepcion))]
        public void Excepcion_Mensaje_Largo()
        {
            string msg = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus massa diam, pharetra et tempor id, elementum eu est. Maecenas eget ex a lorem auctor aliquam. Nunc fringilla suscipit quam ut tristique. Proin vel orci a augue bibendum pulvinar. Proin eget facilisis lorem, vitae vulputate purus biam.";
            var unaReserva = new Reserva { Mensaje = msg };
        }

        [TestMethod]
        public void Deberia_Obtener_Mensaje_Rechazo()
        {
            var unaReserva = new Reserva { Mensaje = "Un mensaje" };
            Assert.AreEqual("Un mensaje", unaReserva.Mensaje);
        }
    }
}