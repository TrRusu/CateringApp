using CateringApp;
using DAL.Data;
using DAL.Interfaces;
using DAL.Persistence;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static CateringApp.Item;

namespace DAL.Handlers
{
    public class ItemHandler : IItemHandler
    {   
        List<Item> items = new List<Item>();
        DBItem _dbItem = new DBItem();
        IngredientHandler ingHandler;
        private readonly DataContext _dataContext;

        public ItemHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
            ingHandler = new IngredientHandler();
        }

        public void AddItem(string name, double price, ItemType itemType, string description)
        {


        }

        public Item getItemById(int itemID)
        {
            return null;
        }
        public IEnumerable<Item> getItemsByCategory(int categoryId)
        {
            return _dataContext.Items.Where(x => x.CategoryId == categoryId).ToList();
        }
        
        public List<int> GetIngredientsForItem(int itemid)
        {

            return null;
        }

        public IEnumerable<Item> getAllItems()
        {
            return null;
        }



        public void ChangeMealStatus(int orderid, int id, string status)
        {
            int statusid = -1;
            switch (status)
            {
                case "Preparing":
                    statusid = 0;
                    break;

                case "Cooking":
                    statusid = 1;
                    break;

                case "Ready":
                    statusid = 2;
                    break;
            }
            _dbItem.ChangeStatus(orderid, id, status);
        }

        public void AddIngredientToItem(int itemid, int ingredientid)
        {   

        }

        public int ChangeMealStatus(string status)
        {
            int statusid = -1;
            switch (status)
            {
                case "Preparing":
                    statusid = 0;
                    break;

                case "Cooking":
                    statusid = 1;
                    break;

                case "Ready":
                    statusid = 2;
                    break;
            }

            return statusid;
        }


        //CATEGORY HANDLER METHODS
        public IEnumerable<Category> getAllCategories()
        {
            return _dataContext.Categories.ToList();
        }

    }
}
