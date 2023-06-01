using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM4U.Common;
using GYM4UModel;


namespace GYM4UService.Common
{
    public interface IAppUserService
    {
        Task<bool> CreateNewAppUser(AppUserModelDTO appUserModel);
        Task<List<AppUserModelDTO>> GetAllAppUser(Paging paging, Sorting sorting, Filtering filtering);
        Task<AppUserModelDTO> GetAppUser(Guid id);
        Task<bool> EditAppUser(Guid id, AppUserModelDTO appUserModel);
        Task<bool> DeleteAppUser(Guid id);
    }
}
