using MyStore.Domain;

namespace MyStore.Services
{
    public interface INumService
    {
        IEnumerable<Num> GetNums();
        Num? GetNum(int id);
        Num InsertNew(Num num);
        int Remove(Num num);
        Num Update(Num num);
    }
}