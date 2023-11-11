using MyStore.Domain;

namespace MyStore.Services
{
    public interface IScoreService
    {
        Score? GetScore(int id);
        IEnumerable<Score> GetScores();
        Score InsertNew(Score score);
        int Remove(Score score);
        Score Update(Score score);
    }
}