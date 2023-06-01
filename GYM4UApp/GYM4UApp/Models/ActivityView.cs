using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYM4UApp.Models
{
    public class ActivityView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
    //    public Guid ActivityId { get; set; }
    //    public Guid MembershipCardId { get; set; }
    //    public DateTime DateCreated { get; set; }
    //    public DateTime DateUpdated { get; set; }
    //    public Guid CreatedByUserId { get; set; }
    //    public Guid UpdatedByUserId { get; set; }
        public bool IsActive { get; set; }
    }
}