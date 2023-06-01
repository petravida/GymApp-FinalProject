using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM4UModel.Common
{
    public interface IMembershipCardModel
    {
        Guid Id { get; set; }
        int CardNumber { get; set; }
        DateTime Expired { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        Guid CreatedByUserId { get; set; }
        Guid UpdatedByUserId { get; set; }
        bool IsActive { get; set; }
        Guid MembershipTypeId { get; set; }
    }
}
