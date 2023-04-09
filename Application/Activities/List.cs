using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Quey : IRequest<List<Activity>> {}

        public class Handler : IRequestHandler<Quey, List<Activity>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }


            public async Task<List<Activity>> Handle(Quey request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync();
            }
        }
    }
}