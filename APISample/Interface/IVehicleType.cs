using APISample.Models;

namespace APISample.Interface
{
    public interface IVehicleType
    {
        int? Create(VehicleType VT);
        int? Update(int id, VehicleType VT);
        int? DeleteOne(int id);
        List<VehicleType>? GetAll();
    }
}
