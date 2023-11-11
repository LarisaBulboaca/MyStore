using MyStore.Domain;

namespace MyStore.Data
{
    public interface INumRepository
    {
        Num Add(Num num);
        int Delete(Num num);
        IEnumerable<Num> GetAll();
        Num? GetNumByID(int id);
        Num Update(Num num);
    }
}