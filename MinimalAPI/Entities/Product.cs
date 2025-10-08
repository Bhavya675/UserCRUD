using System;
using System.Collections.Generic;

namespace MinimalAPI.Entities;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Category { get; set; }

    public string? Description { get; set; }

    public decimal? Ratings { get; set; }

    public string? Warranty { get; set; }
}
