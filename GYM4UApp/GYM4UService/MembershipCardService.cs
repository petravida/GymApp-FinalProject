using GYM4URepository.Common;
using GYM4UService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM4UModel;
using GYM4U.Common;
using GYM4UDAL;

namespace GYM4UService
{
    public class MembershipCardService : IMembershipCardService
    {
        protected IMembershipCardRepository Repository { get; set; }

        public MembershipCardService(IMembershipCardRepository repository)
        {
            Repository = repository;
        }
        public async Task<bool> CreateNewMembershipCard(Guid Id, MembershipCardModelDTO membershipCard)
        {
            bool isAdded = await Repository.CreateNewMembershipCard(Id, membershipCard);
            return isAdded;
        }
    
        public async Task<List<MembershipCardModelDTO>> GetAllMembershipCard(Paging paging, Sorting sorting, Filtering filtering)
        {
            List<MembershipCardModelDTO> membershipCard = await Repository.GetAllMembershipCard(paging, sorting, filtering);

            return membershipCard;
        }

        public async Task<MembershipCardModelDTO> GetMembershipCard(Guid id)
        {
            MembershipCardModelDTO membershipCardModel = await Repository.GetMembershipCard(id);

            return membershipCardModel;
        }

        public async Task<bool> EditMembershipCard(Guid id, MembershipCardModelDTO membershipCard)

        {
            MembershipCardModelDTO findCard = await GetMembershipCard(id);

            if (findCard == null)
            {

                return false;
            }

            MembershipCardModelDTO cardForUpdate = new MembershipCardModelDTO();
            cardForUpdate.CardNumber = membershipCard.CardNumber == default ? findCard.CardNumber : membershipCard.CardNumber;
            cardForUpdate.Expired = membershipCard.Expired == default ? findCard.Expired : membershipCard.Expired;
            cardForUpdate.IsActive = membershipCard.IsActive == default ? findCard.IsActive : membershipCard.IsActive;


            Task<bool> isEdited = Repository.EditMembershipCard(id, cardForUpdate);
            return await isEdited;
        }
        public async Task<bool> DeleteMembershipCard(Guid id)
        {
            MembershipCardModelDTO membershipCardCheck = await Repository.GetMembershipCard(id);
            if (membershipCardCheck == null)
            {
                return false;
            }
            bool isDeleted = await Repository.DeleteMembershipCard(id);
            return isDeleted;
        }

    }
}
