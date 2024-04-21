using BusinessLogic;
using Dominio;
using Repositorio;
using System.Net;
namespace Interfaz.Data
{
    public class Depositos
    {
        private static readonly DepositoRepository Repositorio = new();
        private DepositoLogic Logica = new(Repositorio);

        public void AddDeposito(Deposito depo, Usuario usuario) => Logica.AddDeposito(depo, usuario);

        public void DeleteDeposito(Deposito depo, Usuario usuario) => Logica.DeleteDeposito(depo, usuario);

        public IList<Deposito> ListaDepositos { get => Logica.GetDepositos();}
    }
}
