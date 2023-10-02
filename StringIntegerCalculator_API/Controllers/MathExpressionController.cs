using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StringCalculator.Application.Interfaces;
using StringIntegerCalculator_API.Exceptions;
using StringIntegerCalculator_API.Extensions;

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
        [Authorize]
        [HttpGet]
        public IActionResult Evaluate(string expression)
        {


            if (!expression.IsValidMathExpression())
            {
                return BadRequest(new APIResponce(402));
            }

            double result = _expressionService.EvaluateExpression(expression);
                var response = new { expression, result };
                return Ok(response);
           
        }
    }
}
