using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYM4UApp.Models
{
    public class MembershipCardView
    {
        public Guid Id { get; set; }
        public int CardNumber { get; set; }
        public DateTime Expired { get; set; }
        public Guid MembershipTypeId { get; set; }

        //public DateTime DateCreated { get; set; }
        //public DateTime DateUpdated { get; set; }
        //public Guid CreatedByUserId { get; set; }
        //public Guid UpdatedByUserId { get; set; }
        //public bool IsActive { get; set; }
    }
}