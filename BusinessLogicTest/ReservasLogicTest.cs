using BusinessLogic;
using Dominio;
using Excepcion;
using Repositorio;

namespace BusinessLogicTest
{
    [TestClass]
    public class ReservasLogicTest
    {
        private static readonly Deposito deposito = new('A', 'S', false) { ID = 0 };
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
        public void No_Deberia_Permitir_Agregar_Reserva_Null()
        {
            // Arrange
            ReservasLogic _reservasLogic = new(_repository);

            //Act
            ReservaLogicExcepcion ex = Assert.ThrowsException<ReservaLogicExcepcion>(() => _reservasLogic.AddReserva(null));
           
            //Assert
            Assert.AreEqual("No se puede agregar una reserva null", ex.Message);
        }

        [TestMethod]
        [DataRow(1, 10,1,3)]
        [DataRow(1, 10, 0, 3)]
        public void No_Deberia_Permitir_Agregar_Reserva_Fechas_Superpuestas(int dias1,int dias2,int dias3,int dias4)
        {
            // Arrange
            ReservasLogic _reservasLogic = new(_repository);
            _reservasLogic.AddReserva(new(deposito, usuario, DateTime.Today.AddDays(dias1), DateTime.Today.AddDays(dias2)));

            //Act
            ReservaLogicExcepcion ex = Assert.ThrowsException<ReservaLogicExcepcion>(() => _reservasLogic.AddReserva(new(deposito, usuario, DateTime.Today.AddDays(dias3), DateTime.Today.AddDays(dias4))));
            //Assert
            Assert.AreEqual("La fecha de reserva no se puede superponer con otra reserva", ex.Message);
        }

        [TestMethod]
        public void Deberia_Permitir_Agregar_Reserva_Fechas_Superpuestas_Distinto_tipo()
        {
            // Arrange
            ReservasLogic _reservasLogic = new(_repository);
            Reserva res1 = new(deposito, usuario, DateTime.Today.AddDays(0), DateTime.Today.AddDays(3));
            _reservasLogic.AddReserva(res1);
            Deposito deposito1 = new('A', 'M', false) { ID = 45 };
            Reserva res2 = new(deposito1, usuario, DateTime.Today.AddDays(0), DateTime.Today.AddDays(3));
            
            //Act
            _reservasLogic.AddReserva(res2);
            IList<Reserva> reservas = _reservasLogic.GetReservas();
            //Assert
            Assert.IsTrue(reservas.Contains(res1));
            Assert.IsTrue(reservas.Contains(res2));
        }



        [TestMethod]
        
        public void Verificar_Get_Reservas_Por_Usuario()
        {
            // Arrange
            Usuario usuario1 = new("Usuario1", "Usuario1@gmail.com", "Usuario1234!", false);
            Usuario usuario2 = new("Usuario2", "Usuario2@gmail.com", "Usuario2234!", false);
            ReservasLogic _reservasLogic = new(_repository);
            Deposito deposito2 = new('B', 'M', false) { ID = 1};
            Reserva reserva1 = new(deposito, usuario1, DateTime.Today, DateTime.Today.AddDays(10));
            Reserva reserva2 = new(deposito2, usuario1, DateTime.Today, DateTime.Today.AddDays(10));
            Reserva reserva3 = new(deposito, usuario2, DateTime.Today, DateTime.Today.AddDays(10));
            Reserva reserva4 = new(deposito2, usuario2, DateTime.Today, DateTime.Today.AddDays(10));
            _reservasLogic.AddReserva(reserva1);
            _reservasLogic.AddReserva(reserva2);
            _reservasLogic.AddReserva(reserva3);
            _reservasLogic.AddReserva(reserva4);

            // Act
            IList<Reserva> reservas = _reservasLogic.GetReservasUsuario(usuario1);

            // Assert
            Assert.IsTrue(reservas.Contains(reserva1));
            Assert.IsTrue(reservas.Contains(reserva2));
            Assert.IsFalse(reservas.Contains(reserva3));
            Assert.IsFalse(reservas.Contains(reserva4));
        }

        [TestMethod]
        public void Verificar_Get_Reservas_Por_Usuario_Null()
        {
            //Arrange
            ReservasLogic _reservasLogic = new(_repository);

            //Act
            ReservaLogicExcepcion ex = Assert.ThrowsException<ReservaLogicExcepcion>(() => _reservasLogic.GetReservasUsuario(null));

            //Assert
            Assert.AreEqual("El usuario en getReservasUsuario no puede ser null.", ex.Message);

        }

        [TestMethod]
        public void Verificar_Si_Deposito_Esta_Reservado()
        {
            Deposito depositoA = new('A', 'S', true) { ID = 23 };

            Deposito depositoB = new('B', 'S', true) { ID = 33 };
            Reserva res = new(depositoA, usuario, DateTime.Today, DateTime.Today.AddDays(10));
            ReservasLogic _reservasLogic = new(_repository);
            _reservasLogic.AddReserva(res);

            bool EstaDepositoAReservado = _reservasLogic.TieneDepositoReservas(depositoA.ID);
            bool EstaDepositoBReservado = _reservasLogic.TieneDepositoReservas(depositoB.ID);

            Assert.IsTrue(EstaDepositoAReservado);
            Assert.IsFalse(EstaDepositoBReservado);
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

        [TestMethod]
        public void Verificar_Modificacion_Reserva_Null()
        {
            // Arrange
            ReservasLogic _reservasLogic = new(_repository);
            
            //Act
            ReservaLogicExcepcion ex = Assert.ThrowsException<ReservaLogicExcepcion>(() => _reservasLogic.ModificarReserva(0, null));

            //Assert
            Assert.AreEqual("La reserva en ModifcarReserva no puede ser null", ex.Message);

        }
    }
}
