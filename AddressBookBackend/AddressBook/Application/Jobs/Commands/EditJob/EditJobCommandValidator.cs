using FluentValidation;

namespace AddressBook.Application.Commands
{
    public class EditJobCommandValidator : AbstractValidator<EditJobCommand>
    {
        public EditJobCommandValidator()
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