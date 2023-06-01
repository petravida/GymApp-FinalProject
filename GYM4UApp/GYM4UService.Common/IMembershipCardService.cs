using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM4U.Common;
using GYM4UModel;


namespace GYM4UService.Common
{
    public interface IMembershipCardService
    {
        Task<bool> CreateNewMembershipCard(Guid Id, MembershipCardModelDTO membershipCard);
        Task<List<MembershipCardModelDTO>> GetAllMembershipCard(Paging paging, Sorting sorting, Filtering filtering);
        Task<MembershipCardModelDTO> GetMembershipCard(Guid id);
        Task<bool> EditMembershipCard(Guid id, MembershipCardModelDTO membershipCard);
        Task<bool> DeleteMembershipCard(Guid id);
    }
}
