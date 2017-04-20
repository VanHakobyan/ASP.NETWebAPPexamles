using System;
namespace EmployeeWebAPI.Models
{
    interface IEmployeeRepository
    {
        Employee Add(Employee employee);
        Employee Get(int id);
        System.Linq.IQueryable<Employee> GetAll();
        void Remove(int id);
        bool Update(Employee employee);
    }
}
