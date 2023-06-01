using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM4U.Common;
using GYM4UModel;


namespace GYM4UService.Common
{
    public interface IMembershipTypeService
    {
        Task<bool> CreateNewMembershipType(MembershipTypeModelDTO membershipTypeModel);
        Task<List<MembershipTypeModelDTO>> GetAllMembershipType();
        Task<MembershipTypeModelDTO> GetMembershipType(Guid id);
        Task<bool> EditMembershipType(Guid id, MembershipTypeModelDTO membershipTypeModel);
        Task<bool> DeleteMembershipType(Guid id);

    }
}
