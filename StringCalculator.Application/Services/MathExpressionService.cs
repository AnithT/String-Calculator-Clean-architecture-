using StringCalculator.Application.Interfaces;
using StringCalculator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Application.Services
{
    public class MathExpressionService : IMathExpressionService
    {
            private readonly IMathExpressionEvaluator _evaluator;

            public MathExpressionService(IMathExpressionEvaluator evaluator)
            {
                _evaluator = evaluator;
            }

            public double EvaluateExpression(string expression)
            {
                return _evaluator.Evaluate(expression);
            }
        }
}
