using EmployeeApp.Data;
using EmployeeApp.Models;
using EmployeeApp.Repositries.Interfaces;

namespace EmployeeApp.Repositries;

public class EmployeeRepository : IEmployeeRepository
{
    public List<EmployeeDto> GetAll()
    {
        return Database.Employees.ToList();
    }

    public EmployeeDto GetbyId(Guid id)
    {
        return Database.Employees.FirstOrDefault(t => t.EmpId == id);
    }
}