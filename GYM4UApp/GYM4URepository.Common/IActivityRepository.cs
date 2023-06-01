using GYM4U.Common;
using GYM4UModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM4URepository.Common
{
    public interface IActivityRepository
    {
        Task<bool> CreateNewActivity(ActivityModelDTO activityModel);
        Task<List<ActivityModelDTO>> GetAllActivity(Paging paging, Sorting sorting, Filtering filtering);
        Task<ActivityModelDTO> GetActivity(Guid id);
        Task<bool> EditActivity(Guid id, ActivityModelDTO activityModel);
        Task<bool> DeleteActivity(Guid id);
    }
}
