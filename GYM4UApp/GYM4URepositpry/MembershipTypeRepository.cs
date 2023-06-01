using GYM4U.Common;
using GYM4UDAL;
using GYM4UModel;
using GYM4URepository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace GYM4URepositpry
{
    public class MembershipTypeRepository : IMembershipTypeRepository
    {
        protected Gym4UEntities Context { get; set; }
        public MembershipTypeRepository(Gym4UEntities contex)
        {
            Context = contex;
        }
        public async Task<bool> CreateNewMembershipType(MembershipTypeModelDTO membershipType)
        {
            membershipType.Id = Guid.NewGuid();
            Context.MembershipType.Add(new MembershipType
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Name = membershipType.Name,
                Price = membershipType.Price,
                NumberOfActivities = membershipType.NumberOfActivities,
                TimeLimit = membershipType.TimeLimit,
                CreatedByUserId = membershipType.CreatedByUserId,
                UpdatedByUserId = membershipType.UpdatedByUserId,
                IsActive = membershipType.IsActive
            });

            var numberOfRows = await Context.SaveChangesAsync();

            if (numberOfRows > 0)
            {
                return true;
            }
            return false;
        }

        public Task<bool> DeleteMembershipType(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditMembershipType(Guid id, MembershipTypeModelDTO membershipType)
        {
            MembershipType editedMembershipType = await Context.MembershipType.Where(mt => mt.Id == id).FirstOrDefaultAsync();
            if (editedMembershipType != null)
            {
                editedMembershipType.Name = membershipType.Name;
                editedMembershipType.Price = membershipType.Price;
                editedMembershipType.NumberOfActivities = membershipType.NumberOfActivities;
                editedMembershipType.TimeLimit = membershipType.TimeLimit;


                Context.SaveChanges();
                return true;
            }
            else return false;
        }

        public async Task<List<MembershipTypeModelDTO>> GetAllMembershipType()
        {
            List<MembershipTypeModelDTO> membershipTypeList = new List<MembershipTypeModelDTO>();
            List<MembershipType> allMembershipType = await Context.MembershipType.ToListAsync();
            foreach (var membershipTypes in allMembershipType)
            {
                membershipTypeList.Add(new MembershipTypeModelDTO()
                {
                    Id = membershipTypes.Id,
                    Name = membershipTypes.Name,
                    Price = membershipTypes.Price,
                    NumberOfActivities = membershipTypes.NumberOfActivities,
                    TimeLimit = membershipTypes.TimeLimit,
                });
            }
            return membershipTypeList;
        }

        public async Task<MembershipTypeModelDTO> GetMembershipType(Guid id)
        {
            MembershipType membershipType = new MembershipType();
            membershipType = await Context.MembershipType.Where(mt => mt.Id == id).FirstOrDefaultAsync();
            MembershipTypeModelDTO findedType = new MembershipTypeModelDTO();
            if (membershipType != null)
            {
                findedType.Id = id;
                findedType.Name = membershipType.Name;
                findedType.Price = membershipType.Price;
                findedType.NumberOfActivities = membershipType.NumberOfActivities;
                findedType.TimeLimit = membershipType.TimeLimit;

            }
            return findedType;
        }
    }
}
