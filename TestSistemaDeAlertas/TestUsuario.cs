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

        [TestMethod()]
        public void UsuarioDebeSuscribirseATema()
        {
            //arrange
            var usuario = new Usuario("Fran");
            var tema = new Tema("Noticias");

            //act
            usuario.suscribirseATema(tema);

            //assert
            Assert.IsTrue(tema.ObtenerObservadoresSuscriptos().Contains(usuario), "Error: El usuario no fue suscrito al tema correctamente.");
        }

        [TestMethod()]
        public void UsuarioDebeRecibirAlerta()
        {
            //arrange
            var usuario = new Usuario("Fran");
            var alerta = new Alerta(TipoAlerta.INFORMATIVA, new Tema("Noticias"), DateTime.Now, false, false, true);

            //act
            usuario.recibirAlerta(alerta);

            //assert
            Assert.AreEqual(1, usuario.AlertasDelUsuario.Count, "Error: La lista de alertas debería tener una alerta.");
            Assert.AreEqual(alerta, usuario.AlertasDelUsuario[0], "Error: La alerta recibida no es correcta.");
        }

        [TestMethod()]
        public void MarcarPrimeraAlertaNoLeidaComoLeida()
        {
            //arrange
            var usuario = new Usuario("Fran");
            var alertaNoLeida = new Alerta(TipoAlerta.INFORMATIVA, new Tema("Noticias"), DateTime.Now.AddDays(1), false, false, true);
            var alertaLeida = new Alerta(TipoAlerta.URGENTE, new Tema("Noticias"), DateTime.Now.AddDays(1), false, true, true);

            usuario.recibirAlerta(alertaNoLeida);
            usuario.recibirAlerta(alertaLeida);

            //act
            usuario.marcarPrimeraAlertaNoLeidaComoLeida();

            //assert
            Assert.IsTrue(alertaNoLeida.Leido, "Error: La primera alerta no leída debería estar marcada como leída.");
        }

        [TestMethod()]
        public void ObtenerAlertasNoLeidasNoExpiradas()
        {
            //arrange
            var usuario = new Usuario("Fran");
            var alertaNoLeidaNoExpirada = new Alerta(TipoAlerta.INFORMATIVA, new Tema("Noticias"), DateTime.Now.AddDays(1), false, false, true);
            var alertaNoLeidaExpirada = new Alerta(TipoAlerta.URGENTE, new Tema("Noticias"), DateTime.Now.AddDays(-1), true, false, true);
            var alertaLeidaNoExpirada = new Alerta(TipoAlerta.INFORMATIVA, new Tema("Noticias"), DateTime.Now.AddDays(1), false, true, true);

            usuario.recibirAlerta(alertaNoLeidaNoExpirada);
            usuario.recibirAlerta(alertaNoLeidaExpirada);
            usuario.recibirAlerta(alertaLeidaNoExpirada);

            //act
            var alertasNoLeidasNoExpiradas = usuario.obtenerAlertasNoLeidasNoExpiradas();

            //assert
            Assert.AreEqual(1, alertasNoLeidasNoExpiradas.Count, "Error: Solo debería haber una alerta no leída y no expirada.");
            Assert.AreEqual(alertaNoLeidaNoExpirada, alertasNoLeidasNoExpiradas[0], "Error: La alerta no leída y no expirada no es la correcta.");
        }
    }
}