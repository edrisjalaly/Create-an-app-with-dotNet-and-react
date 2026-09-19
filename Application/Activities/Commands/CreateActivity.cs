using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands
{
    public class CreateActivity
    {
        public class Command : IRequest<string>
        {
            public Activity activity {  get; set; }
        }


        public class handler : IRequestHandler<Command, string>
        {

            private readonly AppDbContext _context;

            public handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {                
                _context.Activities.Add(request.activity);
                await _context.SaveChangesAsync(cancellationToken);
                return request.activity.Id;
            }
        }
    }
}
