using SolidInvestimentos.Core.Entities;
using SolidInvestimentos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidInvestimentos.Core.Services
{
  public class InvestmentSimulator
  {
      private readonly IInvestmentStrategy _strategy;
      private readonly ILogger _logger;

    public InvestmentSimulator(IInvestmentStrategy strategy, ILogger logger)
    {
      _strategy = strategy;
      _logger = logger;
    }

    public void Simulate(Investment investment)
    {
      decimal result = _strategy.CalculateReturn(investment);
      _logger.Log($"Simulação de investimento para '{investment.Type}':");
      _logger.Log($"Valor investido: R$ {investment.Amount:F2}");
      _logger.Log($"Período: {investment.Months} meses");
      _logger.Log($"Retorno estimado: R$ {result:F2}");
    }
  }
}