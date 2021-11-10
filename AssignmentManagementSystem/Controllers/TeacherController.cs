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
    public class TeacherController : Controller
    {
        // GET: Teacher

        TeacherService teacherService = new TeacherService();
        FacultyService facultyService = new FacultyService();
        public ActionResult Index(string searchTerm, int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            TeacherListingModel model = new TeacherListingModel();
            model.SearchTerm = searchTerm;
            model.Teachers = teacherService.SearchTeacher(searchTerm, page.Value, recordSize);
            var totalRecord = teacherService.SearchTeacherCount(searchTerm);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);
        }


        public ActionResult Create(int? ID)
        {
            TeacherActionModel model = new TeacherActionModel();
            if (ID.HasValue)
            {
                var teacher = teacherService.GetTeacherById(ID.Value);
                model.TeacherId = teacher.TeacherId;
                model.TeacherName = teacher.TeacherName;
                model.Address = teacher.Address;
                model.ContactNumber = teacher.ContactNumber;
                model.Email = teacher.Email;
                model.FacultyId = teacher.FacultyId;


            }
            model.Faculty = facultyService.GetAllFaculty();
            return PartialView("_Create", model);
        }
        [HttpPost]
        public JsonResult Create(TeacherActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;

            if (model.TeacherId > 0)
            {
                var teacher = teacherService.GetTeacherById(model.TeacherId);
                teacher.TeacherId = model.TeacherId;
                teacher.TeacherName = model.TeacherName;
                teacher.Address = model.Address;
                teacher.ContactNumber = model.ContactNumber;
                teacher.Email = model.Email;
                teacher.FacultyId = model.FacultyId;

                result = teacherService.UpdateTeacher(teacher);

            }
            else
            {
                TeacherModel teacher = new TeacherModel();
                teacher.Address = model.Address;
                teacher.ContactNumber = model.ContactNumber;
                teacher.Email = model.Email;
                teacher.FacultyId = model.FacultyId;


                teacher.TeacherName = model.TeacherName;
                result = teacherService.SaveTeacher(teacher);

            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Teacher " };
            }

            return json;
        }


        public ActionResult Delete(int ID)
        {
            TeacherActionModel model = new TeacherActionModel();
            var teacher = teacherService.GetTeacherById(ID);
            model.TeacherId = teacher.TeacherId;
            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(TeacherActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var teacher = teacherService.GetTeacherById(model.TeacherId);

            result = teacherService.DeleteTeacher(teacher);
            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Teacher" };
            }

            return json;
        }
    }
}