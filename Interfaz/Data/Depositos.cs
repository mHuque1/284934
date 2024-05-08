using BusinessLogic;
using Dominio;
using Repositorio;
namespace Interfaz.Data
{
    public class Depositos
    {
        private static readonly DepositoRepository Repositorio = new();
        private readonly DepositoLogic Logica = new(Repositorio);

        public bool AddDeposito(char area, char tamano, bool climatizacion, IList<Promocion> promos, Usuario usuario)
        {
            try
            {
                Deposito depo = new(area, tamano, climatizacion);

                Logica.AddDeposito(depo, usuario);
                foreach (Promocion promo in promos)
                {
                    depo.AgregarPromocion(promo);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public void DeleteDeposito(Deposito depo, Usuario usuario)
        {
            try
            {
                Logica.DeleteDeposito(depo, usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void BorrarPromocionDepositos(Promocion promo, Usuario usuario)
        {
            try
            {
                Logica.BorrarPromocionDepositos(promo, usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void ModificarPromocionDepositos(int id, Promocion promo, Usuario usuario)
        {
            try
            {
                Logica.ModificarPromocionDepositos(id, promo, usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public IList<Deposito> ListaDepositos { get => Logica.GetDepositos(); }
    }
}
