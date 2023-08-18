using HR_Management.UI.Contracts;
using HR_Management.UI.Models;
using HR_Management.UI.Services.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.UI.Controllers
{
    [Authorize]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypes();
            return View(leaveTypes);
        }

        // GET: LeaveTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leaveType);
        }

        #region Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVM createLeaveType)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(createLeaveType);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", response.ValidationErrors);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }
            return View(createLeaveType);
        }

        #endregion

        #region Edit

        public async Task<ActionResult> Edit(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leaveType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeVM leaveType)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveType(id,leaveType);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", response.ValidationErrors);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }
            return View(leaveType);
        }

        #endregion



        public async Task<ActionResult> Delete(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leaveType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(LeaveTypeVM leaveTypeVm)
        {
            try
            {
                var response = await _leaveTypeService.DeleteLeaveType(leaveTypeVm.Id);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", response.ValidationErrors);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }

            return BadRequest();
        }
    }
}
