using AssignmentManagementSystem.Models;
using AssignmentManagementSystem.Services;
using AssignmentManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManagementSystem.Controllers
{
    [AllowAnonymous]
    public class DepartmentController : Controller
    {
        
        DepartmentService departmentService = new DepartmentService();
        public ActionResult Index(string searchTerm, int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            DepartmentListingModel model = new DepartmentListingModel();
            model.SearchTerm = searchTerm;
            model.Departments = departmentService.SearchDepartment(searchTerm, page.Value, recordSize);
            var totalRecord = departmentService.SearchDepartmentCount(searchTerm);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);
        }

       
        public ActionResult Create(int? ID)
        {
            DepartmentActionModel model = new DepartmentActionModel();
            if (ID.HasValue)
            {
                var department = departmentService.GetDepartmentById(ID.Value);
                model.DepartmentId = department.DepartmentId;
                model.DepartmentName = department.DepartmentName;
                
            }
            return PartialView("_Create", model);
        }
        [HttpPost]
        public JsonResult Create(DepartmentActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;

            if (model.DepartmentId > 0)
            {
                var department = departmentService.GetDepartmentById(model.DepartmentId);
                department.DepartmentId = model.DepartmentId;
                department.DepartmentName = model.DepartmentName;
                result = departmentService.UpdateDepartment(department);

            }
            else
            {
                DepartmentModel department = new DepartmentModel();

                department.DepartmentName = model.DepartmentName;
                result = departmentService.SaveDepartment(department);

            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Faculty " };
            }

            return json;
        }

       
        public ActionResult Delete(int ID)
        {
            DepartmentActionModel model = new DepartmentActionModel();
            var department = departmentService.GetDepartmentById(ID);
            model.DepartmentId = department.DepartmentId;
            return PartialView("_Delete", model);
        }
        // POST: Faculty/Delete/5
        [HttpPost]
        public JsonResult Delete(DepartmentActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var department = departmentService.GetDepartmentById(model.DepartmentId);

            result = departmentService.DeleteDepartment(department);
            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Faculty" };
            }

            return json;
        }
    }
}
