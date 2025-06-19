using SolidInvestimentos.Core.Entities;
using SolidInvestimentos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidInvestimentos.Core.Services
{
  public class CdbInvestment : IInvestmentStrategy, IInvestmentCalculator
  {
    private const decimal MonthlyRate = 0.011m;

    public decimal CalculateReturn(Investment investment)
    {
      return investment.Amount * (1 + MonthlyRate * investment.Months);
    }

    public decimal Calculate(Investment investment)
    {
      return CalculateReturn(investment);
    }
  }     
}