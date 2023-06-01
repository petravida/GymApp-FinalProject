using GYM4URepository.Common;
using GYM4UService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM4UModel;
using GYM4U.Common;

namespace GYM4UService
{
    public class MembershipTypeService : IMembershipTypeService
    {
        protected IMembershipTypeRepository Repository { get; set; }

        public MembershipTypeService(IMembershipTypeRepository repository)
        {
            Repository = repository;
        }
        public async Task<bool> CreateNewMembershipType(MembershipTypeModelDTO membershipTypeModel)
        {
            bool isAdded = await Repository.CreateNewMembershipType(membershipTypeModel);
            return isAdded;

        }
        public async Task<List<MembershipTypeModelDTO>> GetAllMembershipType()
        {
            List<MembershipTypeModelDTO> membershipType = await Repository.GetAllMembershipType();

            return membershipType;
        }

        public async Task<MembershipTypeModelDTO> GetMembershipType(Guid id)
        {
            MembershipTypeModelDTO membershipTypeModel = await Repository.GetMembershipType(id);

            return membershipTypeModel;
        }

        public async Task<bool> EditMembershipType(Guid id, MembershipTypeModelDTO membershipType)

        {
            MembershipTypeModelDTO findType = await GetMembershipType(id);

            if (findType == null)
            {

                return false;
            }

            MembershipTypeModelDTO typeForUpdate = new MembershipTypeModelDTO();
            typeForUpdate.Name = membershipType.Name == default ? findType.Name : membershipType.Name;
            typeForUpdate.Price = membershipType.Price == default ? findType.Price : membershipType.Price;
            typeForUpdate.NumberOfActivities = membershipType.NumberOfActivities == default ? findType.NumberOfActivities : membershipType.NumberOfActivities;
            typeForUpdate.TimeLimit = membershipType.TimeLimit == default ? findType.TimeLimit : membershipType.TimeLimit;


            Task<bool> isEdited = Repository.EditMembershipType(id, typeForUpdate);
            return await isEdited;
        }
        public async Task<bool> DeleteMembershipType(Guid id)
        {
            MembershipTypeModelDTO membershipTypeCheck = await Repository.GetMembershipType(id);
            if(membershipTypeCheck == null)
            {
                return false;
            }
            bool isDeleted = await Repository.DeleteMembershipType(id);
            return isDeleted;
        }

    }
}
