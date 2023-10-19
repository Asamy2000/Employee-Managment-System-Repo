using AutoMapper;
using MVCAPPBLL.interfaces;
using MVCAPPDAL.Models;
using MVCPL.Helpers;
using MVCPL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCPL.Controllers
{
	[Authorize]
	public class EmployeeController : Controller
	{

		//private readonly IEmployeerepo _employeerepo;
		//private readonly IDepartmentrepo _departmentrepo;
		private readonly IunitOfWork _iunitOfWork;
		private readonly IMapper _mapper;

		public EmployeeController(IunitOfWork iunitOfWork, IMapper mapper)
		{
			//_employeerepo = employeerepo;
			//_departmentrepo = departmentrepo;
			_iunitOfWork = iunitOfWork;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index(string SearchValue)
		{
			IEnumerable<Employee> Employees;

			if (string.IsNullOrEmpty(SearchValue))
				Employees = await _iunitOfWork.Employeerepo.GetAll();
			else
				Employees = _iunitOfWork.Employeerepo.GetEmployessByName(SearchValue);

			var mappedEmps = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeVM>>(Employees);

			return View(mappedEmps);
		}
		//[HttpGet]
		public async Task<IActionResult> Create()
		{
			ViewBag.Departments = await _iunitOfWork.Departmentrepo.GetAll();
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(EmployeeVM empVM)
		{
			if (ModelState.IsValid) //serverSideValidation
			{
				if (empVM.Image is not null)
					empVM.ImageName = DocSettings.UploadFile(empVM.Image, "images");

				var mappedEmp = _mapper.Map<EmployeeVM, Employee>(empVM);
				await _iunitOfWork.Employeerepo.Add(mappedEmp);
				int Count = await _iunitOfWork.Complete();
				if (Count > 0)
					TempData["Message"] = "Employee is created successfuly";

				return RedirectToAction(nameof(Index));
			}
			return View(empVM);
		}

		public async Task<IActionResult> Details(int? id, string viewName = "Details")
		{
			if (id is null)
				return BadRequest();
			var emp = await _iunitOfWork.Employeerepo.Get(id.Value);
			if (emp == null)
				return NotFound();
			var mappedEmp = _mapper.Map<Employee, EmployeeVM>(emp);
			return View(viewName, mappedEmp);
		}

		public async Task<IActionResult> Edit(int? id, bool isFoo)
		{

			///if (id is null)
			///    return BadRequest();
			///var emp = _employeerepo.Get(id.Value);
			///if (emp == null)
			///    return NotFound();
			///return View(emp);
			ViewBag.Departments = await _iunitOfWork.Departmentrepo.GetAll();
			return await Details(id, "Edit");
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit([FromRoute] int id, EmployeeVM employeeVM)
		{
			//for security from hidden input
			if (id != employeeVM.Id)
				return BadRequest();
			if (ModelState.IsValid)
			{
				try
				{
					var mappedEmp = _mapper.Map<EmployeeVM, Employee>(employeeVM);
					_iunitOfWork.Employeerepo.Update(mappedEmp);
					await _iunitOfWork.Complete();
					return RedirectToAction(nameof(Index));
				}
				catch (Exception ex)
				{

					ModelState.AddModelError(string.Empty, ex.Message);

				}
			}
			return View(employeeVM);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			return await Details(id, "Delete");
		}
		[HttpPost]
		public async Task<IActionResult> Delete([FromRoute] int id,EmployeeVM empVM)
		{
			if (id != empVM.Id)
				return BadRequest();
			try
			{
				var mappedEmp = _mapper.Map<EmployeeVM, Employee>(empVM);
				_iunitOfWork.Employeerepo.Delete(mappedEmp);
				int Count = await _iunitOfWork.Complete();
				if (Count > 0 && empVM.ImageName is not null)
				{
					DocSettings.DeleteFile(empVM.ImageName, "images");
				}
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				return View(empVM);
			}

		}
	}
}
