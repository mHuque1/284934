using Dominio;
using Repositorio;

namespace RepositorioTest
{
    [TestClass]
    public class UsuarioRepositoryTest
    {
        private IRepository<Usuario> _usuarios;

        [TestInitialize]
        public void Setup()
        {
            _usuarios = new UsuarioRepository();
        }


        [TestMethod]
        public void Deberia_Verificar_Ingreso_De_Usuario()
        {
            // Arrange
            IRepository<Usuario> _usuarios = new UsuarioRepository();
            Usuario usuario = new Usuario
            {
                Nombre = "Juan Gomez",
                Email = "JuanGomez@gmail.com",
                Contrasena = "JuanGomez!1234"
            };

            // Act
            _usuarios.Add(usuario);
            var usuarios = _usuarios.GetAll();

            // Assert
            Assert.IsTrue(usuarios.Contains(usuario));
        }
    

        [TestMethod]
        public void Deberia_Verificar_Baja_De_Usuario()
        {
            // Arrange
            Usuario usuario = new Usuario
            {
                Nombre = "Juan Gomez",
                Email = "JuanGomez@gmail.com",
            };

            // Act
            _usuarios.Add(usuario);
            var usuarios = _usuarios.GetAll();

            // Assert
            Assert.IsTrue(usuarios.Contains(usuario));
        }



        [TestMethod]
        public void Deberia_Actualizar_Usuario()
        {
            // Arrange
            Usuario usuario = new Usuario
            {
                Nombre = "Juan Gomez",
                Email = "JuanGomez@gmail.com",
                Contrasena = "JuanGomez!1234"
            };

            _usuarios.Add(usuario);

            // Act
            usuario.Nombre = "Pedro";
            _usuarios.Update(usuario);
            var usuarioModificado = _usuarios.Find(u => u.Nombre == "Pedro");

            // Assert
            Assert.IsNotNull(usuarioModificado);
            Assert.AreEqual("Pedro", usuarioModificado.Nombre);
        }


    }
}
