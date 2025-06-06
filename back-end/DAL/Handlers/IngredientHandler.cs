using CateringApp;
using DAL.Data;
//using DAL.Data;
using DAL.Interfaces;
using DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handlers
{
    public class IngredientHandler : IIngredientHandler
    {
        DBIngredient _db;
        public IngredientHandler()
        {
            this._db = new DBIngredient();   
        }
        
        public List<Ingredient> GetAllIngredients()
        {
            return null;
        }

        public Ingredient GetIngredientByID(int ingredientid)
        {

            return null;

        }


        public void AddIngredients(string name, int amount, double price)
        {

        }
    }
}
