using MyStore.Domain;

namespace MyStore.Data
{
    public interface IScoreRepository
    {
        Score Add(Score score);
        int Delete(Score score);
        IEnumerable<Score> GetAll();
        Score? GetScoreByID(int id);
        Score Update(Score score);
    }
}