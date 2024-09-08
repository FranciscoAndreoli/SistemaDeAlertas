using SistemaDeAlertas.Entidades;

namespace SistemaDeAlertas.Interfaces
{
    public interface IObservador
    {
        public void recibirAlerta(Alerta alerta);
    }
}