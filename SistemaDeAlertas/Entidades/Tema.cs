using System;
using System.ComponentModel.DataAnnotations;
using SistemaDeAlertas.Interfaces;

namespace SistemaDeAlertas.Entidades
{
    public class Tema : INotificador
    {
        public string Nombre { get; private set; }
        public List<IObservador> ObservadoresSuscriptos { get; private set; }
        public List<Alerta> AlertasDelTema { get; private set; }

        public Tema(string nombre)
        {
            this.Nombre = nombre;
            this.ObservadoresSuscriptos = new List<IObservador>();
            this.AlertasDelTema = new List<Alerta>();

        }
        public void agregarAlerta(TipoAlerta tipo, Tema temaAsociado, DateTime fechaExpiracion, bool expiro, bool leido, bool esParaTodos, Usuario? usuarioEspecifico = null)
        {
            var nuevaAlerta = new Alerta(tipo, temaAsociado, fechaExpiracion, expiro, leido, esParaTodos, usuarioEspecifico);
            AlertasDelTema.Add(nuevaAlerta);
        }

        public List<Alerta> obtenerAlertasNoExpiradas()
        {
            var alertasNoExpiradas = new List<Alerta>();
            foreach (var alerta in AlertasDelTema)
            {
                if (!alerta.haExpirado())
                {
                    alertasNoExpiradas.Add(alerta);
                }
            }
            return alertasNoExpiradas;
        }

        public void suscribirUsuario(IObservador usuario)
        {
            ObservadoresSuscriptos.Add(usuario);
        }

        public void desuscribirUsuario(IObservador usuario)
        {
            ObservadoresSuscriptos.Remove(usuario);
        }

        public List<IObservador> ObtenerObservadoresSuscriptos()
        {
            return ObservadoresSuscriptos;
        }

        public void notificarUsuarios()
        {
            foreach(var alerta in AlertasDelTema)
            {
                if (alerta.EsParaTodos)
                {
                    foreach (var usuario in ObservadoresSuscriptos)
                    {
                        usuario.recibirAlerta(alerta);
                    }
                }
                else
                {
                    if (alerta.UsuarioEspecifico != null)
                    {
                        alerta.UsuarioEspecifico.recibirAlerta(alerta);
                    }
                }
            }
        }
    }
}
