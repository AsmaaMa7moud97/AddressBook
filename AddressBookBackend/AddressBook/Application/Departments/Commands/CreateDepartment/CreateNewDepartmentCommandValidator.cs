using FluentValidation;

namespace AddressBook.Application.Commands
{
    public class CreateNewDepartmentCommandValidator : AbstractValidator<CreateNewDepartmentCommand>
    {
        public CreateNewDepartmentCommandValidator()
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