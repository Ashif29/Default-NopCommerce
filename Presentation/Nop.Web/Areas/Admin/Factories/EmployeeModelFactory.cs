using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Employee;
using Nop.Services.Employees;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Areas.Admin.Models.Employees;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories;

public class EmployeeModelFactory : IEmployeeModelFactory
{

    private readonly IEmployeeService _employeeService;

    public EmployeeModelFactory
    (
        IEmployeeService employeeService
    )
    {
        _employeeService = employeeService;
    }

    public virtual async Task<EmployeeSearchModel> PrepareEmployeeSearchModelAsync(EmployeeSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(searchModel);

        //prepare page parameters
        searchModel.SetGridPageSize();

        return searchModel;
    }

    public virtual async Task<EmployeeListModel> PrepareEmployeeListModelAsync(EmployeeSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(searchModel);
        //get Employees
        var employees = await _employeeService.GetAllEmployeesAsync(
            employeeName: searchModel.SearchEmployeeName,
            employeeFatherName: searchModel.SearchEmployeeFatherName,
            pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

        //prepare grid model
        var model = await new EmployeeListModel().PrepareToGridAsync(searchModel, employees, () =>
        {
            return employees.SelectAwait(async employee =>
            {
                //fill in model values from the entity
                var employeeModel = employee.ToModel<EmployeeModel>();

                //fill in additional values (not existing in the entity)
                //employeeModel.Breadcrumb = await _employeeService.GetFormattedBreadCrumbAsync(employee);
               // employeeModel.SeName = await _urlRecordService.GetSeNameAsync(employee, 0, true, false);

                return employeeModel;
            });
        });

        return model;
    }
    public async Task<EmployeeModel> PrepareEmployeeModelAsync(EmployeeModel model, Employee employee)
    {
        if (employee != null)
        {
            if (model == null)
            {
                model = new EmployeeModel
                {
                    Name = employee.Name,
                    FatherName = employee.FatherName,
                    MotherName = employee.MotherName,
                    EmployeeCustomId = employee.EmployeeCustomId,
                    DateOfBirth = employee.DateOfBirth,
                    Address = employee.Address,
                    Id = employee.Id
                };
            }
        }
        return model;
    }
}
