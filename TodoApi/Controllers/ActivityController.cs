using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Dto;
using TodoApi.Errors;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    [Authorize]
    [Route("api/Activity")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;

        public ActivityController(IMapper mapper, IActivityRepository activityRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
        }

        // GET: api/Activity
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _activityRepository.GetAllAsync();
            return Ok(activities);
        }

        //GET: api/Activity/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(long id)
        {
            var activity = await _activityRepository.GetAsync(id);
            if (activity == null)
            {
                return NotFound(new ErrorMessage("Invaild id"));
            }
            return Ok(activity);
        }
        
        // POST: api/Activity
        [HttpPost]
        public async Task<ActionResult<Activity>> PostActivity(newActivityDTO activityDTO)
        {
            var activity = _mapper.Map<Activity>(activityDTO);
            await _activityRepository.AddAsync(activity);

            return CreatedAtAction(nameof(GetActivity), new { id = activity.Id}, activity);
        }
    }
}