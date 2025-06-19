using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidInvestimentos.Core.Entities
{
  public class Investment
  {
    public string Type { get; }
    public decimal Amount { get; }
    public int Months { get; }

    public Investment(string type, decimal amount, int months)
    {
      Type = type;
      Amount = amount;
      Months = months;
    }
  }
}