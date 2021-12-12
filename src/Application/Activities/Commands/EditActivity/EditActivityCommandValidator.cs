using FluentValidation;

namespace Application.Activities.Commands.EditActivity
{
    public class EditActivityCommandValidator : AbstractValidator<EditActivityCommand>
    {
        public EditActivityCommandValidator()
        {
            RuleFor(v => v.Title).NotEmpty().MaximumLength(200);
            RuleFor(v => v.Category).NotEmpty();
            RuleFor(v => v.City).NotEmpty();
            RuleFor(v => v.Description).NotEmpty();
            RuleFor(v => v.Date).NotEmpty();
            RuleFor(v => v.Venue).NotEmpty();
        }
    }
}