using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControllerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Test : ControllerBase
    {
        // private readonly IPhoneService _phoneService;

        // public Test(IPhoneService phoneService)
        // {
        //     _phoneService = phoneService;
        // }

        public IPhoneService phoneService { get; set; }

        public IActionResult HH()
        {
            var result = phoneService.GetAllPhones();
            return Ok(result);
        }

        public bool IsEvenNumber(int number, IPhoneService phoneService)
        {
            phoneService.GetAllPhones();
            return number % 2 == 0;
        }

    }
}