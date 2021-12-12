using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Activities.Queries.GetActivities
{
    public class GetActivitiesQuery : IRequest<List<Activity>>
    {

    }

    public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQuery, List<Activity>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetActivitiesQueryHandler> _logger;
        public GetActivitiesQueryHandler(IApplicationDbContext context, ILogger<GetActivitiesQueryHandler> logger)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<List<Activity>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Delay(1000, cancellationToken);
                    _logger.LogInformation("Task {0} has completed", i);
                }
            }
            catch (System.OperationCanceledException ex)
            {
                _logger.LogInformation("Task was canceled. {0}", ex.Message);
            }
            catch (System.ObjectDisposedException ex)
            {
                _logger.LogInformation("Task was canceled. {0}", ex.Message);
            }
            if (_context.Activities != null && _context.Activities.Any())
            {
                return await _context.Activities.ToListAsync(cancellationToken);
            }
            return new List<Activity>();
        }
    }
}