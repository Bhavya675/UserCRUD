using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PhoneService : IPhoneService
{
    List<Phone> phones = new List<Phone>
    {
        new Phone { Id = 1, Name = "Samsung Galaxy S25", DisplayType = "AMOLED", ScreenSize = 6.5, Price = 35000 },
        new Phone { Id = 2, Name = "One Plus 18", DisplayType = "AMOLED", ScreenSize = 6.2, Price = 28000 },
        new Phone { Id = 3, Name = "Realme 14", DisplayType = "IPS LCD", ScreenSize = 6, Price = 18000 },
    };

    public List<Phone> GetAllPhones()
    {
        return phones;
    }

    public Phone GetPhoneById(int id)
    {
        return phones.FirstOrDefault(x => x.Id == id)!;
    }

    public bool AddPhone(Phone phone)
    {
        phones.Add(phone);
        return true;
    }

    public bool UpdatePhone(int id, Phone phone)
    {
        var record = phones.Find(x => x.Id == id);
        if (record != null)
        {
            record.Name = phone.Name;
            record.ScreenSize = phone.ScreenSize;
            record.DisplayType = phone.DisplayType;
            record.Price = phone.Price;

            Console.WriteLine(record);
            return true;
        }
        else
        {
            Console.WriteLine("Record Not Found");
            return false;
        }
    }

    public bool DeletePhone(int id)
    {
        var record = phones.Find(x => x.Id == id);
        if (record != null)
        {
            phones.Remove(record);
            return true;
        }
        else
        {
            Console.WriteLine("Record Not Found");
            return false;
        }
    }
}
