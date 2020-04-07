
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LeaveManagement.Contracts;
using LeaveManagement.Models.ViewModels;
using System.Collections.Generic;
using LeaveManagement.Data;
using System.Linq;
using System;

namespace LeaveManagement.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repository;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var leaveTypes = _repository.GetAll();
            if (leaveTypes != null)
            {
                var mapped = MapToLeaveTypeVMList(leaveTypes);
                return View(mapped);
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            if (!_repository.IsExist(id))
            {
                return NotFound();
            }
            return View(MapToLeaveTypeVM(_repository.GetById(id)));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM entity)
        {
            if (entity == null || !ModelState.IsValid)
            {
                return View(entity);
            }

            try
            {
                entity.DateCreated = DateTime.Now;
                if (!_repository.Add(MapToLeaveType(entity)))
                {
                    ModelState.AddModelError("", "Something went wrong while saving the leave type.");
                    return View(entity);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong while saving the leave type.");
                return View();
            }
        }

        // GET: LeaveTypes/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repository.IsExist(id))
            {
                return NotFound();
            }
            return View(MapToLeaveTypeVM(_repository.GetById(id)));
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LeaveTypeVM entity)
        {
            if (id==0 || entity == null || !ModelState.IsValid)
            {
                return View(entity);
            }

            if (!_repository.IsExist(id))
            {
                return NotFound();
            }

            try
            {
                if (!_repository.Update(id,MapToLeaveType(entity)))
                {
                    ModelState.AddModelError("", "Something went wrong while updating the leave type.");
                    return View(entity);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong while updating the leave type.");
                return View();
            }
        }

        // GET: LeaveTypes/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity==null)
            {
                return NotFound();
            }

            if (!_repository.Remove(entity))
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: LeaveTypes/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, LeaveTypeVM entity)
        //{
        //    if (id == null || entity == null || ModelState.IsValid)
        //    {
        //        return View(entity);
        //    }

        //    if (!_repository.IsExist(id))
        //    {
        //        return NotFound();
        //    }
        //    try
        //    {
              
        //        if (!_repository.Remove(MapToLeaveType(entity)))
        //        {
        //            ModelState.AddModelError("", "Something went wrong while updating the leave type.");
        //            return View(entity);
        //        }

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        ModelState.AddModelError("", "Something went wrong while updating the leave type.");
        //        return View(entity);
        //    }
        //}

        [NonAction]
        private LeaveType MapToLeaveType(LeaveTypeVM entity)
        {
            return _mapper.Map<LeaveType>(entity);
        }
        [NonAction]
        private LeaveTypeVM MapToLeaveTypeVM(LeaveType entity)
        {
            return _mapper.Map<LeaveTypeVM>(entity);
        }

        [NonAction]
        private IEnumerable<LeaveTypeVM> MapToLeaveTypeVMList(IEnumerable<LeaveType> entity)
        {
            return _mapper.Map<IEnumerable<LeaveType>, IEnumerable<LeaveTypeVM>>(entity);
        }

    }
}