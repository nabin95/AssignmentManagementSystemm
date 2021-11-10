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
    public class AssignmentController : Controller
    {
        // GET: Assignment
        AssignmentService assignmentService = new AssignmentService();
        StudentService studentService = new StudentService();
        AssignmentMarkService assignmnentMarkService = new AssignmentMarkService();
        AssignmentStatusService assignmentStatusService = new AssignmentStatusService();
        TeacherService teacherService = new TeacherService();
        SubjectService subjectService = new SubjectService();
       
        public ActionResult Index(string searchTerm, int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            AssignmentListingModel model = new AssignmentListingModel();
            model.SearchTerm = searchTerm;
            model.Assignments = assignmentService.SearchAssignment(searchTerm, page.Value, recordSize);
            var totalRecord = assignmentService.SearchAssigmentCount(searchTerm);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);
            
           
        }


        // GET: Assignment/Create
        public ActionResult Create(int? ID)
        {
            AssignmentActionModel model = new AssignmentActionModel();
            if (ID.HasValue)
            {
                var assignment = assignmentService.GetAssignmentById(ID.Value);
                model.AssignmentId = assignment.AssignmentId;
                model.StudentId = assignment.StudentId;
                model.SubjectId = assignment.SubjectId;
                model.TeacherId = assignment.TeacherId;
                
               
            }
            model.Students = studentService.GetAllStudent();
            model.Subjects = subjectService.GetAllSubject();
            model.Teachers = teacherService.GetAllTeacher();
            model.AssignmentMarks = assignmnentMarkService.GetAllAssignmentMarks();
            model.AssignmentStatus = assignmentStatusService.GetAllAssignmentStatus();
            return PartialView("_Create", model);
        }

        // POST: Assignment/Create
        [HttpPost]
        public JsonResult Create(AssignmentActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;

            if (model.AssignmentId > 0)
            {
                var assignment = assignmentService.GetAssignmentById(model.TeacherId);
                assignment.AssignmentId = model.AssignmentId;
                assignment.StudentId = model.StudentId;
                assignment.SubjectId = model.SubjectId;
                assignment.TeacherId = model.TeacherId;
                assignment.AssigmentMarksId = model.AssigmentMarksId;
                assignment.AssigmentStatusId = model.AssigmentStatusId;

                result = assignmentService.UpdateAssignment(assignment);

            }
            else
            {
                AssignmentModel assignment = new AssignmentModel();
                assignment.StudentId = model.StudentId;
                assignment.SubjectId = model.SubjectId;
                assignment.TeacherId = model.TeacherId;
                assignment.AssigmentMarksId = model.AssigmentMarksId;
                assignment.AssigmentStatusId = model.AssigmentStatusId;


                
                result = assignmentService.SaveAssignment(assignment);

            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Assignment " };
            }

            return json;
        }



        public ActionResult Delete(int ID)
        {
            AssignmentActionModel model = new AssignmentActionModel();
            var assignment = assignmentService.GetAssignmentById(ID);
            model.AssignmentId = assignment.AssignmentId;
            return PartialView("_Delete", model);
        }


        [HttpPost]
        public JsonResult Delete(AssignmentActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var assignment = assignmentService.GetAssignmentById(model.AssignmentId);

            result = assignmentService.DeleteAssignment(assignment);
            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Assignment" };
            }

            return json;
        }
    }
}
