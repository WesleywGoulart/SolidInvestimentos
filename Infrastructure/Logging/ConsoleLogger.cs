﻿using SolidInvestimentos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidInvestimentos.Infrastructure.Logging
{
  public class ConsoleLogger : ILogger
  {
    public void Log(string message)
    {
      Console.WriteLine($"[LOG] {message}");
    }
  }
}