using FluentValidation;

using timesheet.Models;

namespace timesheet.Validator
{
    public class ItemValidator : AbstractValidator<TsItems>
    {
        public ItemValidator()
        {
            RuleFor(c => c.Hours).Must(h => ValidateStringEmpty(h.ToString())).WithMessage("Insert worked hours number.");
            RuleFor(c => c.Description).Must(ValidateStringEmpty).WithMessage("Insert an activity description.");
            RuleFor(c => c.Date).Must(d => ValidateStringEmpty(d.ToString())).WithMessage("Select a Date.");
            RuleFor(c => c.ConfirmedStatus).Must(s => ValidateStringEmpty(s.ToString())).WithMessage("Chose CONFIRMED or REFUSED.");
            RuleFor(c => c.RefusedStatus).Must(s => ValidateStringEmpty(s.ToString())).WithMessage("Chose CONFIRMED or REFUSED.");
        }

        bool ValidateStringEmpty(string stringValue)
        {
            if (!string.IsNullOrEmpty(stringValue))
                return true;
            return false;
        }
    }
}
