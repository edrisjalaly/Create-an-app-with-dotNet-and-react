using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Queries
{
    public class GetActiviesList
    {

        public class Query : IRequest<List<Activity>>
        {

        }


        public class handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly AppDbContext _context;

            public handler(AppDbContext context)
            {
                _context = context;
            } 

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {

                return await _context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}
