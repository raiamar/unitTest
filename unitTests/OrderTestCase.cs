using Xunit;
using FluentValidation;
using Moq;
using FluentValidation.Results;
using xUnitDemo;

namespace unitTests;

public class OrderTestCase
{
    // Fact: Test for valid order with FluentValidation.
    [Fact]
    public void AddOrder_ValidOrder_ShouldCallAddOrderOnce()
    {
        // Arrange
        var mockOrderRepository = new Mock<IOrderRepository>();
        var mockValidator = new Mock<IValidator<Order>>();
        mockValidator.Setup(v => v.Validate(It.IsAny<Order>())).Returns(new ValidationResult());

        var service = new CustomerOrderService(mockOrderRepository.Object, mockValidator.Object);
        var order = new Order { Id = 1, ProductName = "Laptop", Quantity = 5 };

        // Act
        service.AddOrder(order);

        // Assert
        mockOrderRepository.Verify(repo => repo.AddOrder(order), Times.Once);
        mockValidator.Verify(v => v.Validate(order), Times.Once);
    }


    // Theory: Test with invalid data using FluentValidation.
    [Theory]
    [InlineData("", 5)] // Empty product name
    [InlineData("Phone", 0)] // Zero quantity
    [InlineData(null, 10)] // Null product name
    [InlineData("Tablet", -1)] // Negative quantity
    public void AddOrder_InvalidOrder_ShouldThrowValidationException(string productName, int quantity)
    {
        // Arrange
        var mockOrderRepository = new Mock<IOrderRepository>();
        var mockValidator = new Mock<IValidator<Order>>();

        var validationFailures = new List<ValidationFailure>
        {
            new ValidationFailure("ProductName", "Invalid Product Name"),
            new ValidationFailure("Quantity", "Invalid Quantity")
        };

        mockValidator.Setup(v => v.Validate(It.IsAny<Order>())).Returns(new ValidationResult(validationFailures));

        var service = new CustomerOrderService(mockOrderRepository.Object, mockValidator.Object);
        var order = new Order { Id = 2, ProductName = productName, Quantity = quantity };

        // Act & Assert
        Assert.Throws<ValidationException>(() => service.AddOrder(order));
        mockValidator.Verify(v => v.Validate(order), Times.Once);
        mockOrderRepository.Verify(repo => repo.AddOrder(It.IsAny<Order>()), Times.Never);
    }


    // Fact: Test with collection of orders.
    [Fact]
    public void AddOrder_ValidOrdersCollection_ShouldAddEachOrder()
    {
        // Arrange
        var mockOrderRepository = new Mock<IOrderRepository>();
        var mockValidator = new Mock<IValidator<Order>>();
        mockValidator.Setup(v => v.Validate(It.IsAny<Order>())).Returns(new ValidationResult());

        var service = new CustomerOrderService(mockOrderRepository.Object, mockValidator.Object);

        var orders = new List<Order>
        {
            new Order { Id = 1, ProductName = "Laptop", Quantity = 1 },
            new Order { Id = 2, ProductName = "Mouse", Quantity = 2 },
            new Order { Id = 3, ProductName = "Keyboard", Quantity = 3 }
        };

        // Act
        foreach (var order in orders)
        {
            service.AddOrder(order);
        }

        // Assert
        mockOrderRepository.Verify(repo => repo.AddOrder(It.IsAny<Order>()), Times.Exactly(orders.Count));
        mockValidator.Verify(v => v.Validate(It.IsAny<Order>()), Times.Exactly(orders.Count));
    }

    // Theory: Test with multiple orders using MemberData.
    public static IEnumerable<object[]> ValidOrders =>
        new List<object[]>
        {
            new object[] { new Order { Id = 1, ProductName = "Laptop", Quantity = 5 } },
            new object[] { new Order { Id = 2, ProductName = "Headphones", Quantity = 10 } },
            new object[] { new Order { Id = 3, ProductName = "Monitor", Quantity = 2 } }
        };

    [Theory]
    [MemberData(nameof(ValidOrders))]
    public void AddOrder_ValidOrderCollection_ShouldValidateAndAdd(Order order)
    {
        // Arrange
        var mockOrderRepository = new Mock<IOrderRepository>();
        var mockValidator = new Mock<IValidator<Order>>();
        mockValidator.Setup(v => v.Validate(order)).Returns(new ValidationResult());

        var service = new CustomerOrderService(mockOrderRepository.Object, mockValidator.Object);

        // Act
        service.AddOrder(order);

        // Assert
        mockOrderRepository.Verify(repo => repo.AddOrder(order), Times.Once);
        mockValidator.Verify(v => v.Validate(order), Times.Once);
    }

}
