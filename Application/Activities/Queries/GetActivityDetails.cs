using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Queries
{
    public class GetActivityDetails
    {
        public class Query : IRequest<Activity>
        {
            public string Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly AppDbContext _context;
            private readonly IMediator _mediator;

            public Handler(AppDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id, cancellationToken);

                if (activity == null) throw new Exception("not found");

                return activity;
            }
        }
    }
}
