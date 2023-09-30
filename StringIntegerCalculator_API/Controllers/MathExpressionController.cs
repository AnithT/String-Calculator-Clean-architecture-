using Microsoft.AspNetCore.Mvc;
using StringCalculator.Application.Interfaces;

namespace StringIntegerCalculator_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathExpressionController : ControllerBase
    {
        private readonly IMathExpressionService _expressionService;

        public MathExpressionController(IMathExpressionService expressionService)
        {
            _expressionService = expressionService;
        }

        [HttpGet]
        public IActionResult Evaluate(string expression)
        {
           
                if (string.IsNullOrEmpty(expression))
                {
                    return BadRequest("Expression is empty or null.");
                }

                double result = _expressionService.EvaluateExpression(expression);
                var response = new { expression, result };
                return Ok(response);
           
        }
    }
}
