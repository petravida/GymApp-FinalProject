using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM4U.Common;
using GYM4UCommon;
using GYM4UModel;
using PagedList;

namespace GYM4UService.Common
{
    public interface IMemberService
    {
        Task<bool> CreateNewMember(MemberModelDTO memberModel);
        Task<IPagedList<MemberModelDTO>> GetAllMember(SearchString searchString, Paging paging, Sorting sorting, Filtering filtering);
        Task<MemberModelDTO> GetMember(Guid id);
        Task<bool> EditMember(Guid id, MemberModelDTO memberModel);
        Task<bool> DeleteMember(Guid id);
    }
}
