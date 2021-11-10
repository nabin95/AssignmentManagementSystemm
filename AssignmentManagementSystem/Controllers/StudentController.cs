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
    public class StudentController : Controller
    {

        StudentService studentService = new StudentService();
        DepartmentService departmentService = new DepartmentService();
        public ActionResult Index(string searchTerm, int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            StudentListingModel model = new StudentListingModel();
            model.SearchTerm = searchTerm;
            model.Students = studentService.SearchStudent(searchTerm, page.Value, recordSize);
            var totalRecord = studentService.SearchStudentCount(searchTerm);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);
        }


        public ActionResult Create(int? ID)
        {
            StudentActionModel model = new StudentActionModel();
            if (ID.HasValue)
            {
                var student = studentService.GetStudentById(ID.Value);
                model.StudentId = student.StudentId;
                model.StudentName = student.StudentName;
                model.Address = student.Address;
                model.ContactNumber = student.ContactNumber;
                model.Email = student.Email;
                model.DepartmentId = student.DepartmentId;
                

            }
            model.Departments = departmentService.GetAllDepartment();
            return PartialView("_Create", model);
        }
        [HttpPost]
        public JsonResult Create(StudentActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;

            if (model.StudentId > 0)
            {
                var student = studentService.GetStudentById(model.StudentId);
                student.StudentId = model.StudentId;
                student.StudentName = model.StudentName;
                student.Address = model.Address;
                student.ContactNumber = model.ContactNumber;
                student.Email = model.Email;
                student.DepartmentId = model.DepartmentId;
                
                result = studentService.UpdateStudent(student);

            }
            else
            {
                StudentModel student = new StudentModel();
                student.Address = model.Address;
                student.ContactNumber = model.ContactNumber;
                student.Email = model.Email;
                student.DepartmentId = model.DepartmentId;
              

                student.StudentName = model.StudentName;
                result = studentService.SaveStudent(student);

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
            StudentActionModel model = new StudentActionModel();
            var student = studentService.GetStudentById(ID);
            model.StudentId = student.StudentId;
            return PartialView("_Delete", model);
        }
       
        [HttpPost]
        public JsonResult Delete(StudentActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var student = studentService.GetStudentById(model.StudentId);

            result = studentService.DeleteStudent(student);
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