using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM4UModel.Common
{
    public interface IAppUserModel
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Sex { get; set; }
        string OIB { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        //Guid CreatedByUserId { get; set; }
        //Guid UpdatedByUserId { get; set; }
        int IsActive { get; set; }
        Guid RoleId { get; set; }
    }
}
