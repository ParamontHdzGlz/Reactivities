using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Quey : IRequest<Activity>
        {
            public Guid Id {get; set; }
        }

        public class Handler : IRequestHandler<Quey, Activity>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }


            public async Task<Activity> Handle(Quey request, CancellationToken cancellationToken)
            {
                return await _context.Activities.FindAsync(request.Id);
            }
        }
    }
}