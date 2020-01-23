using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id=1,Name="Magesh",Email="magesh@gmail.com",Department=Dept.HR},
                new Employee(){Id=2,Name="Janu",Email="Janu@gmail.com",Department=Dept.IT },
                new Employee(){Id=3,Name="Hithu",Email="Hithu@gmail.com",Department=Dept.Payroll },
                new Employee(){Id=4,Name="jasvic",Email="jasvic@gmail.com",Department=Dept.DR },
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
