﻿using SistemaDeAlertas.Interfaces;
using System.ComponentModel.DataAnnotations;

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

        public void suscribirseATema(INotificador notificador)
        {
            notificador.suscribirUsuario(this);
        }

        public void recibirAlerta(Alerta alerta)
        {
            AlertasDelUsuario.Add(alerta);

        }

        public void marcarPrimeraAlertaNoLeidaComoLeida()
        {
            var alerta = AlertasDelUsuario.FirstOrDefault(a => !a.Leido);
            if (alerta != null)
            {
                alerta.Leido = true;
            }
        }

        public List<Alerta> obtenerAlertasNoLeidasNoExpiradas()
        {
            var alertasNoLeidasNoExpiradas = new List<Alerta>();

            foreach (var alerta in AlertasDelUsuario)
            {
                if (!alerta.Leido && !alerta.haExpirado())
                {
                    alertasNoLeidasNoExpiradas.Add(alerta);
                }
            }

            // Urgentes LIFO primero y después informativas FIFO.
            var urgentes = alertasNoLeidasNoExpiradas.Where(a => a.Tipo == TipoAlerta.URGENTE).OrderByDescending(a => a.FechaExpiracion);

            var informativas = alertasNoLeidasNoExpiradas.Where(a => a.Tipo == TipoAlerta.INFORMATIVA).OrderBy(a => a.FechaExpiracion);

            return urgentes.Concat(informativas).ToList();
        }

    }
}
