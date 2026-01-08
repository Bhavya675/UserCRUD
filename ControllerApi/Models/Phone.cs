using System.ComponentModel.DataAnnotations;

namespace ControllerApi.Models;

public class Phone
{
    public int PhoneId { get; set; }
    public string Name { get; set; }
    public double ScreenSize { get; set; }
    public string DisplayType { get; set; }
    public double Price { get; set; }
}
