using System;

namespace SistemaDeAlertas.Entidades
{
    public class Alerta
    {
        public TipoAlerta Tipo { get; private set; }
        public Tema TemaAsociado { get; private set; }
        public DateTime FechaExpiracion { get; private set; }
        public bool Expiro { get; private set; }
        public bool Leido { get; private set; }

        public Alerta(TipoAlerta tipo, Tema temaAsociado, DateTime fechaExpiracion, bool expiro, bool leido)
        {
            this.Tipo = tipo;
            this.TemaAsociado = temaAsociado;
            this.FechaExpiracion = fechaExpiracion;
            this.Expiro = expiro;
            this.Leido = leido;
        }

        public void esExpirada()
        {
            if (FechaExpiracion < DateTime.Now)
            {
                Expiro = true;
            }

        }
    }
}

