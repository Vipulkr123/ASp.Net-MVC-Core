using DemoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDb.Interfaces;

public interface IEmployeeRepository
{
	Task<List<Employee>> GetEmployees();

	Task<bool> AddEmployee(Employee employee);
	Task<Employee> GetEmployee(int id);
    Task<bool> UpdateEmployee(Employee employee);
	Task<bool> DeleteEmployee(int id);
}
