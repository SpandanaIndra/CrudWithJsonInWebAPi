using CrudWithJsonInWebAPi.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Newtonsoft.Json;

namespace CrudWithJsonInWebAPi.Repository
{
    public class EmployeeJson : IEmployee
    {
        private readonly string _jsonFilePath;
        private List<Employee> _items;
      List<Employee> employeeList;
        public EmployeeJson(IOptions<JsonFilePathOptions> options)
        {
            _jsonFilePath = options.Value.JsonFilePath;
            LoadData();
        }

    

        private void LoadData()
        {
            if (File.Exists(_jsonFilePath))
            {
                string jsonData = File.ReadAllText(_jsonFilePath);
                employeeList = JsonConvert.DeserializeObject<List<Employee>>(jsonData);
            }
            else
            {
                employeeList = new List<Employee>();
            }
        }


        private void SaveData(List<Employee> emp)
        {
            string jsonData = JsonConvert.SerializeObject(emp, Formatting.Indented);

            File.WriteAllText(_jsonFilePath, jsonData);
        }
        public int AddEmployee(Employee emp)
        {

            // Load the existing data
            LoadData();

            // Add the new employee to the list
            employeeList.Add(emp);

            // Save the updated list to the JSON file
            SaveData(employeeList);

            return employeeList.Count;
        }

        public void DeleteEmployee(int id)
        {
            int index = employeeList.FindIndex(item => item.Id == id);

            if (index != -1)
            {
                employeeList.RemoveAt(index);
                SaveData(employeeList);
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            return employeeList.Find(item => item.Id == id);
        }

        public Employee UpdateEmployee(int id, Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            int index = employeeList.FindIndex(i => i.Id == id);

            if (index != -1)
            {
                emp.Id = id;
               employeeList[index] = emp;
                SaveData(employeeList);
            }

            return emp;
        }
    }
}
