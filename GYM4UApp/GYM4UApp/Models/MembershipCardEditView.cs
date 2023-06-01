using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYM4UApp.Models
{
    public class MembershipCardEditView
    {
        public Guid Id { get; set; }
        public int CardNumber { get; set; }
        public DateTime Expired { get; set; }
        public Guid MembershipTypeId { get; set; }  
    }
}