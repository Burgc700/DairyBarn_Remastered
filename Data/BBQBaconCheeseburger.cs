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
        /// Whether this burger contains cheddar cheese
        /// </summary>
        public bool CheddarCheese { get; set; } = true;

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
        /// The price of this burger
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 7.29m;
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

                if(CheddarCheese == false)
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

                if(CheddarCheese == false)
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

                return instructions;
            }
        }
    }
}
