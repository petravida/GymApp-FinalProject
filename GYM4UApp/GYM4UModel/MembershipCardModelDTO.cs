using System;
using GYM4UModel.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM4UModel
{
    public class MembershipCardModelDTO : IMembershipCardModel
    {
        public Guid Id { get; set; }
        public int CardNumber { get; set; }
        public DateTime Expired { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid UpdatedByUserId { get; set; }
        public bool IsActive { get; set; }
        public Guid MembershipTypeId { get; set; }
    }
}
