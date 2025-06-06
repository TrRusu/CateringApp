using CateringApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IIngredientManager
    {
        public List<Ingredient> GetAllIngredients();
        public void AddIngredients(string name, int amount, double price);
    }
}
