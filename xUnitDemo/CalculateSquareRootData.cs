using System.Collections;

namespace xUnitDemo;

public class CalculateSquareRootData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 4.0, 2.0 };
        yield return new object[] { 9.0, 3.0 };
        yield return new object[] { 16.0, 4.0 };
        yield return new object[] { 0.25, 0.5 };
        yield return new object[] { 1e16, 1e8 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
