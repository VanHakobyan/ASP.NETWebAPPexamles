using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebAPI.Models
{
    public class EmployeeRepository : EmployeeWebAPI.Models.IEmployeeRepository
    {
         private List<Employee> _employee = new List<Employee>();
        private int _nextId = 1;
        public EmployeeRepository()
        {
            this.Add(new Employee() { Name = "Raj Beniwal", Designation = "Asst. Project Manager", Address= "Noida" });
            this.Add(new Employee() { Name = "Dev Malhotra", Designation = "Tech Lead", Address = "Banglore" });
            this.Add(new Employee() { Name = "Neelesh Arora", Designation = "System Analyst", Address= "Pune"});
            this.Add(new Employee() { Name = "Samy Verma", Designation = "Project Manager", Address = "Washingtom DC" });
            this.Add(new Employee() { Name = "Ravinder Malik", Designation = "Team Lead", Address = "Gurgaon" });
        }
        public IQueryable<Employee> GetAll()
        {
            return _employee.AsQueryable();
        }
        public Employee Get(int id)
        {
            return _employee.Find(c => c.Id == id);
        }
        public Employee Add(Employee employee)
        {
            employee.Id = _nextId++;
            _employee.Add(employee);
            return employee;
        }
        public void Remove(int id)
        {
            Employee employee = _employee.Find(c => c.Id == id);
            _employee.Remove(employee);
        }
        public bool Update(Employee employee)
        {
            int index = _employee.FindIndex(c => c.Id == employee.Id);
            if (index == -1)
            {
                return false;
            }
            _employee.RemoveAt(index);
            _employee.Add(employee);
            return true;
        }    
    }
}