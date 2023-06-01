using GYM4U.Common;
using GYM4UModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM4URepository.Common
{
    public interface IAppUserRepository
    {
        Task<bool> CreateNewAppUser(AppUserModelDTO appUserModel);
        Task<List<AppUserModelDTO>> GetAllAppUser(Paging paging, Sorting sorting, Filtering filtering);
        Task<AppUserModelDTO> GetAppUser(Guid id);
        Task<bool> EditAppUser(Guid id, AppUserModelDTO appUserModel);
        Task<bool> DeleteAppUser(Guid id);
    }
}
