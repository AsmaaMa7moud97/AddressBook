using FluentValidation;

namespace AddressBook.Application.Commands
{
    public class EditDepartmentCommandValidator : AbstractValidator<EditDepartmentCommand>
    {
        public EditDepartmentCommandValidator()
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