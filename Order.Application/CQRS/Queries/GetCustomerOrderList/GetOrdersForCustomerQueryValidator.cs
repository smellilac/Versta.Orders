using FluentValidation;
using Order.Application.CQRS.Commands;

namespace Order.Application.CQRS.Queries.GetCustomerOrderList;

internal class GetOrdersForCustomerQueryValidator : AbstractValidator<GetOrdersForCustomerQuery>
{
    public GetOrdersForCustomerQueryValidator()
    {
        RuleFor(order => order.ReceiverCity)
            .NotEmpty().WithMessage("Sender city is required.")
            .MaximumLength(100).WithMessage("Sender's city cannot exceed 100 characters.");

        RuleFor(order => order.ReceiverAddress)
            .NotEmpty().WithMessage("Sender address is required.")
            .MaximumLength(100).WithMessage("The sender's address cannot exceed 100 characters..");
    }
}
