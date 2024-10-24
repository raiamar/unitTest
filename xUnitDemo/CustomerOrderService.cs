using FluentValidation;
namespace xUnitDemo;

public class CustomerOrderService(IOrderRepository orderRepository, IValidator<Order> validator)
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IValidator<Order> _validator = validator;

    public void AddOrder(Order order)
    {
        var validationResult = _validator.Validate(order);
        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }

        _orderRepository.AddOrder(order);
    }
}
