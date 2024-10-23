namespace xUnitDemo;

public class MathService
{
    public double CalculateSquareRoot(double number)
    {
        if (number < 0)
            throw new ArgumentException("Input must be non-negative");
        return Math.Sqrt(number);
    }

}
