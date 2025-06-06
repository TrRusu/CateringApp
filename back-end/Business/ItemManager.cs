using Business.Interfaces;
using CateringApp;
using DAL.Handlers;
using DAL.Interfaces;
using DTO;
using DTO.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CateringApp.Item;

namespace Business
{
    public class ItemManager : IItemManager
    {
        List<Item> items;
        IngredientManager ingManager;
        private readonly IIngredientManager _ingredientManager;
        private readonly IItemHandler _handler;
        private readonly IOrderHandler _orderHandler;
        private readonly IOrderManager _orderManager;
        private readonly ICategoryHandler _categoryHandler;


        public ItemManager(IItemHandler handler)
        {
            items = new List<Item>();
            _ingredientManager = new IngredientManager();
            IngredientManager ingManager = new IngredientManager();
            _handler = handler;

        }

        public ItemManager(List<Item> items)
        {
            this.items = items;
        }
        public IEnumerable<CategoryViewModel> getItemsByCategory()
        {
            List<Category> categoriesList =  _handler.getAllCategories().ToList();
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            foreach (var category in categoriesList) {
                List<Item> itemsInCurrentCategory = _handler.getItemsByCategory(category.Id).ToList();

                categories.Add(new CategoryViewModel
                {
                    id = category.Id,
                    name = category.Name,
                    items = itemsInCurrentCategory
                });
            }
            return categories;
        }


        public Item GetItem(int id)
        {
            return new Item();
        }

        public void AddIngredient(int itemid, int ingredientid)
        {
            
        }

        public void CreateItem(string name, int price, ItemType type, string description, List<Ingredient> ingredients)
        {
            
        }

        public void RemoveItem(int id)
        {
            
        }

        public void EditItem(int id, string name, ItemType itemType, string description, List<Ingredient> ingrediants)
        {
            
        }


        public void RemoveIngredient(int itemid, int ingredientid)
        {
           
        }
        
        public void CreateItem(string name, double price, ItemType type, string description)
        {
            _handler.AddItem(name, price, type, description);
        }
        public void AddIngredientToItem(int itemid, int ingredientid)
        {
            _handler.AddIngredientToItem(itemid, ingredientid);
        }
        public IEnumerable<Item> getAllItems()
        {
            return _handler.getAllItems();
        }

        public void ChangeMealStatus(int orderid, int itemid, string status)
        {

        }
    }
}
