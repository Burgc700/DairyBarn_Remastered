using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of BrownieSundae class
    /// </summary>
    public class BrownieSundae
    {
        /// <summary>
        /// The name of the BrownieSundae instance
        /// </summary>
        public string Name { get; } = "Brownie Sundae";

        /// <summary>
        /// The description of this sundae
        /// </summary>
        public string Description { get; } = "A decadent sundae with two scoops of ice cream, whipped cream, cherry, and hot fudge on top of a gooey brownie";

        /// <summary>
        /// Whether this sundae contains hot fudge
        /// </summary>
        public bool HotFudge { get; set; } = true;

        /// <summary>
        /// Whether this sundae contains Whipped Cream
        /// </summary>
        public bool WhippedCream { get; set; } = true;

        /// <summary>
        /// Whether this sundae contains cherry
        /// </summary>
        public bool Cherry { get; set; } = true;

        /// <summary>
        /// Whether this sundae contains peanuts
        /// </summary>
        public bool Peanuts { get; set; } = false;

        /// <summary>
        /// The price of this sundae.
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
                uint cals = 910;

                if(WhippedCream == false)
                {
                    cals -= 80;
                }
                else if(Cherry == false)
                {
                    cals -= 10;
                }
                else if(HotFudge == false)
                {
                    cals -= 130;
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

                if(HotFudge == false)
                {
                    instructions.Add("Hold Hot Fudge");
                }
                else if(WhippedCream == false)
                {
                    instructions.Add("Hold Whipped Cream");
                }
                else if(Cherry == false)
                {
                    instructions.Add("Hold Cherry");
                }
                else if(Peanuts == true)
                {
                    instructions.Add("Add Peanuts");
                }

                return instructions;
            }
        }

    }
}
