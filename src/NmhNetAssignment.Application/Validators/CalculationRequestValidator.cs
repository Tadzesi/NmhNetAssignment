using FluentValidation;
using NmhNetAssignment.Application.Requests;

namespace NmhNetAssignment.Application.Validators
{
    public class CalculationRequestValidator : AbstractValidator<CalculationRequest>
    {
        public CalculationRequestValidator()
        {
            RuleFor(x => x.Input)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
