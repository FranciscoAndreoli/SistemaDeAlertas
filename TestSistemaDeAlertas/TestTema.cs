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
            var tema = new Tema(nombre);

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
            tema.agregarAlerta(TipoAlerta.URGENTE, tema, fechaExpiracionEstimada, false, false, true);
            var alerta = tema.AlertasDelTema[0];

            //assert
            Assert.AreEqual(1, tema.AlertasDelTema.Count, "Error: La lista debe contener un valor.");
            Assert.AreEqual(alerta.Tipo, TipoAlerta.URGENTE, "Error: El tipo de alerta debe ser URGENTE");
            Assert.AreEqual(alerta.TemaAsociado, tema, "Error: Los objetos 'Tema' no coinciden");
            Assert.AreEqual(alerta.FechaExpiracion, fechaExpiracionEstimada, "Error: La fecha de expiración es incorrecta.");
            Assert.IsFalse(alerta.haExpirado(), "Error: El atributo 'Expiró' debe ser False.");
            Assert.IsFalse(alerta.Leido, "Error: El atributo 'Leído' debe ser False.");
            Assert.IsTrue(alerta.EsParaTodos, "Error: El atributo 'esParaTodos' debe ser True.");
        }

        [TestMethod()]
        public void suscribirUsuarioATema()
        {
            //arrange
            var tema = new Tema("Noticias");
            var usuario = new Usuario("Fran");

            //act
            tema.suscribirUsuario(usuario);

            //assert
            Assert.AreEqual(1, tema.ObservadoresSuscriptos.Count, "Error: La lista de observadores debe tener un usuario.");
            Assert.IsTrue(tema.ObservadoresSuscriptos.Contains(usuario), "Error: El usuario no está suscrito al tema.");
        }

        [TestMethod()]
        public void desuscribirUsuarioDeTema()
        {
            //arrange
            var tema = new Tema("Noticias");
            var usuario = new Usuario("Fran");
            tema.suscribirUsuario(usuario);

            //act
            tema.desuscribirUsuario(usuario);

            //assert
            Assert.AreEqual(0, tema.ObservadoresSuscriptos.Count, "Error: El usuario debe ser removido de la lista de suscriptores.");
            Assert.IsFalse(tema.ObservadoresSuscriptos.Contains(usuario), "Error: El usuario sigue suscrito al tema.");
        }

        [TestMethod()]
        public void obtenerAlertasNoExpiradas()
        {
            //arrange
            var tema = new Tema("Noticias");
            var fechaFutura = DateTime.Now.AddDays(1);
            var fechaPasada = DateTime.Now.AddDays(-1);
            tema.agregarAlerta(TipoAlerta.INFORMATIVA, tema, fechaFutura, false, false, true);
            tema.agregarAlerta(TipoAlerta.URGENTE, tema, fechaPasada, false, false, true);

            //act
            var alertasNoExpiradas = tema.obtenerAlertasNoExpiradas();

            //assert
            Assert.AreEqual(1, alertasNoExpiradas.Count, "Error: Debe haber solo una alerta no expirada.");
            Assert.AreEqual(TipoAlerta.INFORMATIVA, alertasNoExpiradas[0].Tipo, "Error: La alerta no expirada debe ser INFORMATIVA.");
        }

        [TestMethod()]
        public void notificarUsuarios()
        {
            //arrange
            var tema = new Tema("Noticias");
            var usuario1 = new Usuario("Fran");
            var usuario2 = new Usuario("Ana");
            tema.suscribirUsuario(usuario1);
            tema.suscribirUsuario(usuario2);
            var alerta = new Alerta(TipoAlerta.URGENTE, tema, DateTime.Now.AddDays(1), false, false, true);

            tema.agregarAlerta(alerta.Tipo, alerta.TemaAsociado, alerta.FechaExpiracion, alerta.Expiro, alerta.Leido, true);

            //act
            tema.notificarUsuarios();

            //assert
            Assert.AreEqual(1, usuario1.AlertasDelUsuario.Count, "Error: El usuario 1 debe recibir una alerta.");
            Assert.AreEqual(1, usuario2.AlertasDelUsuario.Count, "Error: El usuario 2 debe recibir una alerta.");
            Assert.AreEqual(alerta.Tipo, usuario1.AlertasDelUsuario[0].Tipo, "Error: La alerta del usuario 1 no coincide.");
            Assert.AreEqual(alerta.Tipo, usuario2.AlertasDelUsuario[0].Tipo, "Error: La alerta del usuario 2 no coincide.");
        }

        [TestMethod()]
        public void notificarUsuarioEspecifico()
        {
            //arrange
            var tema = new Tema("Noticias");
            var usuario1 = new Usuario("Fran");
            var usuario2 = new Usuario("Ana");
            usuario1.suscribirseATema(tema);
            usuario2.suscribirseATema(tema);
            var alertaParaFran = new Alerta(TipoAlerta.URGENTE, tema, DateTime.Now.AddDays(1), false, false, false, usuario1);

            //act
            tema.agregarAlerta(alertaParaFran.Tipo, alertaParaFran.TemaAsociado, alertaParaFran.FechaExpiracion, alertaParaFran.Expiro, alertaParaFran.Leido, alertaParaFran.EsParaTodos, alertaParaFran.UsuarioEspecifico);
            tema.notificarUsuarios();

            //assert
            Assert.AreEqual(1, usuario1.AlertasDelUsuario.Count, "Error: Fran debe recibir la alerta.");
            Assert.AreEqual(alertaParaFran.Tipo, usuario1.AlertasDelUsuario[0].Tipo, "Error: La alerta no coincide con la esperada.");

            Assert.AreEqual(0, usuario2.AlertasDelUsuario.Count, "Error: Ana no debe recibir ninguna alerta.");
        }

    }
}