using Dominio;
using Repositorio;

namespace RepositorioTest
{
    [TestClass]
    public class ReservasRepositoryTest
    {
        private IRepository<Reserva> _reservasRepository = new ReservasRepository();
        private static Deposito _deposito = new('A', 'S', false) { ID = 1 };
        private static Usuario _usuario = new("Pedro", "Pedro@gmail.com", "Pedro12345!", true);
        private Reserva _reserva = new(_deposito, _usuario, DateTime.Today, DateTime.Today.AddDays(3));


        [TestInitialize]
        public void Setup()
        {
            _reservasRepository = new ReservasRepository();
            _deposito = new('A', 'S', false) { ID = 1 };
            _usuario = new("Pedro", "Pedro@gmail.com", "Pedro12345!", true);
            _reserva = new(_deposito, _usuario, DateTime.Today, DateTime.Today.AddDays(3));
        }

        [TestMethod]
        public void Verifico_Que_Funcione_El_Alta_De_Reservas()
        {
            // Arrange
            _reservasRepository.Add(_reserva);

            // Act
            IList<Reserva> reservas = _reservasRepository.GetAll();

            // Assert
            Assert.IsTrue(reservas.Contains(_reserva));
        }

        [TestMethod]
        public void Verifico_Que_Funcione_La_Baja_De_Reservas()
        {
            // Arrange
            _reservasRepository.Add(_reserva);

            // Act
            _reservasRepository.Delete(_reserva);
            IList<Reserva> reservas = _reservasRepository.GetAll();

            // Assert
            Assert.IsFalse(reservas.Contains(_reserva));
        }

        [TestMethod]
        public void Verifico_Que_Funcione_La_Modificacion_De_Reservas()
        {
            // Arrange
            _reservasRepository.Add(_reserva);
            Deposito nuevoDeposito = new('B', 'S', false) { ID = 2 };
            Usuario nuevoUsuario = new("Jose", "Jose@gmail.com", "Jose12345!", false);
            Reserva reservaModificada = new(nuevoDeposito, nuevoUsuario, DateTime.Today.AddDays(3), DateTime.Today.AddDays(6)) { ID = _reserva.ID };

            // Act
            _reservasRepository.Update(reservaModificada);
            Reserva reservaActualizada = _reservasRepository.Find(u => u.ID == _reserva.ID);

            // Assert
            Assert.IsNotNull(reservaActualizada);
            Assert.AreEqual(nuevoDeposito, reservaActualizada.Deposito);
            Assert.AreEqual(DateTime.Today.AddDays(3), reservaActualizada.Comienzo);
            Assert.AreEqual(DateTime.Today.AddDays(6), reservaActualizada.Fin);
        }
    }
}
