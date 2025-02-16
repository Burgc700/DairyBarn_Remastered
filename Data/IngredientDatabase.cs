using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Creates an instance for every sauce, type of cheese, and burger topping for the menu items.
    /// </summary>
    public static class IngredientDatabase
    {
        /// <summary>
        /// Gets the ingredient information for the ingredients for the different ingredients.
        /// </summary>
        private class IngredientInfo
        {
            /// <summary>
            /// Gets the name of the ingredient.
            /// </summary>
            public string Name { get; }

            /// <summary>
            /// Gets the calories of the ingredient.
            /// </summary>
            public uint Calories { get; }

            /// <summary>
            /// Gets the price of the ingredient.
            /// </summary>
            public decimal AdditionalPrice { get; }

            /// <summary>
            /// The constructor.
            /// </summary>
            /// <param name="name">Initializes name.</param>
            /// <param name="cals">Initializes calories.</param>
            /// <param name="additionalPrice">Initializes price.</param>
            public IngredientInfo(string name, uint cals, decimal additionalPrice)
            {
                Name = name;
                Calories = cals;
                AdditionalPrice = additionalPrice;
            }
        }

        /// <summary>
        /// Creates a key value pair for the sauce and the information of the sauce.
        /// </summary>
        private static Dictionary<IceCreamSauce, IngredientInfo> _sauceInfo = new();

        /// <summary>
        /// Creates a key value pair for the cheese and the information of the cheese.
        /// </summary>
        private static Dictionary<Cheese, IngredientInfo> _cheeseInfo = new();

        /// <summary>
        /// Creates a key value pair for the burger toppings and the information of the topping.
        /// </summary>
        private static Dictionary<BurgerTopping, IngredientInfo> _burgerInfo = new();

        /// <summary>
        /// The constructor that Initializes all the dictionaries with the different ingredients.
        /// </summary>
        static IngredientDatabase()
        {
            _sauceInfo = new Dictionary<IceCreamSauce, IngredientInfo>();
            _sauceInfo[IceCreamSauce.ChocolateSauce] = new IngredientInfo("Chocolate Sauce", 80, 0.00m);
            _sauceInfo[IceCreamSauce.Caramel] = new IngredientInfo("Carmel", 130, 0.00m);
            _sauceInfo[IceCreamSauce.HotFudge] = new IngredientInfo("Hot Fudge", 130, 0.00m);
            _sauceInfo[IceCreamSauce.CrushedPineapple] = new IngredientInfo("Crushed Pineapple", 50, 0.00m);
            _sauceInfo[IceCreamSauce.StrawberrySauce] = new IngredientInfo("Strawberry Sauce", 50, 0.00m);
            _sauceInfo[IceCreamSauce.None] = new IngredientInfo("None", 0, 0.00m);

            _cheeseInfo = new Dictionary<Cheese, IngredientInfo>();
            _cheeseInfo[Cheese.American] = new IngredientInfo("American Cheese", 80, 0.00m);
            _cheeseInfo[Cheese.Swiss] = new IngredientInfo("Swiss Cheese", 85, 0.00m);
            _cheeseInfo[Cheese.Cheddar] = new IngredientInfo("Cheddar Cheese", 90, 0.00m);
            _cheeseInfo[Cheese.PepperJack] = new IngredientInfo("Pepper Jack", 85, 0.00m);
            _cheeseInfo[Cheese.None] = new IngredientInfo("None", 0, 0.00m);

            _burgerInfo = new Dictionary<BurgerTopping, IngredientInfo>();
            _burgerInfo[BurgerTopping.Ketchup] = new IngredientInfo("Ketchup", 20, 0.00m);
            _burgerInfo[BurgerTopping.Mustard] = new IngredientInfo("Mustard", 5, 0.00m);
            _burgerInfo[BurgerTopping.Onions] = new IngredientInfo("Onions", 5, 0.00m);
            _burgerInfo[BurgerTopping.Pickles] = new IngredientInfo("Pickles", 5, 0.00m);
            _burgerInfo[BurgerTopping.Lettuce] = new IngredientInfo("Lettuce", 5, 0.25m);
            _burgerInfo[BurgerTopping.Bacon] = new IngredientInfo("Bacon", 75, 1.00m);
            _burgerInfo[BurgerTopping.Tomato] = new IngredientInfo("Tomato", 5, 0.25m);
            _burgerInfo[BurgerTopping.GrilledOnions] = new IngredientInfo("Grilled Onions", 50, 1.00m);
            _burgerInfo[BurgerTopping.GrilledMushrooms] = new IngredientInfo("Grilled Mushrooms", 60, 1.00m);
            _burgerInfo[BurgerTopping.BBQSauce] = new IngredientInfo("BBQ Sauce", 40, 0.25m);
            _burgerInfo[BurgerTopping.CrispyFriedOnions] = new IngredientInfo("Crispy Fried Onions", 70, 0.50m);
            _burgerInfo[BurgerTopping.ChipotleMayo] = new IngredientInfo("Chipotle Mayo", 90, 0.25m);
        }

        /// <summary>
        /// The name of the sauce.
        /// </summary>
        /// <param name="sauce">The type of sauce.</param>
        /// <returns>The name of the sauce.</returns>
        public static string GetSauceName(IceCreamSauce sauce)
        {
            return _sauceInfo[sauce].Name;
        }

        /// <summary>
        /// The number of calories in the sauce.
        /// </summary>
        /// <param name="sauce">The type of sauce.</param>
        /// <returns>The number of calories in the sauce.</returns>
        public static uint GetSauceCalories(IceCreamSauce sauce)
        {
            return _sauceInfo[sauce].Calories;
        }

        /// <summary>
        /// The price of the sauce.
        /// </summary>
        /// <param name="sauce">The type of sauce.</param>
        /// <returns>The price of the sauce.</returns>
        public static decimal GetSaucePrice(IceCreamSauce sauce)
        {
            return _sauceInfo[sauce].AdditionalPrice;
        }


        /// <summary>
        /// The name of the cheese.
        /// </summary>
        /// <param name="cheese">The type of cheese.</param>
        /// <returns>The name of the cheese.</returns>
        public static string GetCheeseName(Cheese cheese)
        {
            return _cheeseInfo[cheese].Name;
        }

        /// <summary>
        /// The number of calories in the cheese.
        /// </summary>
        /// <param name="cheese">The type of cheese.</param>
        /// <returns>The number of calories in the cheese.</returns>
        public static uint GetCheeseCalories(Cheese cheese)
        {
            return _cheeseInfo[cheese].Calories;
        }

        /// <summary>
        /// The price of the cheese.
        /// </summary>
        /// <param name="cheese">The type of cheese.</param>
        /// <returns>The price of the cheese.</returns>
        public static decimal GetCheesePrice(Cheese cheese)
        {
            return _cheeseInfo[cheese].AdditionalPrice;
        }


        /// <summary>
        /// The name of the topping.
        /// </summary>
        /// <param name="topping">The type of topping.</param>
        /// <returns>The name of the topping.</returns>
        public static string GetBurgerToppingName(BurgerTopping topping)
        {
            return _burgerInfo[topping].Name;
        }

        /// <summary>
        /// The number of calories in the topping.
        /// </summary>
        /// <param name="topping">The type of topping.</param>
        /// <returns>The number of calories in the topping.</returns>
        public static uint GetBurgerToppingCalories(BurgerTopping topping)
        {
            return _burgerInfo[topping].Calories;
        }

        /// <summary>
        /// The price of the topping.
        /// </summary>
        /// <param name="topping">The type of topping.</param>
        /// <returns>The price of the topping.</returns>
        public static decimal GetBurgerToppingPrice(BurgerTopping topping)
        {
            return _burgerInfo[topping].AdditionalPrice;
        }
    }
}
