using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeAlertas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var alerta = new Alerta(TipoAlerta.INFORMATIVA, tema, fechaExpiracion, false, true);

            //assert
            Assert.AreEqual(TipoAlerta.INFORMATIVA, alerta.Tipo, "Error: El tipo de alerta es incorrecto.");
            Assert.AreEqual(alerta.TemaAsociado, tema, "Error: El tema asociado es incorrecto.");
            Assert.AreEqual(alerta.FechaExpiracion, fechaExpiracion, "Error: La fecha de expiración no coincide.");
            Assert.IsFalse(alerta.Expiro, "Error: El atributo 'expiró' deberia ser false.");
            Assert.IsTrue(alerta.Leido, "Error: El atributo 'leído' debe ser true.");
        }

        [TestMethod()]
        public void AlertaDebeSerExpirada_CuandoFechaExpiracionEsPasada()
        {
            //arrange
            var tema = new Tema("Noticia");
            var alerta = new Alerta(TipoAlerta.INFORMATIVA, tema, DateTime.Now.AddDays(-4), false, true);

            //act
            alerta.esExpirada();

            //assert
            Assert.IsTrue(alerta.Expiro, "Error: El atributo 'Expiró' debería ser True.");

        }

        [TestMethod()]
        public void AlertaDebeSerNoExpirada_CuandoFechaExpiracionEsFutura()
        {
            //arrange
            var tema = new Tema("Noticia");
            var alerta = new Alerta(TipoAlerta.INFORMATIVA, tema, DateTime.Now.AddDays(5), false, true);

            //act
            alerta.esExpirada();

            //assert
            Assert.IsFalse(alerta.Expiro, "Error: El atributo 'Expiró' debería ser False.");

        }
    }
}