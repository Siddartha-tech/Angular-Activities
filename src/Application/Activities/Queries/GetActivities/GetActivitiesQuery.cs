using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities.Queries.GetActivities
{
    public class GetActivitiesQuery : IRequest<List<Activity>>
    {

    }

    public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQuery, List<Activity>>
    {
        private readonly IApplicationDbContext _context;
        public GetActivitiesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Activity>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
        {
            if (_context.Activities != null && _context.Activities.Any())
            {
                return await _context.Activities.ToListAsync(cancellationToken);   
            }
            return new List<Activity>();
        }
    }
}