using GYM4U.Common;
using GYM4UApp.Models;
using GYM4UModel;
using GYM4UService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace GYM4UApp.Controllers
{

    public class ActivityController : Controller
    {
        protected IActivityService Service { get; set; }

        public ActivityController(IActivityService service)
        {
            Service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllActivity(Paging paging, Sorting sorting, Filtering filtering)
        {
            try
            {
                List<ActivityModelDTO> listOfActivities = await Service.GetAllActivity(paging, sorting, filtering);
                List<ActivityView> activityMappedList = new List<ActivityView>();
                if (listOfActivities == null)
                {
                    return View();
                }
                else
                {
                    foreach (ActivityModelDTO activity in listOfActivities)
                    {
                        ActivityView activityList = new ActivityView
                        {
                            Id = activity.Id,
                            Name = activity.Name,
                            Duration = activity.Duration,
                            //IsActive = activity.IsActive
                        };
                        activityMappedList.Add(activityList);
                    }
                    return View(activityMappedList);

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
        public async Task<ActionResult> Create(ActivityPostView newActivity)
        {
            try
            {
                ActivityModelDTO insertedActivity = new ActivityModelDTO();
                insertedActivity.Name = newActivity.Name;
                insertedActivity.Duration = newActivity.Duration;
                insertedActivity.UpdatedByUserId = newActivity.UpdatedByUserId;
                insertedActivity.CreatedByUserId = newActivity.CreatedByUserId;
                insertedActivity.IsActive = newActivity.IsActive;
                bool isInserted = await Service.CreateNewActivity(insertedActivity);
                if (isInserted == true)
                {
                    return RedirectToAction("GetAllActivity");
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
        public async Task<ActionResult> Edit(ActivityEditView activityForEdit)
        {
            try
            {
                ActivityModelDTO editActivity = new ActivityModelDTO();
                editActivity.Id = activityForEdit.Id;
                editActivity.Name = activityForEdit.Name;
                editActivity.Duration = activityForEdit.Duration;
                editActivity.IsActive = activityForEdit.IsActive;
                bool isUpdated = await Service.EditActivity(activityForEdit.Id, editActivity);

                if (isUpdated == false)
                {
                    return View();
                }

                return View(activityForEdit);

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
                ActivityModelDTO getActivity = await Service.GetActivity(id);
                if (getActivity == null)
                {
                    return View();
                }
                ActivityView activity = new ActivityView
                {
                    Id = id,
                    Name = getActivity.Name,
                    Duration = getActivity.Duration,
                    IsActive = getActivity.IsActive
                };

                return View(activity);
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
