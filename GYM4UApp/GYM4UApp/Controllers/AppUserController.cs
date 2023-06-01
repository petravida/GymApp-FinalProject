using Autofac.Core;
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
using System.Web.UI.WebControls;

namespace GYM4UApp.Controllers
{
    public class AppUserController : Controller
    {
        protected IAppUserService Service { get; set; }

        public AppUserController(IAppUserService service)
        {
            Service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAppUser(Paging paging, Sorting sorting, Filtering filtering)
        {
            try
            {
                List<AppUserModelDTO> listOfAppUsers = await Service.GetAllAppUser(paging, sorting, filtering);
                List<AppUserView> appUserMappedList = new List<AppUserView>();
                if (listOfAppUsers == null)
                {
                    return View();
                }
                else
                {
                    foreach (AppUserModelDTO appUser in listOfAppUsers)
                    {
                        AppUserView appUserList = new AppUserView
                        {
                            Id = appUser.Id,
                            FirstName = appUser.FirstName,
                            LastName = appUser.LastName,
                            Sex = appUser.Sex,
                            OIB = appUser.OIB,
                            Email = appUser.Email

                        };
                        appUserMappedList.Add(appUserList);
                    }
                    return View(appUserMappedList);

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
        public async Task<ActionResult> Create(AppUserPostView newAppUser)
        {
            try
            {
                AppUserModelDTO insertedAppUser = new AppUserModelDTO();
                insertedAppUser.FirstName = newAppUser.FirstName;
                insertedAppUser.LastName = newAppUser.FirstName;
                insertedAppUser.OIB = newAppUser.OIB;
                insertedAppUser.Sex = newAppUser.Sex;
                insertedAppUser.Email = newAppUser.Email;
                insertedAppUser.Password = newAppUser.Password;

                bool isInserted = await Service.CreateNewAppUser(insertedAppUser);
                if (isInserted == true)
                {
                    return RedirectToAction("GetAllAppUser");
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
        public async Task<ActionResult> Edit(AppUserEditView appUserForEdit)
        {
            try
            {
                AppUserModelDTO editAppUser = new AppUserModelDTO();
                editAppUser.Id = appUserForEdit.Id;
                editAppUser.FirstName = appUserForEdit.FirstName;
                editAppUser.LastName = appUserForEdit.LastName;
                editAppUser.Sex = appUserForEdit.Sex;
                editAppUser.OIB = appUserForEdit.OIB;
                editAppUser.Email = appUserForEdit.Email;
                editAppUser.Password = appUserForEdit.Password;

                bool isUpdated = await Service.EditAppUser(appUserForEdit.Id, editAppUser);

                if (isUpdated == false)
                {
                    return View();
                }

                return View(appUserForEdit);

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
                AppUserModelDTO getAppUser = await Service.GetAppUser(id);
                if (getAppUser == null)
                {
                    return View();
                }
                AppUserView appUser = new AppUserView
                {
                    Id = id,
                    FirstName = getAppUser.FirstName,
                    LastName = getAppUser.LastName,
                    Sex = getAppUser.Sex,
                    OIB = getAppUser.OIB,
                    Email = getAppUser.Email
                };

                return View(appUser);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
    
}