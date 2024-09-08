using SistemaDeAlertas.Interfaces;

namespace SistemaDeAlertas.Entidades
{
    public class Usuario : IObservador
    {
        public string Nombre { get; }
        public List<Alerta> AlertasDelUsuario { get; private set; }
        public Usuario(string nombre)
        {
            this.Nombre = nombre;
            this.AlertasDelUsuario = new List<Alerta>();

        }

        public void marcarAlertaComoLeida()
        {
            throw new NotImplementedException();
        }

        public List<Alerta> obtenerAlertasNoLeidas()
        {
            throw new NotImplementedException();
        }

        public void suscribirseATema(INotificador notificador)
        {
            notificador.suscribirUsuario(this);
        }

        public void recibirAlerta(Alerta alerta)
        {
            AlertasDelUsuario.Add(alerta);

        }
    }
}
