using GYM4U.Common;
using GYM4UDAL;
using GYM4UModel;
using GYM4URepository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GYM4URepositpry
{
    public class ActivityRepository : IActivityRepository
    {
        protected Gym4UEntities Context { get; set; }
        public ActivityRepository(Gym4UEntities contex)
        {
            Context = contex;
        }
        public async Task<List<ActivityModelDTO>> GetAllActivity(Paging paging, Sorting sorting, Filtering filtering)
        {
            List<ActivityModelDTO> activityList = new List<ActivityModelDTO>();
            List<Activity> allActivities = await Context.Activity.ToListAsync();
            foreach (var activities in allActivities)
            {
                activityList.Add(new ActivityModelDTO()
                {
                    Id = activities.Id,
                    Name = activities.Name,
                    Duration = activities.Duration,
                    IsActive = activities.IsActive
                });
            }
            return activityList;
        }
        public async Task<bool> CreateNewActivity(ActivityModelDTO activity)
        {
            activity.Id = Guid.NewGuid();
            activity.DateCreated = DateTime.Now;
            activity.DateUpdated = DateTime.Now;
            Context.Activity.Add(new Activity
            {
                Id = Guid.NewGuid(),
                Name = activity.Name,
                Duration = activity.Duration,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                UpdatedByUserId = activity.UpdatedByUserId,
                CreatedByUserId = activity.CreatedByUserId,
                IsActive = activity.IsActive
                

            });

            var numberOfRows = await Context.SaveChangesAsync();

            if (numberOfRows > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EditActivity(Guid id, ActivityModelDTO activity)
        {
            Activity editedActivity = await Context.Activity.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (editedActivity != null)
            {
                editedActivity.Name = activity.Name;
                editedActivity.Duration = activity.Duration;
                editedActivity.IsActive = activity.IsActive;
                
                Context.SaveChanges();
                return true;
            }
            else return false;
        }


        public async Task<ActivityModelDTO> GetActivity(Guid id)
        {
            Activity activity = new Activity();
            activity = await Context.Activity.Where(a => a.Id == id).FirstOrDefaultAsync();
            ActivityModelDTO findedActivity = new ActivityModelDTO();
            if (activity != null)
            {
                findedActivity.Id = id;
                findedActivity.Name = activity.Name;
                findedActivity.Duration = activity.Duration;
                findedActivity.IsActive = activity.IsActive;
                
            }
            return findedActivity;
        }
        

        public Task<bool> DeleteActivity(Guid id)
        {
            throw new NotImplementedException();
        }

        

        

    }
}
