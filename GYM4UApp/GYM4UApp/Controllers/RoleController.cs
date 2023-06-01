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
    public class RoleController : Controller
    {
        protected IRoleService Service { get; set; }

        public RoleController(IRoleService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRole(Paging paging, Sorting sorting, Filtering filtering)
        {
            try
            {
                List<RoleModelDTO> listOfRoles = await Service.GetAllRole(paging, sorting, filtering);
                List<RoleView> roleMappedList = new List<RoleView>();
                if (listOfRoles == null)
                {
                    return View();
                }
                else
                {
                    foreach (RoleModelDTO role in listOfRoles)
                    {
                        RoleView roleList = new RoleView
                        {
                            Id = role.Id,
                            Name = role.Name,

                        };
                        roleMappedList.Add(roleList);
                    }
                    return View(roleMappedList);

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
        public async Task<ActionResult> Create(RoleEditView newActivity)
        {
            throw new NotImplementedException();

        }
        public async Task<ActionResult> Edit(RoleEditView roleForEdit)
        {
            try
            {
                RoleModelDTO editRole = new RoleModelDTO();
                editRole.Id = roleForEdit.Id;
                editRole.Name = roleForEdit.Name;
                bool isUpdated = await Service.EditRole(roleForEdit.Id, editRole);

                if (isUpdated == false)
                {
                    return View();
                }

                return View(roleForEdit);

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
                RoleModelDTO getRole = await Service.GetRole(id);
                if (getRole == null)
                {
                    return View();
                }
                RoleView role = new RoleView
                {
                    Id = id,
                    Name = getRole.Name,
                };

                return View(role);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}