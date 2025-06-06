using DTO;
using System.ComponentModel.DataAnnotations;

namespace CateringApp
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public ICollection<ItemIngredient> ItemIngredients { get; set; }
    }
}
