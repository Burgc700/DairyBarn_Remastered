using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of StrawberryShortcake class
    /// </summary>
    public class StrawBerryShortcake
    {
        /// <summary>
        /// The name of the StrawberryShortcake instance
        /// </summary>
        public string Name { get; } = "Strawberry Shortcake";

        /// <summary>
        /// The description of this sundae
        /// </summary>
        public string Description { get; } = "A sundae with two scoops of ice cream, strawberry sauce, whipped cream, and a cherry all on top of buttery pound cake";

        /// <summary>
        /// Whether this sundae has strawberry sauce
        /// </summary>
        public bool StrawberrySauce { get; set; } = true;

        /// <summary>
        /// Whether this sundae has whipped cream
        /// </summary>
        public bool WhippedCream { get; set; } = true;

        /// <summary>
        /// Whether this sundae has cherry
        /// </summary>
        public bool Cherry { get; set; } = true;

        /// <summary>
        /// Whether this sundae has peanuts
        /// </summary>
        public bool Peanuts { get; set; } = false;

        /// <summary>
        /// The price of this sundae
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 5.99m;

                if(Peanuts == true)
                {
                    cost += .50m;
                }

                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in this sundae
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 790;

                if(StrawberrySauce == false)
                {
                    cals -= 40;
                }
                else if(WhippedCream == false)
                {
                    cals -= 80;
                }
                else if(Cherry == false)
                {
                    cals -= 10;
                }
                else if(Peanuts == true)
                {
                    cals += 50;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this sundae
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (StrawberrySauce == false)
                {
                    instructions.Add("Hold Strawberry Sauce");
                }
                else if (WhippedCream == false)
                {
                    instructions.Add("Hold Whipped Cream");
                }
                else if (Cherry == false)
                {
                    instructions.Add("Hold Cherry");
                }
                else if (Peanuts == true)
                {
                    instructions.Add("Add Peanuts");
                }

                return instructions;
            }
        }
    }
}
