using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM4U.Common;
using GYM4UModel;

namespace GYM4URepository.Common
{
    public interface IRoleRepository
    {
        Task<bool> CreateNewRole(RoleModelDTO roleModel);
        Task<List<RoleModelDTO>> GetAllRole(Paging paging, Sorting sorting, Filtering filtering);
        Task<RoleModelDTO> GetRole(Guid id);
        Task<bool> EditRole(Guid id, RoleModelDTO roleModel);
        Task<bool> DeleteRole(Guid id);
    }
}
