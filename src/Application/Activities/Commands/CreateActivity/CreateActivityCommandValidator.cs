using FluentValidation;

namespace Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityCommandValidator()
        {
            RuleFor(v => v.Title).NotEmpty().MaximumLength(200);
            RuleFor(v => v.Category).NotEmpty();
            RuleFor(v => v.City).NotEmpty();
            RuleFor(v => v.Description).NotEmpty();
            RuleFor(v => v.Date).NotEmpty();
            RuleFor(v => v.Venue).NotEmpty();
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}