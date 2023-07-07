using DemoDb.Interfaces;
using DemoDb.Repository;
using DemoModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Demo.Controllers
{
	public class EmployeesController : Controller
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeesController(IEmployeeRepository employeeRepository)
        {
			_employeeRepository = employeeRepository;

		}
        public async Task<IActionResult> Index()
		{
			List<Employee> employees = await _employeeRepository.GetEmployees();
			return View(employees);
		}

		[HttpGet]
		public Task<IActionResult> Create()
		{
			return Task.FromResult<IActionResult>(View());
		}

		[HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
			if(ModelState.IsValid)
			{
				bool IsEmpAdded = await _employeeRepository.AddEmployee(employee);
				ViewBag.EmployeeAdded = IsEmpAdded;
				return RedirectToAction("Index");
			}
            return View();
        }

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
            Employee employee = await _employeeRepository.GetEmployee(id);
            
            return View(employee);
		}

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                bool IsUpdated = await _employeeRepository.UpdateEmployee(employee);
                ViewBag.EmployeeUpdated = IsUpdated;
                return RedirectToAction("Index");
            }
            return View(employee);
        }

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
            Employee employee = await _employeeRepository.GetEmployee(id);
            return View(employee);
		}

        public async Task<IActionResult> Delete(int id)
        {
            bool IsDeleted = await _employeeRepository.DeleteEmployee(id);
            ViewBag.EmployeeDeleted = IsDeleted;
            return RedirectToAction("Index");
        }
    }
}
