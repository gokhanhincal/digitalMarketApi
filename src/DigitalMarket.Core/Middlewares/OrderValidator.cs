using DigitalMarket.Core.Contracts;
using FluentValidation;

namespace DigitalMarket.Core.Middlewares;

// TODO: FluentValidation version is not supported with .NET 7.0 and will be updated
public class OrderValidator : AbstractValidator<CreateOrderRequest>
{
    public OrderValidator()
    {
        RuleFor(order => order.Partner).NotNull().NotEmpty();
        RuleFor(order => order.OrderID).NotNull().NotEmpty();
        RuleFor(order => order.LineItems.Count).NotNull().GreaterThan(0);
    }
}