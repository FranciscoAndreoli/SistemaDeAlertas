using SistemaDeAlertas.Interfaces;
using System;

namespace SistemaDeAlertas.Entidades
{
    public class Alerta
    {
        public TipoAlerta Tipo { get; private set; }
        public Tema TemaAsociado { get; private set; }
        public DateTime FechaExpiracion { get; private set; }
        public bool Expiro { get; private set; }
        public bool Leido { get; set; }
        public bool EsParaTodos {  get; private set; } 
        public Usuario? UsuarioEspecifico { get; private set; }

        public Alerta(TipoAlerta tipo, Tema temaAsociado, DateTime fechaExpiracion, 
                        bool expiro, bool leido, bool esParaTodos, Usuario? usuarioEspecifico = null)
        {
            this.Tipo = tipo;
            this.TemaAsociado = temaAsociado;
            this.FechaExpiracion = fechaExpiracion;
            this.Expiro = expiro;
            this.Leido = leido;
            this.EsParaTodos = esParaTodos;
            this.UsuarioEspecifico = usuarioEspecifico;
        }

        public bool haExpirado()
        {
            return FechaExpiracion < DateTime.Now;
        }

        public void marcarComoExpirada()
        {
            Expiro = true;
        }
    }
}

