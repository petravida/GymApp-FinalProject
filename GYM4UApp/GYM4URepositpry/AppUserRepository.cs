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
    public class AppUserRepository : IAppUserRepository
    {
        protected Gym4UEntities Context { get; set; }
        public AppUserRepository(Gym4UEntities contex)
        {
            Context = contex;
        }

        public async Task<List<AppUserModelDTO>> GetAllAppUser(Paging paging, Sorting sorting, Filtering filtering)
        {
            try
            {
                List<AppUserModelDTO> appUserList = new List<AppUserModelDTO>();
                List<AppUser> allAppUsers = await Context.AppUser.ToListAsync();
                foreach (var appUser in allAppUsers)
                {
                    appUserList.Add(new AppUserModelDTO()
                    {
                        Id = appUser.Id,
                        FirstName = appUser.FirstName,
                        LastName = appUser.LastName,
                        Sex = appUser.Sex,
                        OIB = appUser.OIB,
                        Email = appUser.Email,

                    });
                }
                return appUserList;
            } catch(Exception e)
            {
                throw e;
            }
            

        }

        public async Task<bool> CreateNewAppUser(AppUserModelDTO appUser)
        {
            appUser.Id = Guid.NewGuid();
            Context.AppUser.Add(new AppUser
            {
                Id = Guid.NewGuid(),
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Sex = appUser.Sex,
                OIB = appUser.OIB,
                Email = appUser.Email

            });

            var numberOfRows = await Context.SaveChangesAsync();

            if (numberOfRows > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<AppUserModelDTO> GetAppUser(Guid id)
        {
            AppUser appUser = new AppUser();
            appUser = await Context.AppUser.Where(a => a.Id == id).FirstOrDefaultAsync();
            AppUserModelDTO findedAppUser = new AppUserModelDTO();
            if (appUser != null)
            {
                findedAppUser.Id = id;
                findedAppUser.FirstName = appUser.FirstName;
                findedAppUser.LastName = appUser.LastName;
                findedAppUser.Sex = appUser.Sex;
                findedAppUser.OIB = appUser.OIB;
                findedAppUser.Email = appUser.Email;

            }
            return findedAppUser;
        }

        public async Task<bool> EditAppUser(Guid id, AppUserModelDTO appUser)
        {
            AppUser editedAppUser = await Context.AppUser.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (editedAppUser != null)
            {
                editedAppUser.FirstName = appUser.FirstName;
                editedAppUser.LastName = appUser.LastName;
                editedAppUser.Sex = appUser.Sex;
                editedAppUser.OIB = appUser.OIB;
                editedAppUser.Email = appUser.Email;

                Context.SaveChanges();
                return true;
            }
            else return false;
        }

        public Task<bool> DeleteAppUser(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}
