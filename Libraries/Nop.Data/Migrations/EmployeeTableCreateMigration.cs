using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Nop.Core.Domain.Employee;
using Nop.Data.Extensions;
using Nop.Data.Mapping;

namespace Nop.Data.Migrations;

[NopSchemaMigration("2024/11/26 15:36:55:1687541", "EmployeeTableCreateMigration", MigrationProcessType.Update)]
public class EmployeeTableCreateMigration : AutoReversingMigration
{
    public override void Up()
    {
        if (!Schema.Table(NameCompatibilityManager.GetTableName(typeof(Employee))).Exists())
        {
            Create.TableFor<Employee>();
        }
    }
}