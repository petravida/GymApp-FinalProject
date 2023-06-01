using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM4U.Common;
using GYM4UModel;


namespace GYM4UService.Common
{
    public interface IActivityService
    {
        Task<bool> CreateNewActivity(ActivityModelDTO activityModel);
        Task<List<ActivityModelDTO>> GetAllActivity(Paging paging, Sorting sorting, Filtering filtering);
        Task<ActivityModelDTO> GetActivity(Guid id);
        Task<bool> EditActivity(Guid id, ActivityModelDTO activityModel);
        Task<bool> DeleteActivity(Guid id);
    }
}
