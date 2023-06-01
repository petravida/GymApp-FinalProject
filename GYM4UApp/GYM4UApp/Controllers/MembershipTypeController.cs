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
    public class MembershipTypeController : Controller
    {
        protected IMembershipTypeService Service { get; set; }

        public MembershipTypeController(IMembershipTypeService service)
        {
            Service = service;
        }

        public MembershipTypeController()
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMembershipType()
        {
            try
            {
                List<MembershipTypeModelDTO> listOfMembershipType = await Service.GetAllMembershipType();
                List<MembershipTypeView> typeMappedList = new List<MembershipTypeView>();
                if (listOfMembershipType == null)
                {
                    return View();
                }
                else
                {
                    foreach (MembershipTypeModelDTO membershipType in listOfMembershipType)
                    {
                        MembershipTypeView typeList = new MembershipTypeView
                        {
                            Id = membershipType.Id,
                            Name = membershipType.Name,
                            Price = membershipType.Price,
                            NumberOfActivities = membershipType.NumberOfActivities,
                            TimeLimit = membershipType.TimeLimit

                        };
                        typeMappedList.Add(typeList);
                    }
                    return View(typeMappedList);

                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(MembershipTypePostView newType)
        {
            try
            {
                MembershipTypeModelDTO insertedType = new MembershipTypeModelDTO();
                insertedType.Name = newType.Name;
                insertedType.Price = newType.Price;
                insertedType.NumberOfActivities = newType.NumberOfActivities;
                insertedType.TimeLimit = newType.TimeLimit;
                insertedType.CreatedByUserId = newType.CreatedByUserId;
                insertedType.UpdatedByUserId = newType.UpdatedByUserId;
                insertedType.IsActive = newType.IsActive;
                bool isInserted = await Service.CreateNewMembershipType(insertedType);
                if (isInserted == true)
                {
                    return RedirectToAction("GetAllMembershipType");
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
        public async Task<ActionResult> Edit(MembershipTypeEditView typeForEdit)
        {
            try
            {
                MembershipTypeModelDTO editType = new MembershipTypeModelDTO();
                editType.Id = typeForEdit.Id;
                editType.Name = typeForEdit.Name;
                editType.Price = typeForEdit.Price;
                editType.NumberOfActivities = typeForEdit.NumberOfActivities;
                editType.TimeLimit = typeForEdit.TimeLimit;
                bool isUpdated = await Service.EditMembershipType(typeForEdit.Id, editType);

                if (isUpdated == false)
                {
                    return View();
                }

                return View(typeForEdit);

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public async Task<ActionResult> DetailsTC(Guid id)
        {
            try
            {
                MembershipTypeModelDTO getType = await Service.GetMembershipType(id);
                if (getType == null)
                {
                    return View();
                }
                MembershipTypeView type = new MembershipTypeView
                {
                    Id = id,
                    Name = getType.Name,
                    Price = getType.Price,
                    NumberOfActivities = getType.NumberOfActivities,
                    TimeLimit = getType.TimeLimit,
                };

                return View(type);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public ActionResult BackToList()
        {
            return RedirectToAction("GetAllMember", "Member");
        }
    }
}