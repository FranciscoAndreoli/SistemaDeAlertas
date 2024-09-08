using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeAlertas.Entidades;

namespace TestSistemaDeAlertas
{
    [TestClass()]
    public class TestTema
    {
        [TestMethod()]
        public void crearTemaCorrectamente()
        {
            //arrange
            var nombre = "Noticias";

            //act
            var tema = new Tema("Noticias");

            //assert
            Assert.AreEqual(nombre, tema.Nombre);
            Assert.IsNotNull(tema.AlertasDelTema, "Error: La lista no debe ser nula.");
            Assert.AreEqual(0, tema.AlertasDelTema.Count, "Error: La lista no debe contener valores.");
            Assert.AreEqual(0, tema.ObservadoresSuscriptos.Count, "Error: La lista no debe contener valores.");

        }

        [TestMethod()]
        public void agregarAlertaATema()
        {
            //arrange
            var tema = new Tema("Notificacion");
            var fechaExpiracionEstimada = DateTime.Now.AddDays(1);

            //act
            tema.agregarAlerta(TipoAlerta.URGENTE, tema, fechaExpiracionEstimada, false, false);
            var alerta = tema.AlertasDelTema[0];

            //assert
            Assert.AreEqual(1, tema.AlertasDelTema.Count, "Error: La lista debe contener un valor.");
            Assert.AreEqual(alerta.Tipo, TipoAlerta.URGENTE, "Error: El tipo de alerta debe ser URGENTE");
            Assert.AreEqual(alerta.TemaAsociado, tema, "Error: Los objetos 'Tema' no coinciden");
            Assert.AreEqual(alerta.FechaExpiracion, fechaExpiracionEstimada, "Error: La fecha de expiración es incorrecta.");
            Assert.IsFalse(alerta.Expiro, "Error: El atributo 'Expiró' debere ser False.");
            Assert.IsFalse(alerta.Leido, "Error: El atributo 'Leído' debere ser False.");
        }

    }
}