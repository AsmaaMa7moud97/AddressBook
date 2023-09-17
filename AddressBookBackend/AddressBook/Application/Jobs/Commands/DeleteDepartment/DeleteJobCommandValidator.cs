using FluentValidation;

namespace AddressBook.Application.Commands
{
    public class DeleteJobCommandValidator : AbstractValidator<EditDepartmentCommand>
    {
        public DeleteJobCommandValidator()
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