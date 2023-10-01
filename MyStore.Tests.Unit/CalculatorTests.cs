using FluentAssertions;
using MyStore.Tests.Unit.Classes;

namespace MyStore.Tests.Unit
{
    public class CalculatorTests
    {
        public readonly Calculator subjectUnderTest;
        public CalculatorTests() 
        { 
            subjectUnderTest = new Calculator();
        }

        [Fact]
        public void SumShouldReturn_CorrectNumber()
        {
            //Arrange
            var x = 1;
            var y = 2;
            var expectedResult = 3;

            //Act
            var actualResult = subjectUnderTest.Sum(x, y);

            //Assert
            expectedResult.Should().Be(actualResult);

        }

        [Fact]
        public void MultiplyShouldReturn_Correct() 
        {
            //Arrange
            var x = 2
        ;   var factor = 2;
            var expectedResult = 4;
            //Act
            var actualResult = subjectUnderTest.Multiply(x, factor);

            //Assert
            expectedResult.Should().Be(actualResult);
        }
    }
}