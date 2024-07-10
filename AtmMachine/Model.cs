using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine
{
    public record Person (int Id, long AcctNo, decimal Balance, string Name, int Pin);
    
    internal class Model
    {
    }
}
