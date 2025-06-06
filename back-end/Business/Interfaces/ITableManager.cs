using DTO;
using DTO.Viewmodels;

namespace Business.Interfaces
{
    public interface ITableManager
    {
        IEnumerable<Table> getAll();
    }
}