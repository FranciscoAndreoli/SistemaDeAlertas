using SistemaDeAlertas.Entidades;

namespace SistemaDeAlertas
{
    public class Program
    {
        static void Main(string[] args)
        {
            Usuario fran = new Usuario("Francisco");

            Tema tema1 = new Tema("Noticias");

            tema1.agregarAlerta(TipoAlerta.INFORMATIVA, tema1, DateTime.Now, false, false);
            tema1.agregarAlerta(TipoAlerta.URGENTE, tema1, DateTime.Now, false, false);

            foreach (Alerta alerta in tema1.AlertasDelTema)
            {
                Console.WriteLine($"TIpo: {alerta.Tipo} y expiracion: {alerta.FechaExpiracion}");
            }


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
