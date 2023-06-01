using GYM4URepository.Common;
using GYM4UService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM4UModel;
using GYM4U.Common;

namespace GYM4UService
{
    public class RoleService : IRoleService
    {
        protected IRoleRepository Repository { get; set; }

        public RoleService(IRoleRepository repository)
        {
            Repository = repository;
        }
        public async Task<bool> CreateNewRole(RoleModelDTO role)
        {
            throw new NotImplementedException();


        }
        public async Task<List<RoleModelDTO>> GetAllRole(Paging paging, Sorting sorting, Filtering filtering)
        {
            List<RoleModelDTO> role = await Repository.GetAllRole(paging, sorting, filtering);

            return role;
        }

        public async Task<RoleModelDTO> GetRole(Guid id)
        {
            RoleModelDTO roleModel = await Repository.GetRole(id);

            return roleModel;
        }

        public async Task<bool> EditRole(Guid id, RoleModelDTO role)

        {
            RoleModelDTO findRole = await GetRole(id);

            if (findRole == null)
            {

                return false;
            }

            RoleModelDTO roleForUpdate = new RoleModelDTO();
            roleForUpdate.Name = role.Name == default ? findRole.Name : role.Name;


            Task<bool> isEdited = Repository.EditRole(id, roleForUpdate);
            return await isEdited;
        }
        public async Task<bool> DeleteRole(Guid id)
        {
            RoleModelDTO roleCheck = await Repository.GetRole(id);
            if (roleCheck == null)
            {
                return false;
            }
            bool isDeleted = await Repository.DeleteRole(id);
            return isDeleted;
        }
    }
}
