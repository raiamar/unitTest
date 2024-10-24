using FluentValidation;

namespace xUnitDemo;

public class OrderValidation : AbstractValidator<Order>
{
    public OrderValidation()
    {
        RuleFor(order => order.ProductName)
            .NotEmpty().WithMessage("Product name must not be empty.");

        RuleFor(order => order.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

        RuleFor(order => order.Id)
            .GreaterThan(0).WithMessage("Order ID must be a positive number.");
    }
}
