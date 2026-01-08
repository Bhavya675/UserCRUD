using ControllerApi.Entities;
using ControllerApi.Interfaces;
// using ControllerApi.Models;
// using ControllerApi.Models;

namespace ControllerApi.Services;

public class PhoneService : IPhoneService
{
    private readonly EmployeeDbContext _dbContext;
    public PhoneService(EmployeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // List<Phone> phones = new List<Phone>
    // {
    //     new Phone { PhoneId = 1, Name = "Samsung Galaxy S25", DisplayType = "AMOLED", ScreenSize = 6.5, Price = 35000 },
    //     new Phone { PhoneId = 2, Name = "One Plus 18", DisplayType = "AMOLED", ScreenSize = 6.2, Price = 28000 },
    //     new Phone { PhoneId = 3, Name = "Realme 14", DisplayType = "IPS LCD", ScreenSize = 6, Price = 18000 },
    // };

    public List<Phone> GetAllPhones()
    {
        // List<Phone> phones = _dbContext.Phones.ToList();
        return _dbContext.Phones.ToList();
        // return phones;
    }

    public Phone? GetPhoneById(int id)
    {
        return _dbContext.Phones.Find(id);
        // return phones.FirstOrDefault(x => x.PhoneId == id)!;
    }

    public bool AddPhone(Phone phone)
    {
        var isDuplicate = _dbContext.Phones.Any(x => x.Name != null && phone.Name != null && x.Name.ToLower() == phone.Name.ToLower());

        var q = _dbContext.Phones.Where(x => x.Name == "Bhavya").ToList();
        if (isDuplicate)
        {
            return false;
        }
        _dbContext.Phones.Add(new Phone
        {
            Name = phone.Name,
            ScreenSize = phone.ScreenSize,
            DisplayType = phone.DisplayType,
            Price = phone.Price
        });

        _dbContext.SaveChanges();
        return true;
    }

    public bool UpdatePhone(int id, Phone phone)
    {
        var record = _dbContext.Phones.Find(id);
        if (record != null)
        {
            record.Name = phone.Name;
            record.ScreenSize = phone.ScreenSize;
            record.DisplayType = phone.DisplayType;
            record.Price = phone.Price;

            _dbContext.Update(record);
            _dbContext.SaveChanges();

            return true;
        }
        else
        {
            // Console.WriteLine("Record Not Found");
            return false;
        }
    }

    public bool DeletePhone(int id)
    {
        var record = _dbContext.Phones.Find(id);
        if (record != null)
        {
            _dbContext.Phones.Remove(record);
            _dbContext.SaveChanges();
            return true;
        }
        else
        {
            // Console.WriteLine("Record Not Found");
            return false;
        }
    }
}
