using System;
using System.Collections.Generic;

namespace ControllerApi.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime JoiningDate { get; set; }

    public DateTime? LastDate { get; set; }

    public bool EmployeeStatus { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
