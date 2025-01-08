using APISample.Models;

namespace APISample.Interface
{
    public interface ITrial
    {
        int Save(TrialClass TC);
        int DeleteOne(int id);
        List<TrialClass> GetAll();
        int Update(int id, TrialClass tc);
    }
}
