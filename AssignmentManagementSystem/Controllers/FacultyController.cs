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
    public class FacultyController : Controller
    {
        // GET: Faculty
        FacultyService facultyService = new FacultyService();
        public ActionResult Index(string searchTerm, int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            FacultyListingModel model = new FacultyListingModel();
            model.SearchTerm = searchTerm;
            model.Faculties = facultyService.SearchFaculty(searchTerm, page.Value, recordSize);
            var totalRecord = facultyService.SearchFacultyCount(searchTerm);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);
        }

        // GET: Faculty/Details/5
        //public ActionResult Details(int? ID)
        //{
           
    
        //}

        // GET: Faculty/Create
        public ActionResult Create(int? ID)
        {
            FacultyActionModel model = new FacultyActionModel();
            if (ID.HasValue)
            {
                var faculty = facultyService.GetFacultyById(ID.Value);
                model.FacultyId = faculty.FacultyId;
                model.FacultyName = faculty.FacultyName;
                //model. = assignment.Name;
            }
            return PartialView("_Create", model);
        }
        [HttpPost]
        public JsonResult Create(FacultyActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;

            if (model.FacultyId > 0)
            {
                var faculty = facultyService.GetFacultyById(model.FacultyId);
               faculty.FacultyId = model.FacultyId;
                faculty.FacultyName = model.FacultyName;
                result = facultyService.UpdateFaculty(faculty);

            }
            else
            {
                FacultyModel faculty = new FacultyModel();

                faculty.FacultyName = model.FacultyName;
                result = facultyService.SaveFaculty(faculty);

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

        // GET: Faculty/Edit/5
       
        // GET: Faculty/Delete/5
        public ActionResult Delete(int ID)
        {
            FacultyActionModel model = new FacultyActionModel();
            var faculty = facultyService.GetFacultyById(ID);
            model.FacultyId = faculty.FacultyId;
            return PartialView("_Delete", model);
        }
        // POST: Faculty/Delete/5
        [HttpPost]
        public JsonResult Delete(FacultyActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var faculty = facultyService.GetFacultyById(model.FacultyId);

            result = facultyService.DeleteFaculty(faculty);
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
