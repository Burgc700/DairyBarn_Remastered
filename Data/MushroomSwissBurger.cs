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
        /// Whether this burger contains Swiss cheese
        /// </summary>
        public bool SwissCheese { get; set; } = true;

        /// <summary>
        /// Whether this burger contains grilled onions
        /// </summary>
        public bool GrilledOnions { get; set; } = true;

        /// <summary>
        /// Whether this burger contains grilled mushrooms
        /// </summary>
        public bool GrilledMushrooms { get; set; } = true;

        /// <summary>
        /// The price of this burger
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 6.99m;
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

                if(SwissCheese == false)
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

                if(SwissCheese == false)
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

                return instructions;
            }
        }
    }
}
