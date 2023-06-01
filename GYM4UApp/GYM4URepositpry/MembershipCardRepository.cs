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
using System.Web.UI.WebControls.WebParts;

namespace GYM4URepositpry
{
    public class MembershipCardRepository : IMembershipCardRepository
    {
        protected Gym4UEntities Context { get; set; }
        public MembershipCardRepository(Gym4UEntities contex)
        {
            Context = contex;
        }
        public async Task<bool> CreateNewMembershipCard(Guid Id, MembershipCardModelDTO membershipCard)
        {
            Member neddedId = await Context.Member.Where(m => m.Id == Id).FirstOrDefaultAsync();

            membershipCard.DateCreated = DateTime.Now;
            membershipCard.DateUpdated = DateTime.Now;
            Context.MembershipCard.Add(new MembershipCard
            {
                Id = Id,
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                CardNumber = membershipCard.CardNumber,
                Expired = membershipCard.Expired,
                CreatedByUserId = membershipCard.CreatedByUserId,
                UpdatedByUserId = membershipCard.UpdatedByUserId,
                IsActive = membershipCard.IsActive,
                MembershipTypeId = membershipCard.MembershipTypeId
               
            });

            var numberOfRows = await Context.SaveChangesAsync();

            if (numberOfRows > 0)
            {
                return true;
            }
            return false;
        }

        public Task<bool> DeleteMembershipCard(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditMembershipCard(Guid id, MembershipCardModelDTO membershipCard)
        {
            MembershipCard editedCard = await Context.MembershipCard.Where(mc => mc.Id == id).FirstOrDefaultAsync();
            if (editedCard != null)
            {
                editedCard.CardNumber = membershipCard.CardNumber;
                editedCard.Expired = membershipCard.Expired;
                editedCard.MembershipTypeId = membershipCard.MembershipTypeId;


                Context.SaveChanges();
                return true;
            }
            else return false;
        }

        public async Task<List<MembershipCardModelDTO>> GetAllMembershipCard(Paging paging, Sorting sorting, Filtering filtering)
        {
            List<MembershipCardModelDTO> cardList = new List<MembershipCardModelDTO>();
            List<MembershipCard> allCards = await Context.MembershipCard.ToListAsync();
            foreach (var cards in allCards)
            {
                cardList.Add(new MembershipCardModelDTO()
                {
                    Id = cards.Id,
                    CardNumber = cards.CardNumber,
                    Expired= cards.Expired,
                    MembershipTypeId = cards.MembershipTypeId
                    
                });
            }
            return cardList;
        }

        public async Task<MembershipCardModelDTO> GetMembershipCard(Guid id)
        {
            MembershipCard card = new MembershipCard();
            card = await Context.MembershipCard.Where(mc => mc.Id == id).FirstOrDefaultAsync();
            MembershipCardModelDTO findedCard = new MembershipCardModelDTO();
            if (card != null)
            {
                findedCard.Id = id;
                findedCard.CardNumber = card.CardNumber;
                findedCard.Expired = card.Expired;
                findedCard.MembershipTypeId = card.MembershipTypeId;

            }
            return findedCard;
        }
    }
}
