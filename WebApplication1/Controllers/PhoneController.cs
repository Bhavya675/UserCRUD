using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1;

[ApiController]
[Route("api/[controller]")]
public class PhoneController : ControllerBase
{
    private readonly IPhoneService _phoneService;
    public PhoneController(IPhoneService phoneService)
    {
        _phoneService = phoneService;
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
            return NotFound("Opps! No Records Found.");
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
        _phoneService.AddPhone(phone);
        return Ok("Phone Added Successfully!");
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
