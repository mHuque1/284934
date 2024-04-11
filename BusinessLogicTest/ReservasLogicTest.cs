using BusinessLogic;
using Dominio;
using Repositorio;

namespace BusinessLogicTest
{
    [TestClass]
    public class ReservasLogicTest
    {
        private static readonly Deposito deposito = new('A', 'S', false);
        private static readonly Usuario usuario = new("Pedro Gomez", "pedrogomez@gmail.com", "Pedrogomez1234!", true);
        private readonly Reserva reserva = new(deposito, usuario, DateTime.Today, DateTime.Today.AddDays(10));
        private ReservasRepository _repository = new();

        [TestInitialize]
        public void Setup()
        {
            _repository = new ReservasRepository();
        }

        [TestMethod]
        public void Deberia_No_Ser_Null()
        {
            ReservasLogic _reservasLogic = new(_repository);

            Assert.IsNotNull(_reservasLogic);
        }

        [TestMethod]
        public void Verificar_Alta_De_Reserva()
        {
            // Arrange
            ReservasLogic _reservasLogic = new(_repository);
            _reservasLogic.AddReserva(reserva);

            // Act
            IList<Reserva> reservas = _reservasLogic.GetReservas();

            // Assert
            Assert.IsTrue(reservas.Contains(reserva));
        }

        [TestMethod]
        public void Verificar_Baja_De_Reserva()
        {
            // Arrange
            ReservasLogic _reservasLogic = new(_repository);
            _reservasLogic.AddReserva(reserva);

            // Act
            _reservasLogic.DeleteReserva(0);

            // Assert
            Assert.IsFalse(_reservasLogic.GetReservas().Contains(reserva));
        }

        [TestMethod]
        public void Verificar_Modificacion_Reserva()
        {
            // Arrange
            ReservasLogic _reservasLogic = new(_repository);
            _reservasLogic.AddReserva(reserva);
            reserva.Aprobar(usuario);

            // Act
            _reservasLogic.ModificarReserva(0, reserva);
            Reserva res = _reservasLogic.GetReserva(0);

            // Assert
            Assert.IsTrue(res.Aprobada);
        }
    }
}
