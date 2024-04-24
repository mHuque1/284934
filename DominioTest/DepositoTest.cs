using Dominio;
using Excepcion;

namespace DominioTest
{
    [TestClass]
    public class DepositoTest
    {
        private Deposito deposito;

        [TestInitialize]
        public void Setup()
        {
            // Arrange: Configuración inicial para cada prueba
            deposito = new Deposito(area: 'A', tamano: 'S', tieneClimatizacion: false);
        }

        [TestMethod]
        public void Deberia_Crear_Un_Deposito()
        {
            // Act: Ejecutar la acción que se quiere probar
            // Assert: Verificar que se haya realizado la acción correctamente
            Assert.IsNotNull(deposito);
        }

        [TestMethod]
        public void Deberia_Obtener_Area()
        {
            // Arrange
            char areaEsperada = 'A';

            // Act
            char areaObtenida = deposito.Area;

            // Assert
            Assert.AreEqual(areaEsperada, areaObtenida);
        }

        [TestMethod]
        public void Deberia_Aceptar_Areas_Validas()
        {
            // Arrange
            char[] areasValidas = { 'A', 'B', 'C', 'D', 'E' };

            // Act & Assert
            foreach (char area in areasValidas)
            {
                deposito.Area = area;
            }

            Assert.IsTrue(true); // Si no se lanzó ninguna excepción hasta aquí, la prueba pasa
        }

        [TestMethod]
        public void Deberia_No_Aceptar_Areas_Invalidas()
        {

            //Act
            DominioDepositoExcepcion ex = Assert.ThrowsException<DominioDepositoExcepcion>(() => deposito.Area = 'H');
            //Assert
            Assert.AreEqual($"El área H no es válida", ex.Message);
        }

        [TestMethod]
        public void Deberia_Obtener_Tamano()
        {
            // Arrange
            char tamanoEsperado = 'S';

            // Act
            char tamanoObtenido = deposito.Tamano;

            // Assert
            Assert.AreEqual(tamanoEsperado, tamanoObtenido);
        }

        [TestMethod]
        public void No_Deberia_Obtener_Tamano()
        {
            //Act
            DominioDepositoExcepcion ex = Assert.ThrowsException<DominioDepositoExcepcion>(() => deposito.Tamano = 'K');
            //Assert
            Assert.AreEqual($"El Tamaño K no es válido", ex.Message);
        }

        [TestMethod]
        public void Deberia_Aceptar_Tamanos_Validos()
        {
            // Arrange
            char[] tamanosValidos = { 'S', 'M', 'L' };

            // Act & Assert
            foreach (char tamano in tamanosValidos)
            {
                deposito.Tamano = tamano;
            }

            Assert.IsTrue(true); // Si no se lanzó ninguna excepción hasta aquí, la prueba pasa
        }

        [TestMethod]
        public void Deberia_Obtener_Climatizacion()
        {
            // Arrange
            bool esperado = true;

            // Act
            deposito.TieneClimatizacion = esperado;
            bool obtenido = deposito.TieneClimatizacion;

            // Assert
            Assert.AreEqual(esperado, obtenido);
        }

        [TestMethod]
        public void Deberia_Tener_Las_Promociones_Agregadas()
        {
            // Arrange
            var promocion = new Promocion(etiqueta: "Promo", descuento: 10, comienzo: DateTime.Today, fin: DateTime.Today.AddDays(1));

            // Act
            deposito.AgregarPromocion(promocion);

            // Assert
            Assert.AreEqual(1, deposito.Promociones.Count);
            Assert.AreEqual(promocion, deposito.Promociones[0]);
        }

        [TestMethod]
        public void Deberia_Borrar_Promocion()
        {
            //Arrange
            var promocion = new Promocion(etiqueta: "Promo", descuento: 10, comienzo: DateTime.Today, fin: DateTime.Today.AddDays(1));
            deposito.AgregarPromocion(promocion);

            // Act
            deposito.BorrarPromocion(promocion);

            //Assert
            Assert.IsFalse(deposito.Promociones.Contains(promocion));
        }

        [TestMethod]
        public void Deberia_Modificar_Promocion()
        {
            //Arrange
            Promocion promocion = new("promo", 10, DateTime.Today, DateTime.Today.AddDays(1)) { Id=0};
            deposito.AgregarPromocion(promocion);
            Promocion promocionActualizada = new("asd", 18, DateTime.Today.AddDays(15), DateTime.Today.AddDays(20)) { Id = 0 };
            
            //Act
            deposito.ActualizarPromocion(0,promocionActualizada);
            Promocion obtenida = deposito.Promociones[0];
            
            //Assert
            Assert.AreEqual("asd",obtenida.Etiqueta);
            Assert.AreEqual(18,obtenida.Descuento);
            Assert.AreEqual(DateTime.Today.AddDays(15), obtenida.Comienzo);
            Assert.AreEqual(DateTime.Today.AddDays(20), obtenida.Fin);
        }
    }
}
