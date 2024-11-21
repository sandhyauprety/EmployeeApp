using EmployeeApp.Models;

namespace EmployeeApp.Services.Interfaces;

public interface IEmployeeService
{
    void Create(EmployeeDto dto); 
    void Update(EmployeeDto dto); 

}