using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Activities.Commands.EditActivity
{
    public class EditActivityCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Venue { get; set; } = string.Empty;
    }

    public class EditActivityCommandHandler : IRequestHandler<EditActivityCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EditActivityCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<Unit> Handle(EditActivityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Activities.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity != null)
            {
                entity.Category = request.Category;
                entity.City = request.City;
                entity.Date = request.Date;
                entity.Description = request.Description;
                entity.Title = request.Title;
                entity.Venue = request.Venue;
                // _mapper.Map(request, entity);
            }
            else
            {
                throw new NotFoundException(nameof(Activities), request.Id);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}