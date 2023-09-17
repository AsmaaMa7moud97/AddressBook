using FluentValidation;

namespace AddressBook.Application.Commands
{
    public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidator()
        {
            RuleFor(c => c.NameAr)
                 .MaximumLength(200)
                 .NotEmpty();

            RuleFor(c => c.NameEn)
                .MaximumLength(200)
                .NotEmpty();

            
        }
    }
}