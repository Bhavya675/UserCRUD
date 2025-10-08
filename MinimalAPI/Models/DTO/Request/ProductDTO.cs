using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalAPI.Models.DTO.Request
{
    public class ProductDTO
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string? Category { get; set; }

        public string? Description { get; set; }

        public decimal? Ratings { get; set; }

        public string? Warranty { get; set; }
    }
}