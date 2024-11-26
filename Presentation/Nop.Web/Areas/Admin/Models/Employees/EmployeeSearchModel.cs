using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Employees;

public partial record EmployeeSearchModel : BaseSearchModel
{
    #region Ctor

    public EmployeeSearchModel()
    {

    }

    #endregion

    #region Properties

    [NopResourceDisplayName("Admin.Employees.List.SearchEmployeeName")]
    public string SearchEmployeeName { get; set; }
    
    [NopResourceDisplayName("Admin.Employees.List.SearchEmployeeFatherName")]
    public string SearchEmployeeFatherName { get; set; }

    #endregion
}