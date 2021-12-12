using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommand : IRequest<Guid>
    {
        // public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Venue { get; set; } = string.Empty;
    }

    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateActivityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = new Activity
            {
                Category = request.Category,
                City = request.City,
                Date = request.Date,
                Description = request.Description,
                Title = request.Title,
                Venue = request.Venue
            };
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync(cancellationToken);
            return activity.Id;
        }
    }
}