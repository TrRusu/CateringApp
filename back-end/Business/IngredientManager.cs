using Business.Interfaces;
using CateringApp;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class IngredientManager : IIngredientManager
    {
        List<Ingredient> ingredients = new List<Ingredient>();
        private readonly IIngredientHandler _ingredientHandler;


        public IngredientManager(IIngredientHandler ingredientHandler)
        {
            this._ingredientHandler = ingredientHandler;
        }

        public IngredientManager()
        {

        }

        public void DecreaseAmount(int id, int amount)
        {

        }

        public void IncreaseAmount(int id, int amount)
        {

        }

        public List<Ingredient> ListOfIngredients()
        {
            return ingredients;
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _ingredientHandler.GetAllIngredients();
        }

        public void AddIngredients(string name, int amount, double price)
        {
            _ingredientHandler.AddIngredients(name, amount, price);
        }
    }
}
