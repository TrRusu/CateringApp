using DTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CateringApp
{
    public enum ItemType
    {
        Food,
        Drinks
    }

    public class Item
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public ItemType itemType { get; set; }
        public string Description { get; set; }

        //public Category Category { get; set; }
        public ICollection<ItemOrder> ItemOrders { get; set; }
        public ICollection<ItemIngredient> ItemIngredients { get; set; }
    }
}