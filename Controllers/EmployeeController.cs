using System.Data;
using EmployeeApp.Data;
using EmployeeApp.Models;
using EmployeeApp.Repositries.Interfaces;
using EmployeeApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders.Physical;

namespace EmployeeApp.Controllers;

public class EmployeeController : Controller
{
    public EmployeeController(
        IEmployeeService employeeService,
        IEmployeeRepository employeeRepository

    )
    {
        _employeeService = employeeService;
        _employeeRepository = employeeRepository;
    }

    public IEmployeeService _employeeService { get; }
    public IEmployeeRepository _employeeRepository { get; }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(EmployeeVm vm)
    {
        if (ModelState.IsValid)
        {
            var dto = new EmployeeDto()
            {
                EmpName = vm.EmpName,
                Designation = vm.Designation

            };



            _employeeService.Create(dto);
            return RedirectToAction("Index");
        }


        return View(vm);
    }

    public IActionResult GetTodos()
    {
        var employees = _employeeRepository.GetAll();
        return View(employees);
    }

    [HttpPost]
    public IActionResult Update(Guid id, EmployeeDto dto)


    {
        var employee = Database.Employees.FirstOrDefault(t => t.EmpId == id);
        employee.EmpId = dto.EmpId;
        employee.EmpName = dto.EmpName;
        employee.Designation = dto.Designation;
        employee.Address = dto.Address;
        return RedirectToAction("GetEmployee");

    }


    public IActionResult Update(Guid id)
    {
        var employee = Database.Employees.FirstOrDefault(t => t.EmpId == id);
        return View(employee);

    }

}


