using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly StoreContext storeContext;

        public ScoreRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Score? GetScoreByID(int id)
        {
            return storeContext.Scores.Find(id);
        }

        public Score Add(Score score)
        {
            var addedEntity = storeContext.Scores.Add(score).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Score score)
        {
            storeContext.Scores.Remove(score);
            return storeContext.SaveChanges();
        }

        public Score Update(Score score)
        {
            var updatedEntity = storeContext.Scores.Update(score).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }

        public IEnumerable<Score> GetAll()
        {
            return storeContext.Scores.ToList();
        }
    }
}
