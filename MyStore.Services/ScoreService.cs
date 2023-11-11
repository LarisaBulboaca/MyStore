using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository scoreRepository;

        public ScoreService(IScoreRepository scoreRepository)
        {
            this.scoreRepository = scoreRepository;
        }

        public Score? GetScore(int id)
        {
            var existingScore = scoreRepository.GetScoreByID(id);
            return existingScore;
        }

        public IEnumerable<Score> GetScores()
        {
            return scoreRepository.GetAll();
        }

        public Score InsertNew(Score score)
        {
            return scoreRepository.Add(score);
        }

        public int Remove(Score score)
        {
            return scoreRepository.Delete(score);
        }

        public Score Update(Score score)
        {
            return scoreRepository.Update(score);
        }
    }
}
