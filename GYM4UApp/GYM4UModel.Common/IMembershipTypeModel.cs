using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM4UModel.Common
{
    public interface IMembershipTypeModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        int NumberOfActivities { get; set; }
        int TimeLimit { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        Guid CreatedByUserId { get; set; }
        Guid UpdatedByUserId { get; set; }
        bool IsActive { get; set; }
    }
}
