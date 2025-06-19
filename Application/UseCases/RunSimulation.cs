using SolidInvestimentos.Core.Entities;
using SolidInvestimentos.Core.Interfaces;
using SolidInvestimentos.Core.Services;
using SolidInvestimentos.Utils;

namespace SolidInvestimentos.Application.UseCases
{
  public class RunSimulation
  {
    private readonly ILogger _logger;

    public RunSimulation(ILogger logger)
    {
      _logger = logger;
    }

    public void Execute(string investmentType, decimal amount, int months)
    {
      IInvestmentStrategy strategy = InvestmentFactory.GetStrategy(investmentType);
      Investment investment = new Investment(investmentType, amount, months);

      InvestmentSimulator simulator = new InvestmentSimulator(strategy, _logger);
      simulator.Simulate(investment);
    }
  }
}