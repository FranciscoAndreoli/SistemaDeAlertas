using SistemaDeAlertas.Entidades;

namespace SistemaDeAlertas.Interfaces
{
    public interface INotificador
    {
        void suscribirUsuario(IObservador usuario);
        void desuscribirUsuario(IObservador usuario);
        void notificarUsuarios();
        void notificarUsuario(IObservador usuario);
    }
}