using SolidInvestimentos.Application.UseCases;
using SolidInvestimentos.Infrastructure.Logging;

namespace SolidInvestimentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger logger = new ConsoleLogger();
            RunSimulation runSimulation = new RunSimulation(logger);

            Console.Clear();
            Console.WriteLine("=== Simulador de Investimentos ===\n");

            Console.WriteLine("Escolha o tipo de investimento:");
            Console.WriteLine("1 - CDB");
            Console.WriteLine("2 - Poupança");
            Console.Write("\nOpção: ");
            string? opcao = Console.ReadLine()?.Trim();

            string tipo = opcao switch
            {
              "1" => "cdb",
              "2" => "poupanca",
              _ => string.Empty
            };

            if (string.IsNullOrEmpty(tipo))
            {
              Console.WriteLine("\nOpção inválida. Encerrando aplicação.");
              return;
            }

            Console.Write("\nDigite o valor a ser investido (ex: 1000.50): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor <= 0)
            {
              Console.WriteLine("\nValor inválido. Encerrando aplicação.");
              return;
            }

            Console.Write("Digite o número de meses (ex: 12): ");
            if (!int.TryParse(Console.ReadLine(), out int meses) || meses <= 0)
            {
              Console.WriteLine("\nPeríodo inválido. Encerrando aplicação.");
              return;
            }

            try
            {
              Console.WriteLine("\nSimulando investimento...\n");
              runSimulation.Execute(tipo, valor, meses);
            }
            catch (Exception ex)
            {
              Console.WriteLine($"\nErro: {ex.Message}");
            }

            Console.WriteLine("\nSimulação finalizada. Pressione qualquer tecla para sair.");
            Console.ReadKey();
    }
    }
} 