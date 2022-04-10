using Xunit;
using Calculator;
using System;

namespace Assignment_1__Calculator.Tests
{
    public class DivisorTest
    {
        Divisor testCase;
        public DivisorTest()
        {
            // Instantiating a divisor.
            testCase = new Divisor();
        }

        [Fact]
        public void FactTestDivisor()
        {
            // Arrange
            double valueB = 0;
            bool expected = true;
            // Act
            bool actual = testCase.IsZero(valueB);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(-0, true)]
        [InlineData(+0, true)]
        [InlineData(-1, false)]
        [InlineData(0.00000000000000000000000000000000000000000000000000000000000000001, false)]
        // Arrange
        public void TheoryTestDivisor(double valueB, bool expected)
        {
            // Act
            bool actual = testCase.IsZero(valueB);
            // Assert
            Assert.Equal(expected, actual);
        }
    }


    public class DivisionTest
    {
        Division testCase;
        public DivisionTest()
        {
            // Instantiating a divisor.
            testCase = new Division();
        }

        [Fact]
        public void FactTestDivision()
        {
            // Arrange
            double valueA = 50;
            double valueB = 20;
            double expected = 2.5;
            // Act
            double actual = testCase.Calculation(valueA, valueB);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 10, 1)]
        [InlineData(-10, -1, 10)]
        [InlineData(1000, -10, -100)]
        [InlineData(0, 1, 0)]
        [InlineData(8, 0.01, 800)]
            // Arrange
        public void TheoryTestDivision(double valueA, double valueB, double expected)
        {
            // Act
            double actual = testCase.Calculation(valueA, valueB);
            // Assert
            Assert.Equal(expected, actual);
        }
    }


    public class AdditionTest
    {

        Addition testCase;
        public AdditionTest()
        {
            // Instantiating an addition.
            testCase = new Addition();
        }

        [Fact]
        public void FactTestAdditionTestFunction()
        {
            // Arrange
            testCase.valueX = 50;
            testCase.valueY = 25.99;
            double expected = 75.99;
            // Act
            double actual = testCase.testAddition;
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FactTestSingleAddition()
        {
            // Arrange
            double valueA = 50;
            double valueB = 25.99;
            double expected = 75.99;
            // Act
            double actual = testCase.Calculation(valueA, valueB);
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FactTestAdditionArray()
        {
            // Arrange.
            double[] testArray = { 50, 1000, -50, 0.1 };
            double expected = 1000.1;
            // Act
            double actual = testCase.Calculation(testArray);
            // Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(50, 25.99, 75.99)]
        [InlineData(-1, -1, -2)]
        [InlineData(10, 10, 20)]
        [InlineData(0, 0, 0)]
        [InlineData(0.1, 0.01, 0.11)]
            // Arrange
        public void TheoryTestSingleAddition(double valueA, double valueB, double expected)
        {
            // Act
            double actual = testCase.Calculation(valueA, valueB);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}