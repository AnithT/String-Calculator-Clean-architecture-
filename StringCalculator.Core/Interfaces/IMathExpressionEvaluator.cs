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
    public class MathExpressionEvaluator : IMathExpressionEvaluator
    {
        public double Evaluate(string expression)
        {
            // Implement the expression evaluation logic here
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
    }
}
