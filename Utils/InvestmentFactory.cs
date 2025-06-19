using SolidInvestimentos.Core.Interfaces;
using SolidInvestimentos.Core.Services;

namespace SolidInvestimentos.Utils;

public static class InvestmentFactory
{
  public static IInvestmentStrategy GetStrategy(string investmentType)
  {
    return investmentType.ToLower() switch
    {
      "cdb" => new CdbInvestment(),
      "poupanca" => new PoupancaInvestment(),
      _ => throw new ArgumentException($"Tipo de investimento '{investmentType}' não é suportado.")
    };
  }
}