using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        int Delete(Category category);
        IEnumerable<Category> GetAll(int page);
        //IEnumerable<Category> GetAll(int page, string text);
        IQueryable<Category> GetAll();
        IQueryable<Category> GetAll(int page, string? text);
        Category? GetCategoryById(int id);
        Category Update(Category category);
    }
}
