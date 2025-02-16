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
    public class Latte : Drink
    {
        /// <summary>
        /// The name of the Latte instance.
        /// </summary>
        public override string Name { get; } = "Latte";

        /// <summary>
        /// The description of this drink.
        /// </summary>
        public override string Description { get; } = "Espresso and stream milk customized the way you like it.";

        /// <summary>
        /// Whether this drink contains vanilla.
        /// </summary>
        public bool Vanilla { get; set; } = false;

        /// <summary>
        /// The price of this drink.
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 3.49m;

                if (SizeOfCup == CoffeeSize.Grande)
                {
                    cost += .75m;
                }
                if (SizeOfCup == CoffeeSize.Venti)
                {
                    cost += 1.25m;
                }
                if (Vanilla == true)
                {
                    cost += .24m;
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
                uint cals = 150;

                if (SizeOfCup == CoffeeSize.Grande)
                {
                    cals += (uint)(cals * (16 / 12));
                }
                if (SizeOfCup == CoffeeSize.Venti)
                {
                    cals += (uint)(cals * (20 / 12));
                }
                if (Vanilla == true)
                {
                    cals += 80;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this drink
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
                if (Vanilla == true)
                {
                    instructions.Add("Add Vanilla.");
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

        public Latte()
        {
            _sizeOfCup = CoffeeSize.Tall;
            Decaf = false;
            Iced = false;
        }
    }
}
