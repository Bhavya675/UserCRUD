using System;
using System.Collections.Generic;

namespace ControllerApi.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public string? DepartmentEmail { get; set; }

    public string? DepartmentCcemail { get; set; }

    public bool DepartmentStatus { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
