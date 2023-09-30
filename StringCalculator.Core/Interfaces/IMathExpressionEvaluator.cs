using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Core.Interfaces
{
    public interface IMathExpressionEvaluator
    {
        double Evaluate(string expression);
    }
   
}
