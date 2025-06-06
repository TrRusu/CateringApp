using CateringApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IIngredientHandler
    {
        public List<Ingredient> GetAllIngredients();

        public void AddIngredients(string name, int amount, double price);
    }
}
