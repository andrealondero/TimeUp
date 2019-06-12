using FluentValidation;

using timesheet.Models;

namespace timesheet.Validator
{
    public class UserValidator : AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(c => c.Mail).Must(ValidateStringEmpty).WithMessage("Insert a username.");
            RuleFor(c => c.Password).Must(ValidateStringEmpty).WithMessage("Insert a password.");
        }
        bool ValidateStringEmpty(string stringValue)
        {
            if (!string.IsNullOrEmpty(stringValue))
                return true;
            return false;
        }
    }
}
