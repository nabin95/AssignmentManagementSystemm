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
    public class AssignmentStatusController : Controller
    {
        AssignmentStatusService assignmentStatusService = new AssignmentStatusService();
        public ActionResult Index(string searchTerm, int? page)
        {
            int recordSize = 3;
            page = page ?? 1;
            AssignmentStatusListingModel model = new AssignmentStatusListingModel();
            model.SearchTerm = searchTerm;
            model.AssignmentStatus = assignmentStatusService.SearchAssignmentStatus(searchTerm, page.Value, recordSize);
            var totalRecord = assignmentStatusService.SearchAssignmentStatusCount(searchTerm);
            model.Pager = new Pager(totalRecord, page, recordSize);
            return View(model);
        }

       
        public ActionResult Create(int? ID)
        {
            AssignmentStatusActionModel model = new AssignmentStatusActionModel();
            if (ID.HasValue)
            {
                var assignmentStatus = assignmentStatusService.GetAssginmentStatusById(ID.Value);
                model.AssigmentStatusId = assignmentStatus.AssigmentStatusId;
                model.AssigmentStatus = assignmentStatus.AssigmentStatus;
                //model. = assignment.Name;
            }
            return PartialView("_Create", model);
        }
        [HttpPost]
        public JsonResult Create(AssignmentStatusActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;

            if (model.AssigmentStatusId > 0)
            {
                var assignmentStatus = assignmentStatusService.GetAssginmentStatusById(model.AssigmentStatusId);
                assignmentStatus.AssigmentStatusId = model.AssigmentStatusId;
                assignmentStatus.AssigmentStatus = model.AssigmentStatus;
                result = assignmentStatusService.UpdateAssignmentStatus(assignmentStatus);

            }
            else
            {
                AssignmentStatusModel assignmentStatus = new AssignmentStatusModel();

                assignmentStatus.AssigmentStatus = model.AssigmentStatus;
                result = assignmentStatusService.SaveAssignmentStatus(assignmentStatus);

            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add AssignmentStatus " };
            }

            return json;
        }

      
        public ActionResult Delete(int ID)
        {
            AssignmentStatusActionModel model = new AssignmentStatusActionModel();
            var assignmentStatus = assignmentStatusService.GetAssginmentStatusById(ID);
            model.AssigmentStatusId = assignmentStatus.AssigmentStatusId;
            return PartialView("_Delete", model);
        }
     
        [HttpPost]
        public JsonResult Delete(AssignmentStatusActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            var assignmentStatus = assignmentStatusService.GetAssginmentStatusById(model.AssigmentStatusId);

            result = assignmentStatusService.DeleteAssignmentStatus(assignmentStatus);
            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add AssignmentStatus" };
            }

            return json;
        }
    }
}