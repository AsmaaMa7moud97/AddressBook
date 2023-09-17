using FluentValidation;

namespace AddressBook.Application.Commands
{
    public class CreateNewEmployeeCommandValidator : AbstractValidator<CreateNewEmployeeCommand>
    {
        public CreateNewEmployeeCommandValidator()
        {
            RuleFor(c => c.FullName)
                 .MaximumLength(200)
                 .NotEmpty();

            RuleFor(c => c.MobileNumber)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(c => c.Email)
                .EmailAddress();  
        }
    }
}