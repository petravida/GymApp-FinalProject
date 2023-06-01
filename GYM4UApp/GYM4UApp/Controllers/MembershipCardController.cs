using GYM4U.Common;
using GYM4UApp.Models;
using GYM4UModel;
using GYM4UService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GYM4UApp.Controllers
{
    public class MembershipCardController : Controller
    {
        protected IMembershipCardService Service { get; set; }

        public MembershipCardController(IMembershipCardService service)
        {
            Service = service;
        }
        [HttpGet]
        //[Route ("/Member/MembershipCard")]
        public async Task<ActionResult> GetAllMembershipCard(Paging paging, Sorting sorting, Filtering filtering)
        {
            try
            {
                List<MembershipCardModelDTO> listOfCards = await Service.GetAllMembershipCard(paging, sorting, filtering);
                List<MembershipCardView> cardMappedList = new List<MembershipCardView>();
                if (listOfCards == null)
                {
                    return View();
                }
                else
                {
                    foreach (MembershipCardModelDTO card in listOfCards)
                    {
                        MembershipCardView cardList = new MembershipCardView
                        {
                            Id = card.Id,
                            CardNumber = card.CardNumber,
                            Expired = card.Expired,
                            MembershipTypeId = card.MembershipTypeId


                        };
                        cardMappedList.Add(cardList);
                    }
                    return View(cardMappedList);

                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }
        public async Task<ActionResult> SelectTypeAsync()
        {

            List<MembershipTypeModelDTO> types = new List<MembershipTypeModelDTO>();

            types.Add(new MembershipTypeModelDTO { Name = "Silver" });

            types.Add(new MembershipTypeModelDTO { Name = "Golden" });

            types.Add(new MembershipTypeModelDTO { Name = "Premium" });

            types.Add(new MembershipTypeModelDTO { Name = "Test" });
            types.Add(new MembershipTypeModelDTO { Name = "Petra" });

            ViewBag.Create = types;

            return View();

        }
        [HttpGet]
        public ActionResult CreateMC()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateMC(Guid id, MembershipCardPostView newCard)
        {
            try
            {
                MembershipCardModelDTO insertedCard = new MembershipCardModelDTO();
                //insertedCard.Id = id;
                insertedCard.CardNumber = newCard.CardNumber;
                insertedCard.Expired = newCard.Expired;
                insertedCard.UpdatedByUserId = newCard.UpdatedByUserId;
                insertedCard.CreatedByUserId = newCard.CreatedByUserId;
                insertedCard.IsActive = newCard.IsActive;
                insertedCard.MembershipTypeId = newCard.MembershipTypeId;
                bool isInserted = await Service.CreateNewMembershipCard(id, insertedCard);
                if (isInserted == true)
                {
                    return RedirectToAction("GetAllMemberbershipCard");
                }
                else
                {
                    return View();
                }
            }

            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public async Task<ActionResult> Edit(MembershipCardEditView cardForEdit)
        {
            try
            {
                MembershipCardModelDTO editCard = new MembershipCardModelDTO();
                editCard.Id = cardForEdit.Id;
                editCard.CardNumber = cardForEdit.CardNumber;
                editCard.Expired = cardForEdit.Expired;
                editCard.MembershipTypeId = cardForEdit.MembershipTypeId;
                bool isUpdated = await Service.EditMembershipCard(cardForEdit.Id, editCard);

                if (isUpdated == false)
                {
                    return View();
                }

                return View(cardForEdit);

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpGet]
        //[Route("/{Member}/{DetailsMC}/{id}")]
        public async Task<ActionResult> DetailsMS(Guid id)
        {
            try
            {
                MembershipCardModelDTO getCard = await Service.GetMembershipCard(id);
                if (getCard == null)
                {
                    return View();
                }
                MembershipCardView card = new MembershipCardView
                {
                    Id = id,
                    CardNumber = getCard.CardNumber,
                    Expired = getCard.Expired,
                    MembershipTypeId = getCard.MembershipTypeId
                };

                return View(card);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public ActionResult GoToType(Guid id)
        {

            return RedirectToAction("DetailsTC", "MembershipType", new { id });
        }
        public ActionResult BackToList()
        {
            return RedirectToAction("GetAllMember", "Member");
        }


    }
}