using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeAlertas.Entidades;

namespace TestSistemaDeAlertas
{
    [TestClass()]
    public class TestUsuario
    {
        [TestMethod()]
        public void CrearUsuario()
        {
            //arrange
            string nombreEsperado = "Fran";

            //act
            var usuario = new Usuario("Fran");

            //assert
            Assert.AreEqual(nombreEsperado, usuario.Nombre);
            Assert.IsNotNull(usuario.AlertasDelUsuario, "Error: La lista no debe ser nula.");
            Assert.AreEqual(0, usuario.AlertasDelUsuario.Count, "Error: La lista no debe contener valores.");
        }
    }
}