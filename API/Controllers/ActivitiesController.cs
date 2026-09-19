using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new GetActiviesList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            return await Mediator.Send(new GetActivityDetails.Query{ Id = id} );
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(Activity Activity)
        {
            return await Mediator.Send(new CreateActivity.Command {activity = Activity});
        }

        [HttpPut]
        public async Task<ActionResult> EditActicity(Activity activity)
        {
            await Mediator.Send(new EditActivity.Command{ Activity = activity});
            
            return NoContent();
        }

        
    }
}
