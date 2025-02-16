using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of the Mocha class.
    /// </summary>
    public class Mocha : Drink
    {
        /// <summary>
        /// The name of the Mocha instance.
        /// </summary>
        public override string Name { get; } = "Mocha";

        /// <summary>
        /// The description of this drink.
        /// </summary>
        public override string Description { get; } = "Chocolate, espresso, and steamed milk with decaf and ice options available.";

        /// <summary>
        /// The price of this drink.
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 3.99m;
                if (SizeOfCup == CoffeeSize.Grande)
                {
                    cost += .75m;
                }
                else if (SizeOfCup == CoffeeSize.Venti)
                {
                    cost += 1.25m;
                }

                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in this drink.
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 200;
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
        /// Information for the preparation of this drink.
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (Iced == true)
                {
                    instructions.Add("Iced.");
                }
                if (Decaf == true)
                {
                    instructions.Add("Decaf.");
                }
                if (SizeOfCup == CoffeeSize.Grande)
                {
                    instructions.Add("Grande.");
                }
                if (SizeOfCup == CoffeeSize.Venti)
                {
                    instructions.Add("Venti.");
                }

                return instructions;
            }
        }

        public Mocha()
        {
            _sizeOfCup = CoffeeSize.Tall;
            Iced = false;
            Decaf = false;
        }
    }
}
