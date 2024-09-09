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
            var jose = new Usuario("Jose");

            var tema1 = new Tema("Noticias");
            var tema2 = new Tema("Notificaciones");
            var tema3 = new Tema("Noticias Urgentes");

            fran.suscribirseATema(tema1);
            jorge.suscribirseATema(tema2);
            jose.suscribirseATema(tema3);

            tema1.agregarAlerta(TipoAlerta.INFORMATIVA, tema1, DateTime.Now.AddDays(1), false, false, true);
            tema2.agregarAlerta(TipoAlerta.INFORMATIVA, tema1, DateTime.Now.AddDays(1), false, false, false, jorge);
            tema3.agregarAlerta(TipoAlerta.URGENTE, tema3, DateTime.Now.AddDays(1), false, false, true);
            tema3.agregarAlerta(TipoAlerta.INFORMATIVA, tema3, DateTime.Now.AddDays(2), false, false, true);

            tema2.notificarUsuarios();
            tema3.notificarUsuarios();
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
