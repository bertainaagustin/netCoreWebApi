using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAllAsync ();
        Task<Activity> GetAsync(long id);
        Task  AddAsync(Activity activity);
    }
}