using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Activity>> GetAllAsync()
        {
            var activities = await _context.Activities.OrderByDescending(x=>x.Id).ToListAsync();
            return activities;
        }
        public async Task<Activity> GetAsync(long id)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(i => i.Id ==id);
            return activity;
        }
        public async Task AddAsync(Activity activity)
        {
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
        }
    }
}