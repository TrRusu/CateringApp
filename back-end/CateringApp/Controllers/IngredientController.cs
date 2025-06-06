using Business;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CateringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        IIngredientManager _ingredientManager;
        public IngredientController(IIngredientManager _ingredientManager)
        {
            this._ingredientManager = _ingredientManager;
        }
        [HttpGet]
        [Route("GetAllIngredients")]
        public List<Ingredient> GetAllIngredients()
        {
            return _ingredientManager.GetAllIngredients();
        }
        [HttpPost]
        [Route("AddIngredient")]
        public void AddIngredients(string name, int amount, double price)
        {
            _ingredientManager.AddIngredients(name, amount, price);
        }


    }
}
