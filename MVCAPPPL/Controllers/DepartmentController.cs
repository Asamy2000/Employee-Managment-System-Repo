using AutoMapper;
using MVCAPPBLL.interfaces;
using MVCAPPDAL.Models;
using MVCPL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCAPPPL.Controllers
{
	public class DepartmentController : Controller
	{
		//private readonly IDepartmentrepo _departmentrepo;
		private readonly IunitOfWork _iunitOfWork;
		private readonly IMapper _mapper;

		public DepartmentController(IunitOfWork iunitOfWork, IMapper mapper )
		{
			//_departmentrepo = departmentrepo;
			_iunitOfWork = iunitOfWork;
			_mapper = mapper;
		}
		public async Task<IActionResult> Index()
		{
			IEnumerable<Department> Departments;
			Departments = await _iunitOfWork.Departmentrepo.GetAll();
			var mappedDepts = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentVM>>(Departments);
			return View(mappedDepts);
		}
		//[HttpGet]
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(DepartmentVM deptVM)
		{
			if (ModelState.IsValid) //serverSideValidation
			{
				var mappedDept = _mapper.Map<DepartmentVM, Department>(deptVM);
				await _iunitOfWork.Departmentrepo.Add(mappedDept);
				int Count = await _iunitOfWork.Complete();
				if (Count > 0)
					TempData["Message"] = "Department is created successfuly";

				return RedirectToAction(nameof(Index));
			}
			return View(deptVM);
		}

		public async Task<IActionResult> Details(int? id, string viewName = "Details")
		{
			if (id is null)
				return BadRequest();
			var dept = await _iunitOfWork.Departmentrepo.Get(id.Value);
			if (dept == null)
				return NotFound();
			var mappedDept = _mapper.Map<Department, DepartmentVM>(dept);
			return View(viewName, mappedDept);
		}

		public async Task<IActionResult> Edit(int? id, bool isFoo)
		{

			///if (id is null)
			///    return BadRequest();
			///var dept = _departmentrepo.Get(id.Value);
			///if (dept == null)
			///    return NotFound();
			///return View(dept);
			return await Details(id, "Edit");
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit([FromRoute] int id, DepartmentVM departmentVM)
		{
			//for security from hidden input
			if (id != departmentVM.Id)
				return BadRequest();
			if (ModelState.IsValid)
			{
				try
				{
					var mappedDept = _mapper.Map<DepartmentVM, Department>(departmentVM);
					_iunitOfWork.Departmentrepo.Update(mappedDept);
					await _iunitOfWork.Complete();
					return RedirectToAction(nameof(Index));
				}
				catch (Exception ex)
				{

					ModelState.AddModelError(string.Empty, ex.Message);

				}
			}
			return View(departmentVM);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			return await Details(id, "Delete");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(DepartmentVM deptVM)
		{
			try
			{
				var mappedDept = _mapper.Map<DepartmentVM, Department>(deptVM);
				_iunitOfWork.Departmentrepo.Delete(mappedDept);
				await _iunitOfWork.Complete();
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{

				ModelState.AddModelError(string.Empty, ex.Message);
				return View(deptVM);
			}

		}




    }
}
