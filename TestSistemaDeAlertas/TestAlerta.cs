using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeAlertas.Entidades;

namespace TestSistemaDeAlertas
{
    [TestClass()]
    public class TestAlerta
    {
        [TestMethod()]
        public void CrearAlerta()
        {
            //arrange
            var tema = new Tema("Notificacion");
            var fechaExpiracion = DateTime.Now.AddDays(3);

            //act
            var alerta = new Alerta(TipoAlerta.INFORMATIVA, tema, fechaExpiracion, false, true, false);

            //assert
            Assert.AreEqual(TipoAlerta.INFORMATIVA, alerta.Tipo, "Error: El tipo de alerta es incorrecto.");
            Assert.AreEqual(alerta.TemaAsociado, tema, "Error: El tema asociado es incorrecto.");
            Assert.AreEqual(alerta.FechaExpiracion, fechaExpiracion, "Error: La fecha de expiración no coincide.");
            Assert.IsFalse(alerta.haExpirado(), "Error: El atributo 'expiró' deberia ser false.");
            Assert.IsTrue(alerta.Leido, "Error: El atributo 'leído' debe ser true.");
            Assert.IsFalse(alerta.haExpirado(), "Error: El atributo 'esParaTodos' deberia ser false.");
        }

        [TestMethod()]
        public void AlertaDebeSerExpirada()
        {
            //arrange
            var tema = new Tema("Noticia");
            var alerta = new Alerta(TipoAlerta.INFORMATIVA, tema, DateTime.Now.AddDays(-4), false, true, false);

            //act
            if (alerta.haExpirado())
            {
                alerta.marcarComoExpirada();
            }

            //assert
            Assert.IsTrue(alerta.haExpirado(), "Error: El atributo 'Expiró' debería ser True.");
        }

        [TestMethod()]
        public void AlertaDebeSerNoExpirada()
        {
            //arrange
            var tema = new Tema("Noticia");
            var alerta = new Alerta(TipoAlerta.INFORMATIVA, tema, DateTime.Now.AddDays(5), false, true, false);

            //act
            if (alerta.haExpirado())
            {
                alerta.marcarComoExpirada();
            }

            //assert
            Assert.IsFalse(alerta.haExpirado(), "Error: El atributo 'Expiró' debería ser False.");
        }
    }
}