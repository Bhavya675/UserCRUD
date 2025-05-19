using ControllerApi.Models;

namespace ControllerApi.Interfaces;

public interface IPhoneService
{
    List<Phone> GetAllPhones();
    Phone GetPhoneById(int id);
    bool AddPhone(Phone phone);
    bool UpdatePhone(int id, Phone phone);
    bool DeletePhone(int id);
}
