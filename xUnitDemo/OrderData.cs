using System.Collections;

namespace xUnitDemo;

public class OrderData : IEnumerable<Object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new Order { Id = 1, ProductName = "Laptop", Quantity = 5 } };
        yield return new object[] { new Order { Id = 2, ProductName = "Smartphone", Quantity = -2 } };
        yield return new object[] { new Order { Id = 3, ProductName = "Headphones", Quantity = 1 } };

    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
