using CrudWithJsonInWebAPi.Repository;
using Microsoft.AspNetCore.Mvc;
using CrudWithJsonInWebAPi.Models;
using System.Collections.Generic;

namespace CrudWithJsonInWebAPi.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _dataService;

        public EmployeesController(IEmployee dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dataService.GetAllEmployees();
        }
        [HttpPost]
        public int AddEmployee(Employee emp)
        {
             
              int i=  _dataService.AddEmployee(emp);
            return i;
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> GetItem(int id)
        {
            var item = _dataService.GetEmployeeById(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            _dataService.DeleteEmployee(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateItem(int id, Employee item)
        {
            var updatedItem = _dataService.UpdateEmployee(id, item);
            if (updatedItem == null)
            {
                return NotFound();
            }

            return updatedItem;
        }

    }
}
