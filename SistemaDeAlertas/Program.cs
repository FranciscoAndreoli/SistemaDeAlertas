using SistemaDeAlertas.Entidades;
using SistemaDeAlertas.Interfaces;

namespace SistemaDeAlertas
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fran = new Usuario("Francisco");
            var jorge = new Usuario("Jorge");
            var martin = new Usuario("Martin");

            var tema1 = new Tema("Noticias");
            var tema2 = new Tema("Notificaciones");

            fran.suscribirseATema(tema1);
            jorge.suscribirseATema(tema2);
            martin.suscribirseATema(tema2);

            tema1.agregarAlerta(TipoAlerta.INFORMATIVA, tema1, DateTime.Now, false, false, true);
            tema2.agregarAlerta(TipoAlerta.URGENTE, tema1, DateTime.Now, false, false, false, jorge);


            var usuarios = tema1.ObtenerObservadoresSuscriptos();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
