using MyStore.Domain;

namespace MyStore.Data
{
    public interface IProductRepository
    {
        Product Add(Product product);
        int Delete(Product product);
        IEnumerable<Product> GetAll();
        Product? GetProductByID(int id);
        Product Update(Product product);
    }
}