using CateringApp;
using DTO;
using static CateringApp.Item;

namespace DAL.Interfaces
{
    public interface IItemHandler
    {
        public IEnumerable<Item> getAllItems();
        public Item getItemById(int itemID);
        public IEnumerable<Item> getItemsByCategory(int categoryId);
        public void ChangeMealStatus(int orderid, int id, string status);
        public void AddItem(string name, double price, ItemType itemType, string description);
        public void AddIngredientToItem(int itemid, int ingredientid);
        public int ChangeMealStatus(string status);
        public IEnumerable<Category> getAllCategories();
    }
}