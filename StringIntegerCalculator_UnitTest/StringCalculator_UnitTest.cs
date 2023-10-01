using Moq;
using StringCalculator.Core.Specifications;
using System.Data;
using Xunit;

namespace StringIntegerCalculator_UnitTest
{
    public class StringCalculator_UnitTest
    {
        private MathExpressionEvaluator _mathExpressionEvaluator;

        public StringCalculator_UnitTest()
        {
            _mathExpressionEvaluator = new MathExpressionEvaluator();
        }


        [Theory]
        [InlineData("2 + 3", 5)]
        [InlineData("5 * 4", 20)]
        [InlineData("6 / 2", 3)]
        public void Evaluate_ValidExpressions_ReturnsCorrectResult(string expression, double expectedResult)
        {
            // Arrange

            // Act
            double result = _mathExpressionEvaluator.Evaluate(expression);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("2 + abc")] // Invalid expression
        public void Evaluate_InvalidExpressions_ReturnsEvaluateException(string expression)
        {
            // Arrange

            //Act & Assert
            Assert.Throws<EvaluateException>(() => _mathExpressionEvaluator.Evaluate(expression));
        }
        [Theory]
        [InlineData("2 x 3")] // Invalid expression
        public void Evaluate_InvalidExpressions_SyntaxErrorException(string expression)
        {
            // Arrange

            //Act & Assert
            Assert.Throws<SyntaxErrorException>(() => _mathExpressionEvaluator.Evaluate(expression));
        }
    }
}