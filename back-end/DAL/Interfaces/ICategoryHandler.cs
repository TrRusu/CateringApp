using DTO;

namespace DAL.Interfaces
{
    public interface ICategoryHandler
    {
        IEnumerable<Category> getAll();
    }
}