using GYM4U.Common;
using GYM4UModel;
using GYM4URepository.Common;
using GYM4UService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM4UService
{
    public class ActivityService : IActivityService
    {
        protected IActivityRepository Repository { get; set; }

        public ActivityService(IActivityRepository repository)
        {
            Repository = repository;
        }
        public async Task<List<ActivityModelDTO>> GetAllActivity(Paging paging, Sorting sorting, Filtering filtering)
        {
            List<ActivityModelDTO> activity = await Repository.GetAllActivity(paging, sorting, filtering);

            return activity;
        }

        public async Task<bool> CreateNewActivity(ActivityModelDTO activity)
        {
            bool isAdded = await Repository.CreateNewActivity(activity);
            return isAdded;

        }

        public async Task<bool> EditActivity(Guid id, ActivityModelDTO activity)

        {
            ActivityModelDTO findActivity = await GetActivity(id);

            if (findActivity == null)
            {

                return false;
            }

            ActivityModelDTO activityForUpdate = new ActivityModelDTO();
            activityForUpdate.Name = activity.Name == default ? findActivity.Name : activity.Name;
            activityForUpdate.Duration = activity.Duration == default ? findActivity.Duration : activity.Duration;
            activityForUpdate.IsActive = activity.IsActive == default ? findActivity.IsActive : activity.IsActive;
            

            Task<bool> isEdited = Repository.EditActivity(id, activityForUpdate);
            return await isEdited;

        }

        public async Task<ActivityModelDTO> GetActivity(Guid id)
        {
            ActivityModelDTO activityModel = await Repository.GetActivity(id);

            return activityModel;
        }

       
        public async Task<bool> DeleteActivity(Guid id)
        {
            ActivityModelDTO activityCheck = await Repository.GetActivity(id);
            if (activityCheck == null)
            {
                return false;
            }
            bool isDeleted = await Repository.DeleteActivity(id);
            return isDeleted;
        }
    }
}
