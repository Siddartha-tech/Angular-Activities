using Application.Common.Interfaces;
using MediatR;

namespace Application.Activities.Commands.DeleteActivity
{
    public class DeleteActivityCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteActivityCommandHandler(IApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<Unit> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Activities.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity != null)
            {
                _context.Activities.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}