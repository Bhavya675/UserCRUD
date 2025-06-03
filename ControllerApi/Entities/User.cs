using System;
using System.Collections.Generic;

namespace ControllerApi.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }
}
