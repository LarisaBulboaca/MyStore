using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class NumService : INumService
    {
        private readonly INumRepository numRepository;

        public NumService(INumRepository numRepository)
        {
            this.numRepository = numRepository;
        }

        public Num? GetNum(int id)
        {
            var existingNum = numRepository.GetNumByID(id);
            return existingNum;
        }

        public IEnumerable<Num> GetNums()
        {
            return numRepository.GetAll();
        }

        public Num InsertNew(Num num)
        {
            return numRepository.Add(num);
        }

        public int Remove(Num num)
        {
            return numRepository.Delete(num);
        }

        public Num Update(Num num)
        {
            return numRepository.Update(num);
        }
    }
}
