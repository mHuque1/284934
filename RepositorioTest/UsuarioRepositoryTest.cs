using Dominio;
using Repositorio;

namespace RepositorioTest
{
    [TestClass]
    public class UsuarioRepositoryTest
    {
        private IRepository<Usuario> _usuarios = new UsuarioRepository();
        private readonly Usuario usuario = new("Juan Gomez", "JuanGomez@gmail.com", "JuanGomez!1234", false);

        [TestInitialize]
        public void Setup()
        {
            _usuarios = new UsuarioRepository();
        }

        [TestMethod]
        public void Verifico_Que_Funcione_El_Alta_De_Usuarios()
        {
            // Act
            _usuarios.Add(usuario);
            IList<Usuario> usuarios = _usuarios.GetAll();

            // Assert
            Assert.IsTrue(usuarios.Contains(usuario));
        }

        [TestMethod]
        public void Verifico_Que_Funcione_La_Baja_De_Usuarios()
        {
            // Arrange
            _usuarios.Add(usuario);

            // Act
            _usuarios.Delete(usuario);
            IList<Usuario> usuarios = _usuarios.GetAll();

            // Assert
            Assert.IsFalse(usuarios.Contains(usuario));
        }

        [TestMethod]
        public void Verifico_Que_Funcione_La_Modificacion_De_Reservas()
        {
            // Arrange
            _usuarios.Add(usuario);

            // Act
            Usuario usuarioModificado = new("Pedro Rodriguez", "JuanGomez@gmail.com", "Rodriguez!1234", true);
            _usuarios.Update(usuarioModificado);
            Usuario usuarioActualizado = _usuarios.Find(u => u.Email == "JuanGomez@gmail.com");

            // Assert
            Assert.IsNotNull(usuarioActualizado);
            Assert.AreEqual("Pedro Rodriguez", usuarioActualizado.Nombre);
            Assert.AreEqual("Rodriguez!1234", usuarioActualizado.Contrasena);
            Assert.IsTrue(usuarioActualizado.EsAdmin);
        }
    }
}
