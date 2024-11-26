using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Employee;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Discounts;

namespace Nop.Services.Employees;
public partial interface IEmployeeService
{
    //Task ClearDiscountCategoryMappingAsync(Discount discount);

    //Task DeleteEmployeeAsync(Employee employee);


    Task<IPagedList<Employee>> GetAllEmployeesAsync(string employeeName, string employeeFatherName,
        int pageIndex = 0, int pageSize = int.MaxValue);

   
    
    //Task<Employee> GetEmployeeByIdAsync(int employeeId);
    
    //Task InsertCategoryAsync(Employee employee);

 
    //Task UpdateCategoryAsync(Employee employee);


    //Task DeleteEmployeesAsync(IList<Employee> employees);

    //Task DeleteProductCategoryAsync(ProductCategory productCategory);


    //Task<DiscountCategoryMapping> GetDiscountAppliedToCategoryAsync(int categoryId, int discountId);

    //Task InsertDiscountCategoryMappingAsync(DiscountCategoryMapping discountCategoryMapping);


    //Task DeleteDiscountCategoryMappingAsync(DiscountCategoryMapping discountCategoryMapping);


    //Task<IPagedList<ProductCategory>> GetProductEmployeesByCategoryIdAsync(int categoryId,
        //int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

    //Task<IList<ProductCategory>> GetProductEmployeesByProductIdAsync(int productId, bool showHidden = false);

    //Task<ProductCategory> GetProductCategoryByIdAsync(int productCategoryId);

    //Task InsertProductCategoryAsync(ProductCategory productCategory);


    //Task UpdateProductCategoryAsync(ProductCategory productCategory);


    //Task<string[]> GetNotExistingEmployeesAsync(string[] categoryIdsNames);


    //Task<IDictionary<int, int[]>> GetProductCategoryIdsAsync(int[] productIds);


    //Task<IList<Employee>> GetEmployeesByIdsAsync(int[] categoryIds);


    //ProductCategory FindProductCategory(IList<ProductCategory> source, int productId, int categoryId);


    //Task<string> GetFormattedBreadCrumbAsync(Employee employee, IList<Employee> allEmployees = null,
        //string separator = ">>", int languageId = 0);


    //Task<IList<Employee>> GetCategoryBreadCrumbAsync(Employee employee, IList<Employee> allEmployees = null, bool showHidden = false);
}
