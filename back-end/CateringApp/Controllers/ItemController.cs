using Business;
using Business.Interfaces;
using DTO.Viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CateringApp.Item;

namespace CateringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        IItemManager _itemManager;
        public ItemController(IItemManager _itemManager)
        {
            this._itemManager = _itemManager;
        }

        [HttpGet]
        public IEnumerable<CategoryViewModel> GetItemsByCategory() {
            return _itemManager.getItemsByCategory();
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<CategoryViewModel>  getAllItems()
        {
            return _itemManager.getItemsByCategory();
        }

        [HttpPost]
        [Route("AddItem")]
        public void CreateItem(string name, double price, ItemType type, string description)
        {
            _itemManager.CreateItem(name, price, type, description);
        }

        [HttpPost]
        [Route("AddIngredientToItem")]
        public void AddIngredientToItem(int itemid, int ingredientid)
        {
            _itemManager.AddIngredientToItem(itemid, ingredientid);
        }
        [HttpPost]
        [Route("ChangeMealStatus")]
        public void ChangeMealStatus(int orderid, int itemid, string status)
        {
            _itemManager.ChangeMealStatus(orderid, itemid, status);
        }
    }
}
