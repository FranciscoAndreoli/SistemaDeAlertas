using SistemaDeAlertas.Interfaces;

namespace SistemaDeAlertas.Entidades
{
	public class Usuario : IObservador
	{
		public string Nombre { get; }
		public List<Alerta> AlertasDelUsuario { get; private set; }
		public Usuario(string nombre)
		{
			Nombre = nombre;
			AlertasDelUsuario = new List<Alerta>();

        }

		public void marcarAlertaComoLeida()
		{

		}

		public void obtenerAlertasNoLeidas()
		{

		}

		public void recibirAlerta(Alerta alerta)
		{
			AlertasDelUsuario.Add(alerta);

        }
	}
}
