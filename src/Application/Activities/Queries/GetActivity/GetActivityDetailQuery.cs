using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Activities.Queries.GetActivity
{
    public class GetActivityDetailQuery : IRequest<Activity>
    {
        public Guid Id { get; set; }
    }

    public class GetActivityDetailQueryHandler : IRequestHandler<GetActivityDetailQuery, Activity>
    {
        private readonly IApplicationDbContext _context;
        public GetActivityDetailQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Activity> Handle(GetActivityDetailQuery request, CancellationToken cancellationToken)
        {
            return await _context.Activities.FindAsync(request.Id) ?? new Activity();
        }
    }
}