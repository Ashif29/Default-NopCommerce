using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Employee;
using Nop.Core;
using Nop.Data;
using Nop.Core.Caching;
using Nop.Services.Catalog;

namespace Nop.Services.Employees;
public class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> _employeeRepository;
    public EmployeeService(IRepository<Employee> employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public virtual async Task<IPagedList<Employee>> GetAllEmployeesAsync(string employeeName, string employeeFatherName,
        int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var unsortedEmployees = await _employeeRepository.GetAllAsync(async query =>
        {
            if (!string.IsNullOrWhiteSpace(employeeName))
                query = query.Where(c => c.Name.Contains(employeeName));
            if (!string.IsNullOrWhiteSpace(employeeFatherName))
                query = query.Where(c => c.Name.Contains(employeeFatherName));

            return query;
        });

        //sort categories
        //var sortedEmployees = SortEmployeesForTree(unsortedEmployees).ToList();

        //paging
        return new PagedList<Employee>(unsortedEmployees, pageIndex, pageSize);
    }

    //public virtual async Task DeleteEmployeeAsync(Employee employee)
    //{
    //    await _employeeRepository.DeleteAsync(employee);
    //}

    //public virtual async Task<Employee> GetEmployeeByIdAsync(int id)
    //{
    //    return await _employeeRepository.GetByIdAsync(id);
    //}

    //public virtual async Task InsertEmployeeAsync(Employee employee)
    //{
    //    await _employeeRepository.InsertAsync(employee);
    //}

    //public Task<IPagedList<Employee>> SearchEmployeeAsync(string name, int statusId, int pageIndex = 0, int pageSize = int.MaxValue)
    //{
    //    throw new NotImplementedException();
    //}

    //public virtual async Task UpdateEmployeeAsync(Employee employee)
    //{
    //    await _employeeRepository.UpdateAsync(employee);
    //}
}
