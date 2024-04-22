using BusinessLogic;
using Dominio;
using Repositorio;
namespace Interfaz.Data
{
    public class Reservas
    {
        private static readonly ReservasRepository Repositorio = new();
        private readonly ReservasLogic Logica = new(Repositorio);

        public IList<Reserva> ReservaList { get => Logica.GetReservas(); }

        public IList<Reserva> GetReservasUsuario(Usuario usuario) => Logica.GetReservasUsuario(usuario);

        public void AprobarReserva(Reserva reserva, Usuario user)
        {
            reserva.Aprobar(user);
            Logica.ModificarReserva(reserva.ID, reserva);
        }

        public void AddReserva(Reserva res) => Logica.AddReserva(res);

        public void RechazarReserva(Reserva reserva, Usuario user, string msg)
        {
            reserva.Rechazar(user, msg);
            Logica.ModificarReserva(reserva.ID, reserva);
        }
    }
}
