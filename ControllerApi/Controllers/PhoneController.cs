using Microsoft.AspNetCore.Mvc;
using ControllerApi.DTO;
using ControllerApi.Interfaces;
using ControllerApi.Entities;
// using ControllerApi.Models;

namespace ControllerApi;

[ApiController]
[Route("api/[controller]")]
public class PhoneController : ControllerBase
{
    private readonly IPhoneService _phoneService;
    // private readonly EmployeeDbContext _dbContext;
    public PhoneController(IPhoneService phoneService)
    {
        _phoneService = phoneService;
        // _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetAllPhones()
    {
        var phones = _phoneService.GetAllPhones();
        if (phones.Count() != 0)
        {
            return Ok(phones);
        }
        else
        {
            return NotFound("No Records Found.");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetPhoneById(int id)
    {
        var phone = _phoneService.GetPhoneById(id);

        if (phone != null)
        {
            return Ok(phone);
        }
        else
        {
            return NotFound($"No Record Found with id: {id}");
        }
    }

    [HttpPost]
    public IActionResult AddPhone(PhoneDTO requestObject)
    {
        Phone phone = new Phone()
        {
            Name = requestObject.Name,
            ScreenSize = requestObject.ScreenSize,
            DisplayType = requestObject.DisplayType,
            Price = requestObject.Price
        };
        var result = _phoneService.AddPhone(phone);
        if (result)
        {

            return Ok("Phone Added Successfully!");
        }
        else
        {
            return BadRequest("Record Already Exists");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePhone(int id, PhoneDTO requestObject)
    {
        Phone phone = new Phone()
        {
            Name = requestObject.Name,
            ScreenSize = requestObject.ScreenSize,
            DisplayType = requestObject.DisplayType,
            Price = requestObject.Price
        };

        var result = _phoneService.UpdatePhone(id, phone);

        if (result)
        {
            return Ok("Record Updated Successfully");
        }
        else
        {
            return NotFound("No Record Found");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePhone(int id)
    {
        var result = _phoneService.DeletePhone(id);
        if (result)
        {
            return Ok("Record Deleted Successfully");
        }
        else
        {
            return NotFound($"No Record Found with id: {id}");
        }
    }
}
