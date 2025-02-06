using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of MushroomSwissBurger class
    /// </summary>
    public class MushroomSwissBurger
    {
        /// <summary>
        /// The name of the MushroomSwissBurger instance
        /// </summary>
        public string Name { get; } = "Mushroom Swiss Burger";

        /// <summary>
        /// The description of this burger
        /// </summary>
        public string Description { get; } = "A burger with grilled onions, mushroom, and Swiss cheese on top of a toasted bun";

        /// <summary>
        /// Whether this burger contains grilled onions
        /// </summary>
        public bool GrilledOnions { get; set; } = true;

        /// <summary>
        /// Whether this burger contains grilled mushrooms
        /// </summary>
        public bool GrilledMushrooms { get; set; } = true;

        /// <summary>
        /// The default type of cheese on this burger.
        /// </summary>
        private Cheese _defaultCheese = Cheese.Swiss;

        /// <summary>
        /// The types of cheese allowed on this burger.
        /// </summary>
        public Cheese TypeOfCheese
        {
            get => _defaultCheese;
            set
            {
                if(value == _defaultCheese || value == Cheese.None)
                {
                    _defaultCheese = value;
                }
            }
        }

        /// <summary>
        /// The default number of patties.
        /// </summary>
        private int _defaultPatties = 1;

        /// <summary>
        /// The number of patties allowed on this burger.
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
                decimal cost = 6.99m;
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
                uint cals = 695;

                if(TypeOfCheese != Cheese.Swiss && Patties == 2)
                {
                    cals += 350;
                }
                else if(TypeOfCheese == Cheese.Swiss && Patties == 2)
                {
                    cals += 350;
                    cals += 85;
                }
                else if(TypeOfCheese != Cheese.Swiss)
                {
                    cals -= 85;
                }
                else if(GrilledOnions == false)
                {
                    cals -= 50;
                }
                else if(GrilledMushrooms == false)
                {
                    cals -= 60;
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

                if(TypeOfCheese != Cheese.Swiss)
                {
                    instructions.Add("Hold Swiss Cheese");
                }
                else if(GrilledOnions == false)
                {
                    instructions.Add("Hold Grilled Onions");
                }
                else if(GrilledMushrooms == false)
                {
                    instructions.Add("Hold Grilled Mushrooms");
                }
                else if(Patties == 2)
                {
                    instructions.Add("Double");
                }

                return instructions;
            }
        }
    }
}
