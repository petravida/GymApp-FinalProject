using System;
using GYM4UModel.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM4UModel
{
    public class AppUserModelDTO : IAppUserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string OIB { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        //public Guid CreatedByUserId { get; set; }
        //public Guid UpdatedByUserId { get; set; }
        public int IsActive { get; set; }
        public Guid RoleId { get; set; }
    }
}
