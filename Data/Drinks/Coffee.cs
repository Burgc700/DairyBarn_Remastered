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
    public class Coffee : Drink
    {
        /// <summary>
        /// THe name of the Coffee instance
        /// </summary>
        public override string Name { get; } = "Coffee";

        /// <summary>
        /// THe description of this coffee
        /// </summary>
        public override string Description { get; } = "Freshly brewed coffee with decaf and iced options available";

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
        public override decimal Price
        {
            get
            {
                decimal cost = 2.49m;
                if (SizeOfCup == CoffeeSize.Grande)
                {
                    cost += .75m;
                }
                if (SizeOfCup == CoffeeSize.Venti)
                {
                    cost += 1.25m;
                }
                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in this coffee
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 5;

                if (Decaf == true)
                {
                    cals -= 3;
                }
                if (Cream == true)
                {
                    cals += 40;
                }
                if (Sugar == true)
                {
                    cals += 25;
                }
                if (SizeOfCup == CoffeeSize.Grande)
                {
                    cals += (uint)(cals * (16 / 12));
                }
                if (SizeOfCup == CoffeeSize.Venti)
                {
                    cals += (uint)(cals * (20 / 12));
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this coffee
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (Iced == true)
                {
                    instructions.Add("Iced");
                }
                if (Decaf == true)
                {
                    instructions.Add("Decaf");
                }
                if (Cream == true)
                {
                    instructions.Add("Add Cream");
                }
                if (Sugar == true)
                {
                    instructions.Add("Add Sugar");
                }
                if (SizeOfCup == CoffeeSize.Grande)
                {
                    instructions.Add("Grande");
                }
                if (SizeOfCup == CoffeeSize.Venti)
                {
                    instructions.Add("Venti");
                }

                return instructions;
            }
        }

        public Coffee()
        {
            _sizeOfCup = CoffeeSize.Tall;
            Decaf = false;
            Iced = false;
        }

    }
}
