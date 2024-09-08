using System;
using SistemaDeAlertas.Interfaces;

namespace SistemaDeAlertas.Entidades
{
	public class Tema
	{
		public string Nombre { get; private set; }
		private List<IObservador> UsuariosSuscriptos { get; set; }
		public List<Alerta> AlertasDelTema { get; private set; }

		public Tema(string nombre)
		{
			Nombre = nombre;
			UsuariosSuscriptos = new List<IObservador>();
			AlertasDelTema = new List<Alerta>();

        }
        //TipoAlerta tipo, Tema temaAsociado, DateTime fechaExpiracion, bool expiro, bool leido
        public void agregarAlerta(TipoAlerta tipo, Tema temaAsociado, DateTime fechaExpiracion, bool expiro, bool leido)
		{
			Alerta nuevaAlerta = new Alerta(tipo, temaAsociado, fechaExpiracion, expiro, leido);
			AlertasDelTema.Add(nuevaAlerta);
        }

		public void obtenerAlertasNoExpiradas()
		{

		}

		public void suscribirUsuario()
		{

		}

        public void desuscribirUsuario()
        {

        }

        public void notificarUsuarios()
        {

        }
        public void notificarUsuario()
        {

        }
    }
}
