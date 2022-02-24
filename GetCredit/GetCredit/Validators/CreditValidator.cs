using FluentValidation;
using GetCredit.Dtos;

namespace GetCredit.Validators
{
    public class CreditValidator : AbstractValidator<CreditRequestDto>
    {
        public CreditValidator()
        {
            RuleFor(c => c.CreditValue).GreaterThan(2000);
            RuleFor(c => c.CreditValue).LessThanOrEqualTo(69000);
        }
    }
}
