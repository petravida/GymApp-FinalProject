using GYM4U.Common;
using GYM4UDAL;
using GYM4UModel;
using GYM4URepository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace GYM4URepositpry
{
    public class RoleRepository : IRoleRepository
    {
        protected Gym4UEntities Context { get; set; }
        public RoleRepository(Gym4UEntities contex)
        {
            Context = contex;
        }
        public async Task<bool> CreateNewRole(RoleModelDTO role)
        {
            throw new NotImplementedException();

        }

        public Task<bool> DeleteRole(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditRole(Guid id, RoleModelDTO role)
        {
            Role editedRole = await Context.Role.Where(r => r.Id == id).FirstOrDefaultAsync();
            if (editedRole != null)
            {
                editedRole.Name = role.Name;

                Context.SaveChanges();
                return true;
            }
            else return false;

        }
        public async Task<List<RoleModelDTO>> GetAllRole(Paging paging, Sorting sorting, Filtering filtering)
        {
            List<RoleModelDTO> roleList = new List<RoleModelDTO>();
            List<Role> allRoles = await Context.Role.ToListAsync();
            foreach (var roles in allRoles)
            {
                roleList.Add(new RoleModelDTO()
                {
                    Id = roles.Id,
                    Name = roles.Name,
                });
            }
            return roleList;
        }

        public async Task<RoleModelDTO> GetRole(Guid id)
        {
            Role role = new Role();
            role = await Context.Role.Where(r => r.Id == id).FirstOrDefaultAsync();
            RoleModelDTO findedRole = new RoleModelDTO();
            if (role != null)
            {
                findedRole.Id = id;
                findedRole.Name = role.Name;

            }
            return findedRole;
        }
    }
}
