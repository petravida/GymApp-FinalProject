using GYM4URepository.Common;
using GYM4UModel;
using GYM4UService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM4U.Common;

namespace GYM4UService
{
    public class AppUserService : IAppUserService
    {
        protected IAppUserRepository Repository { get; set; }

        public AppUserService(IAppUserRepository repository)
        {
            Repository = repository;
        }
        public async Task<bool> CreateNewAppUser(AppUserModelDTO appUser)
        {
            bool isAdded = await Repository.CreateNewAppUser(appUser);
            return isAdded;

        }
        public async Task<List<AppUserModelDTO>> GetAllAppUser(Paging paging, Sorting sorting, Filtering filtering)
        {
            List<AppUserModelDTO> appUsers = await Repository.GetAllAppUser(paging, sorting, filtering);
            return appUsers;
        }

        public async Task<AppUserModelDTO> GetAppUser(Guid id)
        {
            AppUserModelDTO appUser = await Repository.GetAppUser(id);

            return appUser;
        }

        public async Task<bool> EditAppUser(Guid id, AppUserModelDTO appUser)

        {
            AppUserModelDTO findAppUser = await GetAppUser(id);

            if (findAppUser == null)
            {

                return false;
            }

            AppUserModelDTO appUserForUpdate = new AppUserModelDTO();
            appUserForUpdate.FirstName = appUser.FirstName == default ? findAppUser.FirstName : appUser.FirstName;
            appUserForUpdate.LastName = appUser.LastName == default ? findAppUser.LastName : appUser.LastName;
            appUserForUpdate.Sex = appUser.Sex == default ? findAppUser.Sex : appUser.Sex;
            appUserForUpdate.OIB = appUser.OIB == default ? findAppUser.OIB : appUser.OIB;
            appUserForUpdate.Email = appUser.Email == default ? findAppUser.Email : appUser.Email;
            appUserForUpdate.Password = appUser.Password == default ? findAppUser.Password : appUser.Password;


            Task<bool> isEdited = Repository.EditAppUser(id, appUserForUpdate);
            return await isEdited;
        }
        public async Task<bool> DeleteAppUser(Guid id)
        {
            AppUserModelDTO appUserCheck = await Repository.GetAppUser(id);
            if (appUserCheck == null)
            {
                return false;
            }
            bool isDeleted = await Repository.DeleteAppUser(id);
            return isDeleted;
        }
    }
}
