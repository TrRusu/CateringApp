using CateringApp;
using DAL.Data;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nanoid;

namespace DAL.Seed
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext context)
        {
            _dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!_dataContext.Tables.Any())
            {
                var tables = new List<Table>()
                {
                    new Table
                    {
                        Name = Nanoid.Nanoid.Generate("QWERTYUIOPASDFGHJKLZXCVBNM", 6),
                        amount_seats = 4,
                        Status = TableStatus.Available
                    },
                    new Table
                    {
                        Name = Nanoid.Nanoid.Generate("QWERTYUIOPASDFGHJKLZXCVBNM", 6),
                        amount_seats = 6,
                        Status = TableStatus.Available
                    },
                    new Table
                    {
                        Name = Nanoid.Nanoid.Generate("QWERTYUIOPASDFGHJKLZXCVBNM", 6),
                        amount_seats = 8,
                        Status = TableStatus.Available
                    },
                    new Table
                    {
                        Name = Nanoid.Nanoid.Generate("QWERTYUIOPASDFGHJKLZXCVBNM", 6),
                        amount_seats = 2,
                        Status = TableStatus.Available
                    },
                    new Table
                    {
                        Name = Nanoid.Nanoid.Generate("QWERTYUIOPASDFGHJKLZXCVBNM", 6),
                        amount_seats = 4,
                        Status = TableStatus.Available
                    },
                    new Table
                    {
                        Name = Nanoid.Nanoid.Generate("QWERTYUIOPASDFGHJKLZXCVBNM", 6),
                        amount_seats = 6,
                        Status = TableStatus.Available
                    }
                };

                var categories = new List<Category>()
                {
                    new Category()
                    {
                        Name = "Pizza",
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Margaritha",
                                Description = "Pizza Margherita is a classic Italian pizza that is typically made with tomato sauce, mozzarella cheese, and fresh basil. It is named after Queen Margherita of Savoy and is often considered a symbol of Italian cuisine.",
                                ImageUrl = "https://i.imgur.com/8B8YLOo.jpg",
                                Price = 12.0,
                                itemType = ItemType.Food
                            },
                            new Item()
                            {
                                Name = "Pepperoni",
                                Description = "Pizza Pepperoni is a popular type of pizza that is made with pepperoni, a spicy cured meat made from pork and beef. It is typically topped with tomato sauce and mozzarella cheese, and may also include other ingredients such as onions, peppers, and mushrooms.",
                                ImageUrl = "https://i.imgur.com/OHHctnf.jpg",
                                Price = 15.0,
                                itemType = ItemType.Food
                            },
                            new Item()
                            {
                                Name = "Rome",
                                Description = "Pizza Rome is a type of pizza that is typically made with a thin crust and topped with a variety of ingredients, including tomato sauce, mozzarella cheese, and a selection of meats and vegetables. It is named after the city of Rome, which is known for its rich culinary history and diverse range of dishes.",
                                ImageUrl = "https://i.imgur.com/3ZTwCfz.png",
                                Price = 13.5,
                                itemType = ItemType.Food
                            }
                        }
                    },
                    new Category()
                    {
                        Name = "Pasta",
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Bolognese",
                                Description = "Pasta Bolognese, also known as spaghetti Bolognese, is a classic Italian dish made with spaghetti or another type of pasta, a meat-based sauce, and grated cheese. The sauce, called ragù, is traditionally made with ground beef, onions, carrots, celery, and tomatoes, and is slowly simmered to create a rich, flavorful base. Pasta Bolognese is often served with a sprinkle of Parmesan cheese on top.",
                                ImageUrl = "https://i.imgur.com/IXDJ52k.png",
                                Price = 17.0,
                                itemType = ItemType.Food
                            },
                            new Item()
                            {
                                Name = "Carbonara",
                                Description = "Pasta Carbonara is a pasta dish made with spaghetti or another type of pasta, eggs, bacon or pancetta, and grated cheese. The eggs and cheese are mixed together to create a creamy sauce, which is then tossed with the cooked pasta and bacon or pancetta. Pasta Carbonara is typically garnished with black pepper and served hot.",
                                ImageUrl = "https://i.imgur.com/3jKSuUu.png",
                                Price = 19.0,
                                itemType = ItemType.Food
                            },
                        }
                    },
                    new Category()
                    {
                        Name = "Salads",
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Caesar",
                                Description = "Salad Caesar is a popular salad that is typically made with crisp romaine lettuce, croutons, and grated Parmesan cheese, and is dressed with a creamy Caesar dressing. The dressing is typically made with ingredients such as mayonnaise, anchovy paste, garlic, and lemon juice, and gives the salad its distinctive flavor. Salad Caesar is often served with grilled chicken or other protein, and may also include other ingredients such as tomatoes, onions, and croutons.",
                                ImageUrl = "https://i.imgur.com/QWXH2NC.png",
                                Price = 11.0,
                                itemType = ItemType.Food
                            },
                            new Item()
                            {
                                Name = "Greek",
                                Description = "Salad Greek is a type of salad that is typically made with a variety of fresh vegetables, including tomatoes, cucumbers, bell peppers, onions, and olives, and is topped with feta cheese and dressed with a vinaigrette made with olive oil and lemon juice. Salad Greek is often served with grilled chicken or other protein, and may also include ingredients such as chickpeas or grains for added texture and flavor.",
                                ImageUrl = "https://i.imgur.com/qChqf83.png",
                                Price = 10.0,
                                itemType = ItemType.Food
                            },
                            new Item()
                            {
                                Name = "Tuna",
                                Description = "Salad Tuna is a type of salad that is made with tuna, a type of saltwater fish that is often canned and used in a variety of dishes. Salad Tuna is typically made with a variety of vegetables, such as lettuce, tomatoes, onions, and cucumbers, and is dressed with a vinaigrette made with olive oil and vinegar. It may also include other ingredients such as olives, cheese, and hard-boiled eggs, and is often served as a main course or as a side dish.",
                                ImageUrl = "https://i.imgur.com/Ph0IjrX.png",
                                Price = 13.0,
                                itemType = ItemType.Food
                            },
                        }
                    },
                    new Category()
                    {
                        Name = "Drinks",
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                Name = "Coca cola",
                                Description = "Coca-Cola is a carbonated soft drink that is made with a blend of caramel color, high fructose corn syrup, and natural flavors. It was invented in 1886 and is one of the most well-known and widely consumed soft drinks in the world. Coca-Cola is known for its distinctive flavor, which is a combination of sweet and slightly citrusy.",
                                ImageUrl = "https://i.imgur.com/nJ6LeWv.png",
                                Price = 4.0,
                                itemType = ItemType.Drinks
                            },
                            new Item()
                            {
                                Name = "Fanta",
                                Description = "Fanta is a brand of fruit-flavored carbonated soft drinks that is owned by The Coca-Cola Company. Fanta was first created in Germany in 1941 as a result of a shortage of ingredients used to make Coca-Cola, and it is now available in a variety of fruit flavors, including orange, grape, and strawberry.",
                                ImageUrl = "https://i.imgur.com/1WDkfme.png",
                                Price = 4.0,
                                itemType = ItemType.Drinks
                            },
                            new Item()
                            {
                                Name = "Sprite",
                                Description = "Sprite is a brand of lemon-lime flavored carbonated soft drinks that is owned by The Coca-Cola Company. It was first introduced in the United States in 1961 and is now available in more than 190 countries. Sprite is known for its crisp, refreshing flavor and is often consumed as a thirst quencher.",
                                ImageUrl = "https://i.imgur.com/qP4Nx1x.jpg",
                                Price = 4.0,
                                itemType = ItemType.Drinks
                            },
                        }
                    }
                };
                
                _dataContext.Tables.AddRange(tables);
                _dataContext.Categories.AddRange(categories);
                
                _dataContext.SaveChanges();
            }
        }
    }
}
