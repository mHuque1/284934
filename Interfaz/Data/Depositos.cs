using BusinessLogic;
using Dominio;
using Repositorio;
namespace Interfaz.Data
{
    public class Depositos
    {
        private static readonly DepositoRepository Repositorio = new();
        private readonly DepositoLogic Logica = new(Repositorio);

        public void AddDeposito(Deposito depo, Usuario usuario) => Logica.AddDeposito(depo, usuario);

        public void DeleteDeposito(Deposito depo, Usuario usuario) => Logica.DeleteDeposito(depo, usuario);

        public void BorrarPromocionDepositos(Promocion promo, Usuario usuario) => Logica.BorrarPromocionDepositos(promo,usuario);

        public void ModificarPromocionDepositos(int id,Promocion promo, Usuario usuario) => Logica.ModificarPromocionDepositos(id, promo, usuario);

        public IList<Deposito> ListaDepositos { get => Logica.GetDepositos(); }
    }
}
