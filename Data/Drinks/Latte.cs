using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of Latte class.
    /// </summary>
    public class Latte
    {
        /// <summary>
        /// The name of the Latte instance.
        /// </summary>
        public string Name { get; } = "Latte";

        /// <summary>
        /// The description of this drink.
        /// </summary>
        public string Description { get; } = "Espresso and stream milk customized the way you like it.";

        /// <summary>
        /// Whether this drink is iced.
        /// </summary>
        public bool Iced { get; set; } = false;

        /// <summary>
        /// Whether this drink is decaf.
        /// </summary>
        public bool Decaf { get; set; } = false;

        /// <summary>
        /// Whether this drink contains vanilla.
        /// </summary>
        public bool Vanilla { get; set; } = false;

        /// <summary>
        /// The size of the drink.
        /// </summary>
        public CoffeeSize SizeChoice { get; set; } = CoffeeSize.Tall;

        /// <summary>
        /// The price of this drink.
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 3.49m;

                if (SizeChoice == CoffeeSize.Grande)
                {
                    cost += .75m;
                }
                else if (SizeChoice == CoffeeSize.Venti)
                {
                    cost += 1.25m;
                }
                else if (Vanilla == true)
                {
                    cost += .24m;
                }

                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in this drink.
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 150;

                if(SizeChoice == CoffeeSize.Grande)
                {
                    cals += (uint)(cals * (16 / 12));
                }
                else if(SizeChoice == CoffeeSize.Venti)
                {
                    cals += (uint)(cals * (20 / 12));
                }
                else if(Vanilla == true)
                {
                    cals += 80;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this drink
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (Iced == true)
                {
                    instructions.Add("Iced.");
                }
                else if(Decaf == true)
                {
                    instructions.Add("Decaf.");
                }
                else if(Vanilla == true)
                {
                    instructions.Add("Add Vanilla.");
                }
                else if(SizeChoice == CoffeeSize.Grande)
                {
                    instructions.Add("Grande");
                }
                else if(SizeChoice == CoffeeSize.Venti)
                {
                    instructions.Add("Venti");
                }

                return instructions;
            }
        }
    }
}
