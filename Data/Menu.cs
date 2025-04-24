using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DairyBarn.Data
{
    /// <summary>
    /// Loops through all properties but burger ingredients and creates and instance of each possible combonation.
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Private backing field for the burgers.
        /// </summary>
        private static List<IMenuItem> _burgers;

        /// <summary>
        /// A list of possible burger options.
        /// </summary>
        public static List<IMenuItem> Burgers => _burgers;

        /// <summary>
        /// Private backing field for the ice cream.
        /// </summary>
        private static List<IMenuItem> _iceCream;

        /// <summary>
        /// A list of possible ice cream options.
        /// </summary>
        public static List<IMenuItem> IceCream => _iceCream;

        /// <summary>
        /// A private backing field for drinks.
        /// </summary>
        private static List<IMenuItem> _drinks;

        /// <summary>
        /// A list of possible drink options.
        /// </summary>
        public static List<IMenuItem> Drinks => _drinks;

        /// <summary>
        /// Private backing field for burger toppings.
        /// </summary>
        private static List<Burger.BurgerIngredient> _toppings;

        /// <summary>
        /// A list of possible burger toppings.
        /// </summary>
        public static List<Burger.BurgerIngredient> Toppings => _toppings;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Menu()
        {
            _burgers = new List<IMenuItem>();
            _iceCream = new List<IMenuItem>();
            _drinks = new List<IMenuItem>();
            _toppings = new List<Burger.BurgerIngredient>();
            BurgerOptions();
            ClassicSundaeOptions();
            BrownieSundaeOptions();
            StrawberryShortcakeOptions();
            WinterSwirlOptions();
            IceCreamConeOptions();
            DrinkOptions();
            ToppingsOptions();
        }

        /// <summary>
        /// Finds all possible options for a burger and adds them to the list.
        /// </summary>
        private static void BurgerOptions()
        {
            List<Burger> burger = new List<Burger>
            {
                new BBQBaconCheeseburger(),
                new BYOBurger(),
                new ClassicCheeseburger(),
                new MushroomSwissBurger(),
                new VeggieBurger()
            };

            foreach (Burger defaultBurger in burger)
            {
                for (uint patty = 1; patty <= defaultBurger.MaxPatties; patty++)
                {
                    foreach (Cheese cheese in defaultBurger.CheeseOptions)
                    {
                        if (defaultBurger is VeggieBurger vb)
                        {
                            foreach (bool veggie in new[] { true })
                            {
                                Burger cust = (Burger)Activator.CreateInstance(defaultBurger.GetType())!;
                                cust.Patties = patty;
                                cust.CheeseChoice = cheese;
                                cust.Veggie = veggie;
                                _burgers.Add(cust);
                            }
                        }
                        else
                        {
                            foreach (bool veggie in new[] { true, false })
                            {
                                Burger cust = (Burger)Activator.CreateInstance(defaultBurger.GetType())!;
                                cust.Patties = patty;
                                cust.CheeseChoice = cheese;
                                cust.Veggie = veggie;
                                _burgers.Add(cust);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Finds all possible options for classic sundae and adds them to the list.
        /// </summary>
        private static void ClassicSundaeOptions()
        {
            ClassicSundae cs = new();
            for(uint scoops = 1; scoops <= cs.MaxScoops; scoops++)
            {
                foreach(IceCreamSauce sauce in cs.SauceOptions)
                {
                    foreach(bool whippedCream in new[] { true, false })
                    {
                        foreach(bool cherry in new[] { true, false })
                        {
                            foreach(bool peanuts in new[] { true, false})
                            {
                                ClassicSundae cust = new();
                                cust.Scoops = scoops;
                                cust.SauceChoice = sauce;
                                cust.WhippedCream = whippedCream;
                                cust.Cherry = cherry;
                                cust.Peanuts = peanuts;
                                _iceCream.Add(cust);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Finds all possible options for brownie sundae and adds them to the list.
        /// </summary>
        private static void BrownieSundaeOptions()
        {
            BrownieSundae bs = new();
            foreach(IceCreamSauce sauce in bs.SauceOptions)
            {
                foreach (bool whippedCream in new[] { true, false })
                {
                    foreach (bool cherry in new[] { true, false })
                    {
                        foreach (bool peanuts in new[] { true, false })
                        {
                            BrownieSundae cust = new();
                            cust.SauceChoice = sauce;
                            cust.WhippedCream = whippedCream;
                            cust.Cherry = cherry;
                            cust.Peanuts = peanuts;
                            _iceCream.Add(cust);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Finds all possible options for strawberry shortcake and adds them to the list.
        /// </summary>
        private static void StrawberryShortcakeOptions()
        {
            StrawBerryShortcake sc = new();
            foreach (IceCreamSauce sauce in sc.SauceOptions)
            {
                foreach (bool whippedCream in new[] { true, false })
                {
                    foreach (bool cherry in new[] { true, false })
                    {
                        foreach (bool peanuts in new[] { true, false })
                        {
                            StrawBerryShortcake cust = new();
                            cust.SauceChoice = sauce;
                            cust.WhippedCream = whippedCream;
                            cust.Cherry = cherry;
                            cust.Peanuts = peanuts;
                            _iceCream.Add(cust);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Finds all possible options for winter swirl and adds them to the list.
        /// </summary>
        private static void WinterSwirlOptions()
        {
            WinterSwirl ws = new();
            foreach (IceCreamSauce sauce in ws.SauceOptions)
            {
                foreach (IceCreamMixIn mixIn in ws.MixInOptions)
                {
                    WinterSwirl cust = new();
                    cust.MixInChoice = mixIn;
                    cust.SauceChoice = sauce;
                    _iceCream.Add(cust);
                }
            }
        }

        /// <summary>
        /// Finds all possible options for ice cram cone and adds them to the list.
        /// </summary>
        private static void IceCreamConeOptions()
        {
            IceCreamCone iceCreamCone = new();
            for(uint scoops = 1; scoops <= iceCreamCone.MaxScoops; scoops++)
            {
                foreach(Cone cone in iceCreamCone.ConeOptions)
                {
                    foreach(bool dipped in new[] { true, false })
                    {
                        IceCreamCone cust = new();
                        cust.Scoops = scoops;
                        cust.TypeOfCone = cone;
                        cust.Dipped = dipped;
                        _iceCream.Add(cust);
                    }
                }
            }
        }

        /// <summary>
        /// Finds all possible drink options and adds them to the list.
        /// </summary>
        private static void DrinkOptions()
        {
            List<Drink> drinks = new List<Drink>
            {
                new Coffee(),
                new Latte(),
                new Mocha()
            };
            
            foreach(Drink defaultDrink in drinks)
            {
                foreach (CoffeeSize size in defaultDrink.CupOptions)
                {
                    foreach (bool iced in new[] { true, false })
                    {
                        foreach (bool decaf in new[] { true, false })
                        {
                            if (defaultDrink is Coffee c)
                            {
                                foreach (bool cream in new[] { true, false })
                                {
                                    foreach (bool sugar in new[] { true, false })
                                    {
                                        Drink cust = (Drink)Activator.CreateInstance(defaultDrink.GetType())!;
                                        cust.SizeOfCup = size;
                                        cust.Sugar = sugar;
                                        cust.Cream = cream;
                                        cust.Iced = iced;
                                        cust.Decaf = decaf;
                                        _drinks.Add(cust);
                                    }
                                }
                            }
                            if(defaultDrink is Latte l)
                            {
                                foreach(bool vanilla in new[] { true, false })
                                {
                                    Drink cust = (Drink)Activator.CreateInstance(defaultDrink.GetType())!;
                                    cust.SizeOfCup = size;
                                    cust.Vanilla = vanilla;
                                    cust.Iced = iced;
                                    cust.Decaf = decaf;
                                    _drinks.Add(cust);
                                }
                            }
                            if(defaultDrink is Mocha m)
                            {
                                Drink cust = (Drink)Activator.CreateInstance(defaultDrink.GetType())!;
                                cust.SizeOfCup = size;
                                cust.Iced = iced;
                                cust.Decaf = decaf;
                                _drinks.Add(cust);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds the name calories and price to the topping being added to the list.
        /// </summary>
        /// <param name="topp">The topping we are getting the information for.</param>
        private static void AddTopping(BurgerTopping topp)
        {
            string name = IngredientDatabase.GetBurgerToppingName(topp);
            uint cals = IngredientDatabase.GetBurgerToppingCalories(topp);
            decimal price = IngredientDatabase.GetBurgerToppingPrice(topp);
            _toppings.Add(new Burger.BurgerIngredient(topp, name, true, true, price, cals));
        }

        /// <summary>
        /// Finds all possible burger toppings and adds them to the list.
        /// </summary>
        private static void ToppingsOptions()
        {
            AddTopping(BurgerTopping.Ketchup);
            AddTopping(BurgerTopping.Mustard);
            AddTopping(BurgerTopping.Onions);
            AddTopping(BurgerTopping.Pickles);
            AddTopping(BurgerTopping.Bacon);
            AddTopping(BurgerTopping.Lettuce);
            AddTopping(BurgerTopping.Tomato);
            AddTopping(BurgerTopping.GrilledOnions);
            AddTopping(BurgerTopping.GrilledMushrooms);
            AddTopping(BurgerTopping.BBQSauce);
            AddTopping(BurgerTopping.CrispyFriedOnions);
            AddTopping(BurgerTopping.ChipotleMayo);
        }    
    }
}
