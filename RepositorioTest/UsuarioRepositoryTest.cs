using Dominio;
using Repositorio;

namespace RepositorioTest
{
    [TestClass]
    public class UsuarioRepositoryTest
    {
        private IRepository<Usuario> _usuarios;
        private Usuario usuario;
        [TestInitialize]
        public void Setup()
        {
            usuario = new Usuario("Juan Gomez", "JuanGomez@gmail.com", "JuanGomez!1234", false);
            _usuarios = new UsuarioRepository();
        }


        [TestMethod]
        public void Deberia_Verificar_Ingreso_De_Usuario()
        {
            // Act
            _usuarios.Add(usuario);
            IList<Usuario> usuarios = _usuarios.GetAll();

            // Assert
            Assert.IsTrue(usuarios.Contains(usuario));
        }
    

        [TestMethod]
        public void Deberia_Verificar_Baja_De_Usuario()
        {
            // Arrange
            _usuarios.Add(usuario);

            // Act
            _usuarios.Delete(usuario);
            var usuarios = _usuarios.GetAll();

            // Assert
            Assert.IsFalse(usuarios.Contains(usuario));
        }



        [TestMethod]
        public void Deberia_Actualizar_Usuario()
        {
            // Arrange

            _usuarios.Add(usuario);

            // Act
            usuario.Nombre = "Pedro";
            _usuarios.Update(usuario);
            Usuario usuarioModificado = _usuarios.Find(u => u.Email == "JuanGomez@gmail.com");

            // Assert
            Assert.IsNotNull(usuarioModificado);
            Assert.AreEqual("Pedro", usuarioModificado.Nombre);
        }


    }
}
