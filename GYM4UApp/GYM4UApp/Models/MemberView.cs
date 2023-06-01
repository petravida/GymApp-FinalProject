using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYM4UApp.Models
{
    public class MemberView
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime DOB { get; set; }   
        public string OIB { get; set; }
        public string Phone { get; set; }
        //public DateTime DateCreated { get; set; }
        //public DateTime DateUpdated { get; set; }
        //public Guid CreatedByUserId { get; set; }
        //public Guid UpdatedByUserId { get; set; }
        public bool IsActive { get; set; }
        //public Guid AppUserId { get; set; }
    }
}