using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Models.Employees;

public record EmployeeModel : BaseNopEntityModel
{
    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.FatherName")]
    public string FatherName { get; set; }

    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.MotherName")]
    public string MotherName { get; set; }

    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.EmployeeCustomId")]
    public string EmployeeCustomId { get; set; }

    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.DateOfBirth")]
    [UIHint("Date")]
    public DateTime DateOfBirth { get; set; }

    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.Address")]
    public string Address { get; set; }
}

