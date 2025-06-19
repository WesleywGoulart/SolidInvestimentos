using SolidInvestimentos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidInvestimentos.Core.Interfaces
{
  public interface IInvestmentCalculator
  {
    decimal Calculate(Investment investment);
  }
} 