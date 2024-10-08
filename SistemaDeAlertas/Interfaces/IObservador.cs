﻿using SistemaDeAlertas.Entidades;

namespace SistemaDeAlertas.Interfaces
{
    public interface IObservador
    {
        public void recibirAlerta(Alerta alerta);
        public void suscribirseATema(INotificador notificador);
    }
}