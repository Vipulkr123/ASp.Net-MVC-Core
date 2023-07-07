using DemoDb.DatabaseContext;
using DemoDb.Interfaces;
using DemoModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDb.Repository;

public class EmployeeRepository : IEmployeeRepository
{
	private readonly EmployeeDbContext _employeeDbContext;

	public EmployeeRepository(EmployeeDbContext employeeDbContext)
    {
		_employeeDbContext = employeeDbContext;
    }

    

    public async Task<List<Employee>> GetEmployees()
	{
		List<Employee> employees =  await _employeeDbContext.Employees.ToListAsync();
		return employees;
	}

    public async Task<bool> AddEmployee(Employee employee)
    {
        Employee emp = new Employee()
        {
            Name = employee.Name,
            DOB = employee.DOB,
            Age = employee.Age,
        };
        _employeeDbContext.Add(emp);
        await _employeeDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Employee> GetEmployee(int id)
    {
        Employee? employee = await _employeeDbContext.Employees.FindAsync(id);
        return employee;
    }

    public async Task<bool> UpdateEmployee(Employee employee)
    {
        _employeeDbContext.Entry(employee).State = EntityState.Modified;
        await _employeeDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        Employee employee = await _employeeDbContext.Employees.FindAsync(id);
        _employeeDbContext.Remove(employee);
        await _employeeDbContext.SaveChangesAsync();
        return true;
    }
}
