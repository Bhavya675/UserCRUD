using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalAPI.DTO;
using MinimalAPI.Entities;

namespace MinimalAPI.Models.DTO.Response
{
    public class ProductResponse: BaseResponse
    {
         public List<Product>? Data { get; set; }
    }
}