using CrudWithJsonInWebAPi.Models;

namespace CrudWithJsonInWebAPi.Repository
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();
       Employee GetEmployeeById(int id);
        int AddEmployee(Employee emp);
        Employee UpdateEmployee(int id,Employee emp);
        void DeleteEmployee(int id);
    }
}
