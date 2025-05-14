using WebApplication1.Models;

namespace WebApplication1.Interfaces;

public interface IPhoneService
{
    List<Phone> GetAllPhones();
    Phone GetPhoneById(int id);
    bool AddPhone(Phone phone);
    bool UpdatePhone(int id, Phone phone);
    bool DeletePhone(int id);
}
