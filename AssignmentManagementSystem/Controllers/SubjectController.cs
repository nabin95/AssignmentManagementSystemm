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
    public class SubjectController : Controller
    {
        SubjectService subjectService = new SubjectService();
        public ActionResult Index(string searchTerm, int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            SubjectListingModel model = new SubjectListingModel();
            model.SearchTerm = searchTerm;
            model.Subjects = subjectService.SearchSubject(searchTerm, page.Value, recordSize);
            var totalRecord = subjectService.SearchSubjectCount(searchTerm);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);
        }

      
        public ActionResult Create(int? ID)
        {
            SubjectActionModel model = new SubjectActionModel();
            if (ID.HasValue)
            {
                var subject = subjectService.GetSubjectById(ID.Value);
                model.SubjectId = subject.SubjectId;
                model.SubjectName = subject.SubjectName;
                
            }
            return PartialView("_Create", model);
        }
        [HttpPost]
        public JsonResult Create(SubjectActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;

            if (model.SubjectId > 0)
            {
                var subject = subjectService.GetSubjectById(model.SubjectId);
                subject.SubjectId = model.SubjectId;
                subject.SubjectName = model.SubjectName;
                result = subjectService.UpdateSubject(subject);

            }
            else
            {
                SubjectModel subject = new SubjectModel();

                subject.SubjectName = model.SubjectName;
                result = subjectService.SaveSubject(subject);

            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Subject " };
            }

            return json;
        }

        // GET: Faculty/Edit/5

        // GET: Faculty/Delete/5
        public ActionResult Delete(int ID)
        {
            SubjectActionModel model = new SubjectActionModel();
            var subject = subjectService.GetSubjectById(ID);
            model.SubjectId = subject.SubjectId;
            return PartialView("_Delete", model);
        }
     
        [HttpPost]
        public JsonResult Delete(SubjectActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var subject = subjectService.GetSubjectById(model.SubjectId);

            result = subjectService.DeleteSubject(subject);
            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Subject" };
            }

            return json;
        }
    }
}