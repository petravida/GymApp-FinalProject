using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using GYM4U.Common;
using GYM4UApp.Models;
using GYM4UCommon;
using GYM4UDAL;
using PagedList;
using GYM4UModel;
using GYM4UService.Common;

namespace GYM4UApp.Controllers
{
    //[RoutePrefix("member")]
    public class MemberController : Controller
    {
        protected IMemberService Service { get; set; }

        public MemberController(IMemberService service)
        {
            Service = service;
        }

        public async Task<ActionResult> GetAllMember(string searchString, Filtering filtering, int pageNumber = 1, int pageSize = 5, string sortBy = "Id", string sortOrder = "Desc")
        {
           
            try
            
            {

                if (ViewBag.SearchString != searchString)
                {
                    ViewBag.SearchString = searchString;

                }
                ViewBag.SortOrder = sortOrder;
                ViewBag.SortBy = sortBy;
                List<MemberView> membersMappedList = new List<MemberView>();
                SearchString search = new SearchString
                {
                    SearchQueary = searchString,
                };
                Sorting sorting = new Sorting
                {
                    SortBy = sortBy,
                    SortOrder = sortOrder
                };
                Paging paging = new Paging()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                IPagedList<MemberModelDTO> pagedMember = await Service.GetAllMember(search, paging, sorting, filtering);
                ViewBag.SortBy = sortBy;
                ViewBag.SortOrder = sortOrder == "asc" ? "desc" : "asc";
                if (pagedMember == null)
                {
                    return View();
                }
                return View(pagedMember);

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
        public async Task<ActionResult> Create(MemberPostView newMember)
        {
            try
            {
                MemberModelDTO insertedMember = new MemberModelDTO();
                insertedMember.FirstName = newMember.FirstName;
                insertedMember.LastName = newMember.LastName;
                insertedMember.Sex = newMember.Sex;
                insertedMember.DOB = newMember.DOB;
                insertedMember.OIB = newMember.OIB;
                insertedMember.Phone = newMember.Phone;
                insertedMember.CreatedByUserId = newMember.CreatedByUserId;
                insertedMember.UpdatedByUserId = newMember.UpdatedByUserId;
                insertedMember.IsActive = newMember.IsActive;
                insertedMember.AppUser = newMember.AppUserId;
                bool isInserted = await Service.CreateNewMember(insertedMember);
                if (isInserted == true)
                {
                    return RedirectToAction("GetAllMember");
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
        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                MemberModelDTO getMemeber = await Service.GetMember(id);
                if (getMemeber == null)
                {
                    return View();
                }
                MemberView member = new MemberView
                {
                    Id = id,
                    FirstName = getMemeber.FirstName,
                    LastName = getMemeber.LastName,
                    Sex = getMemeber.Sex,
                    DOB = getMemeber.DOB,
                    OIB = getMemeber.OIB,
                    Phone = getMemeber.Phone,
                    IsActive = getMemeber.IsActive
                    

                };

                return View(member);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public async Task<ActionResult> Edit(MemberEditView memberForEdit)
        {
            try
            {
                MemberModelDTO editMember = new MemberModelDTO();
                editMember.Id = memberForEdit.Id;
                editMember.FirstName = memberForEdit.FirstName;
                editMember.LastName = memberForEdit.LastName;
                editMember.Sex = memberForEdit.Sex;
                editMember.DOB = memberForEdit.DOB;
                editMember.OIB = memberForEdit.OIB;
                editMember.Phone = memberForEdit.Phone;
                editMember.IsActive = memberForEdit.IsActive;

                bool isUpdated = await Service.EditMember(editMember.Id, editMember);

                if (isUpdated == false)
                {
                    return View();
                }

                return View(memberForEdit);

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                bool isDeleted = await Service.DeleteMember(id);

                if (isDeleted == false)
                {
                    return View();
                }
                else
                {

                    return RedirectToAction("GetAllMember");
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }

        public ActionResult GoToMembershipCard(Guid id)
        {

            return RedirectToAction("DetailsMS", "MembershipCard", new {id});
        }
        public ActionResult CreateNewCard(Guid memberId)
        {
            return RedirectToAction("CreateMC", "MembershipCard", new { memberId });
        }

        public ActionResult SeeAllActivities()
        {
            return RedirectToAction("GetAllActivity", "Activity");
        }

        //private Gym4UEntities db = new Gym4UEntities();

        //// GET: member/{id}
        //[HttpGet]
        //[Route("{id:int}")]
        //public ActionResult GetMember(int id)
        //{
        //    var member = db.Member.Find(id);
        //    if (member == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(member);
        //}
    }
}
