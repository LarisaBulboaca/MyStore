using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(int page);
        IEnumerable<Category> GetCategories(int page, string? text);
        Category? GetCategory(int id);
        Category InsertNew(Category category);
        bool IsDuplicate(string Categoryname);
        int Remove(Category category);
        Category Update(Category category);
    }
}
