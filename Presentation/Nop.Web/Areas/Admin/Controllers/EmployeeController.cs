using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Employee;
using Nop.Services.Employees;
using Nop.Services.Media;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Models.Employees;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework;
using Nop.Services.Security;

namespace Nop.Web.Areas.Admin.Controllers;

[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class EmployeeController : BaseAdminController
{
    private readonly IEmployeeModelFactory _employeeModelFactory;
    protected readonly IPermissionService _permissionService;

    public EmployeeController
    (
        IEmployeeModelFactory employeeModelFactory,
        IPermissionService permissionService)
    {
        _employeeModelFactory = employeeModelFactory;
        _permissionService = permissionService;
    }

    public virtual IActionResult Index()
    {
        return RedirectToAction("List");
    }

    public virtual async Task<IActionResult> List()
    {
        //if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageEmployees))
        //    return AccessDeniedView();

        //prepare model
        var model = await _employeeModelFactory.PrepareEmployeeSearchModelAsync(new EmployeeSearchModel());

        return View(model);
    }

    [HttpPost]
    public virtual async Task<IActionResult> List(EmployeeSearchModel searchModel)
    {
        //if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageEmployees))
        //    return await AccessDeniedDataTablesJson();

        //prepare model
        var model = await _employeeModelFactory.PrepareEmployeeListModelAsync(searchModel);

        return Json(model);
    }

    public async Task<IActionResult> Create()
    {
        var model = await _employeeModelFactory.PrepareEmployeeModelAsync(new EmployeeModel(), null);

        return View(model);
    }


    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Create(EmployeeModel model, bool continueEditing)
    {
        if (ModelState.IsValid)
        {
            var employee = new Employee
            {
                Name = model.Name,
                FatherName = model.FatherName,
                MotherName = model.MotherName,
                EmployeeCustomId = model.EmployeeCustomId,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
            };

            //await _employeeService.InsertEmployeeAsync(employee);

            return continueEditing ? RedirectToAction("Edit", new { id = employee.Id }) : RedirectToAction("List");
        }

        model = await _employeeModelFactory.PrepareEmployeeModelAsync(model, null);

        return View("Create", model);
    }
}