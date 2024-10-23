using xUnitDemo;

namespace MathTestCase;

public class MathTestCase
{
    [Fact]
    public void CalculateSquareRoot_PositiveNumber_ReturnsDouble()
    {
        // Arrange
        var mathService = new MathService();
        double input = 16.0;
        double expected = 4.0;

        // Act
        double result = mathService.CalculateSquareRoot(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CalculateSquareRoot_NegativeNumber_ThrowsArgumentException()
    {
        // Arrange
        var mathService = new MathService();
        double input = -1.0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => mathService.CalculateSquareRoot(input));
    }

    [Fact]
    public void CalculateSquareRoot_LargeNumber_ReturnsCorrectResult()
    {
        // Arrange
        var mathService = new MathService();
        double input = 1e16; // 10^16
        double expected = 1e8; // 10^8

        // Act
        double result = mathService.CalculateSquareRoot(input);

        // Assert
        Assert.Equal(expected, result, precision: 5); // Including precision for floating-point comparison
    }


    [Fact]
    [Trait("Category", "Edge Case")]
    public void CalculateSquareRoot_MultipleCalls_PerformsUnderThreshold()
    {
        // Arrange
        var mathService = new MathService();
        double input = 100;
        long iterations = 100000000;
        var stopwatch = new System.Diagnostics.Stopwatch();

        // Act
        stopwatch.Start();
        for (int i = 0; i < iterations; i++)
        {
            mathService.CalculateSquareRoot(input);
        }
        stopwatch.Stop();

        // Assert
        Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 1000);
        // Ensure it runs in under 1 second
        //Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 10); to test failed case you can reduce the time to milliseconds
    }


    [Theory]
    [InlineData(0, 0)]
    [InlineData(1e16, 1e8)]
    [InlineData(0.25, 0.5)]
    [InlineData(0.0, 0.0)]
    [Trait("Category", "Edge Case")]
    public void CalculateSquareRoot_EdgeCases_ReturnsCorrectResult(double input, double expected)
    {
        // Arrange
        var mathService = new MathService();

        // Act
        double result = mathService.CalculateSquareRoot(input);

        // Assert
        Assert.Equal(expected, result, precision: 5); // Allows for a small difference due to floating-point precision
    }

    //The[Trait] attribute allows you to add metadata to your tests.This metadata is often used to categorize or filter tests when running them.
    //dotnet test --filter "Category=Math"


    [Theory]
    [MemberData(nameof(CalculateSquareRootTestData))]
    public void CalculateSquareRoot_MemberData_ReturnsCorrectResult(double input, double expected)
    {
        // Arrange
        var mathService = new MathService();

        // Act
        double result = mathService.CalculateSquareRoot(input);

        // Assert
        Assert.Equal(expected, result, precision: 5);
    }

    // This method provides data to the test method
    public static IEnumerable<object[]> CalculateSquareRootTestData()
    {
        yield return new object[] { 4.0, 2.0 };
        yield return new object[] { 9.0, 3.0 };
        yield return new object[] { 16.0, 4.0 };
        yield return new object[] { 0.25, 0.5 };
        yield return new object[] { 1e16, 1e8 };
    }


    [Theory]
    [ClassData(typeof(CalculateSquareRootData))]
    public void CalculateSquareRoot_ClassData_ReturnsCorrectResult(double input, double expected)
    {
        // Arrange
        var mathService = new MathService();

        // Act
        double result = mathService.CalculateSquareRoot(input);

        // Assert
        Assert.Equal(expected, result, precision: 5);
    }

}