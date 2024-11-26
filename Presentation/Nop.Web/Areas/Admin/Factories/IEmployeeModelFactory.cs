using Nop.Core.Domain.Employee;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Areas.Admin.Models.Employees;

namespace Nop.Web.Areas.Admin.Factories;

public interface IEmployeeModelFactory
{
    Task<EmployeeModel> PrepareEmployeeModelAsync(EmployeeModel model, Employee employee);
    Task<EmployeeSearchModel> PrepareEmployeeSearchModelAsync(EmployeeSearchModel searchModel);
    Task<EmployeeListModel> PrepareEmployeeListModelAsync(EmployeeSearchModel searchModel);
}
