using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of BBQBaconCheeseburger class
    /// </summary>
    public class BBQBaconCheeseburger
    {
        /// <summary>
        /// The name of the BBQBaconCheeseBurger instance
        /// </summary>
        public string Name { get; } = "BBQ Bacon Cheeseburger";

        /// <summary>
        /// The description of this burger
        /// </summary>
        public string Description { get; } = "A burger with smoky barbecue sauce, cheddar cheese, bacon, and crispy fried onions on top of a toasted bun";


        /// <summary>
        /// Whether this burger contains barbecue sauce
        /// </summary>
        public bool BarbecueSauce { get; set; } = true;

        /// <summary>
        /// Whether this burger contains bacon
        /// </summary>
        public bool Bacon { get; set; } = true;

        /// <summary>
        /// Whether this burger contains crispy fried onions
        /// </summary>
        public bool CrispyFriedOnions { get; set; } = true;

        /// <summary>
        /// The default cheese on this burger.
        /// </summary>
        private Cheese _defaultCheese = Cheese.Cheddar;

        /// <summary>
        /// What type of cheese is on this burger.
        /// </summary>
        public Cheese TypeOfCheese
        {
            get => _defaultCheese;
            set
            {
                if (value == _defaultCheese || value == Cheese.None)
                {
                    _defaultCheese = value;
                }
            }
        }

        /// <summary>
        /// The default number of patties for this burger.
        /// </summary>
        private int _defaultPatties = 1;

        /// <summary>
        /// The number of patties on this burger.
        /// </summary>
        public int Patties
        {
            get => _defaultPatties;
            set
            {
                if(value == _defaultPatties || value == 2)
                {
                    _defaultPatties = value;
                }
            }
        }

        /// <summary>
        /// The price of this burger
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 7.29m;
                if(Patties == 2)
                {
                    cost += 2.00m;
                }
                
                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in this burger
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 775;

                if(TypeOfCheese != Cheese.Cheddar && Patties == 2)
                {
                    cals += 350;
                }
                else if(TypeOfCheese == Cheese.Cheddar && Patties == 2)
                {
                    cals += 90;
                    cals += 350;
                }
                else if(TypeOfCheese != Cheese.Cheddar)
                {
                    cals -= 90;
                }
                else if(BarbecueSauce == false)
                {
                    cals -= 40;
                }
                else if(Bacon == false)
                {
                    cals -= 75;
                }
                else if(CrispyFriedOnions == false)
                {
                    cals -= 70;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this burger
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if(TypeOfCheese != Cheese.Cheddar)
                {
                    instructions.Add("Hold Cheddar Cheese");
                }
                else if(BarbecueSauce == false)
                {
                    instructions.Add("Hold Barbecue Sauce");
                }
                else if(Bacon == false)
                {
                    instructions.Add("Hold Bacon");
                }
                else if(CrispyFriedOnions == false)
                {
                    instructions.Add("Hold Crispy Fried Onions");
                }
                else if(Patties == 2)
                {
                    instructions.Add("Double.");
                }               

                return instructions;
            }
        }
    }
}
