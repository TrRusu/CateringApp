using CateringApp;
using DTO.Viewmodels;

namespace Business.Interfaces
{
    public interface IItemManager
    {

        public Item GetItem(int id);

        public void CreateItem(string name, double price, ItemType type, string description);
        public IEnumerable<Item> getAllItems();
        public void RemoveIngredient(int itemid, int ingredientid);

        public void ChangeMealStatus(int orderid, int itemid, string status);
        public void AddIngredientToItem(int itemid, int ingredientid);
        void AddIngredient(int itemid, int ingredientid);
        void CreateItem(string name, int price, ItemType type, string description, List<Ingredient> ingredients);
        void EditItem(int id, string name, ItemType itemType, string description, List<Ingredient> ingrediants);
        IEnumerable<CategoryViewModel> getItemsByCategory();
        void RemoveItem(int id);
    }
}