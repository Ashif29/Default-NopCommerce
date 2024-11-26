using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Stores;

namespace Nop.Core.Domain.Employee;
public class Employee : BaseEntity, ILocalizedEntity
{
    public string Name { get; set; }
    public string FatherName { get; set; }
    public string MotherName { get; set; }
    public string EmployeeCustomId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
}
