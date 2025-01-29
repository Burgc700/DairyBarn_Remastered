using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of Coffee class
    /// </summary>
    public class Coffee
    {
        /// <summary>
        /// THe name of the Coffee instance
        /// </summary>
        public string Name { get; } = "Coffee";

        /// <summary>
        /// THe description of this coffee
        /// </summary>
        public string Description { get; } = "Freshly brewed coffee with decaf and iced options available";

        /// <summary>
        /// Whether this coffee is iced
        /// </summary>
        public bool Iced { get; set; } = false;

        /// <summary>
        /// Whether this coffee is decaf
        /// </summary>
        public bool Decaf { get; set; } = false;

        /// <summary>
        /// Whether this coffee contains cream
        /// </summary>
        public bool Cream { get; set; } = false;

        /// <summary>
        /// Whether this coffee contains sugar
        /// </summary>
        public bool Sugar { get; set; } = false;

        /// <summary>
        /// The price of this coffee
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 2.49m;
                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in this coffee
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 5;

                if(Decaf == true)
                {
                    cals -= 3;
                }
                else if(Cream == true)
                {
                    cals += 40;
                }
                else if(Sugar == true)
                {
                    cals += 25;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this coffee
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if(Iced == true)
                {
                    instructions.Add("Iced");
                }
                else if(Decaf == true)
                {
                    instructions.Add("Decaf");
                }
                else if(Cream == true)
                {
                    instructions.Add("Add Cream");
                }
                else if(Sugar == true)
                {
                    instructions.Add("Add Sugar");
                }

                return instructions;
            }
        }
    }
}
