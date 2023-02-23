using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersCalculator.Models
{
    internal class RomanNumberException : Exception
    {
        public RomanNumberException(string message = "#ERROR") : base(message) { }
    }
}
