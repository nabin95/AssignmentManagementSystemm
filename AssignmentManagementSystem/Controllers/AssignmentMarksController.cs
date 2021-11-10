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
    public class AssignmentMarksController : Controller
    {
        AssignmentMarkService assignmentMarksService = new AssignmentMarkService();
        public ActionResult Index(string searchTerm, int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            AssignmentMarkListingModel model = new AssignmentMarkListingModel();
            model.SearchTerm = searchTerm;
            model.AssignmentMarks = assignmentMarksService.SearchAssignmentMarks(searchTerm, page.Value, recordSize);
            var totalRecord = assignmentMarksService.SearchAssignmentMarksCount(searchTerm);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);
        }

      
        public ActionResult Create(int? ID)
        {
            AssignmentMarkActionModel model = new AssignmentMarkActionModel();
            if (ID.HasValue)
            {
                var assignmentMarks = assignmentMarksService.GetAssignmentMarksById(ID.Value);
                model.AssigmentMarksId = assignmentMarks.AssigmentMarksId;
                model.AssigmentMarks = assignmentMarks.AssigmentMarks;
                //model. = assignment.Name;
            }
            return PartialView("_Create", model);
        }
        [HttpPost]
        public JsonResult Create(AssignmentMarkActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;

            if (model.AssigmentMarksId> 0)
            {
                var assignmentMarks = assignmentMarksService.GetAssignmentMarksById(model.AssigmentMarksId);
                assignmentMarks.AssigmentMarksId = model.AssigmentMarksId;
                assignmentMarks.AssigmentMarks = model.AssigmentMarks;
                result = assignmentMarksService.UpdateAssignmentMarks(assignmentMarks);

            }
            else
            {
                AssignmentMarksModel assignmentMarks = new AssignmentMarksModel();

                assignmentMarks.AssigmentMarks = model.AssigmentMarks;
                result = assignmentMarksService.SaveAssignmentMarks(assignmentMarks);

            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Marks " };
            }

            return json;
        }

   
        public ActionResult Delete(int ID)
        {
            AssignmentMarkActionModel model = new AssignmentMarkActionModel();
            var assignmentMarks = assignmentMarksService.GetAssignmentMarksById(ID);
            model.AssigmentMarksId = assignmentMarks.AssigmentMarksId;
            return PartialView("_Delete", model);
        }
      
        [HttpPost]
        public JsonResult Delete(AssignmentMarkActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var assignmentMarks = assignmentMarksService.GetAssignmentMarksById(model.AssigmentMarksId);

            result = assignmentMarksService.DeleteAssignmentMarks(assignmentMarks);
            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add AssignmentMarks" };
            }

            return json;
        }
    }
}