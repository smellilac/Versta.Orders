using FluentValidation;

namespace Order.Application.CQRS.Commands;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(order => order.Id)
           .NotEmpty().WithMessage("Id cant be empty.")
           .NotEqual(Guid.Empty).WithMessage("Id cant be empty Guid.");

        RuleFor(order => order.SenderCity)
            .NotEmpty().WithMessage("Sender city is required.")
            .MaximumLength(100).WithMessage("Sender's city cannot exceed 100 characters.");

        RuleFor(order => order.SenderAddress)
            .NotEmpty().WithMessage("Sender address is required.")
            .MaximumLength(100).WithMessage("The sender's address cannot exceed 100 characters..");

        RuleFor(order => order.ReceiverCity)
            .NotEmpty().WithMessage("Receiver city is required.")
            .MaximumLength(100).WithMessage("The receiver's city cannot exceed 100 characters..");

        RuleFor(order => order.ReceiverAddress)
            .NotEmpty().WithMessage("Receiver address is required.")
            .MaximumLength(100).WithMessage("The receiver's address cannot exceed 100 characters..");

        RuleFor(order => order.Weight)
            .GreaterThan(0).WithMessage("Weight must be greater than 0.")
            .LessThanOrEqualTo(1000).WithMessage("The weight should not exceed 1000 kg.");

        RuleFor(order => order.PickupDate)
            .NotEmpty().WithMessage("The date of cargo collection is mandatory.")
            .Must(date => date >= DateTime.UtcNow.Date)
            .WithMessage("The date of cargo collection cannot be in the past.");
    }
}
