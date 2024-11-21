using EmployeeApp.Models;

namespace EmployeeApp.Repositries.Interfaces;

public interface IEmployeeRepository
{ 
    List<EmployeeDto>GetAll();
    

}