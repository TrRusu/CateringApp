using CateringApp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public class ItemIngredient
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int IngredientId { get; set; }
        public Item Item { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
