using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Defines an instance of the PickTwo menu item.
    /// </summary>
    public class PickTwo : IMenuItem
    {
        /// <summary>
        /// The name of the menu item.
        /// </summary>
        public string Name => "Pick Two";

        /// <summary>
        /// The description of the menu item.
        /// </summary>
        public string Description => "Any burger plus your favorite ice cream.";

        /// <summary>
        /// The choice of burger.
        /// </summary>
        public Burger BurgerChoice { get; set; } = new ClassicCheeseburger();

        /// <summary>
        /// The choice of ice cream.
        /// </summary>
        public IceCream IceCreamChoice { get; set; } = new ClassicSundae();

        /// <summary>
        /// The price of the burger and ice cream.
        /// </summary>
        public decimal Price => ((BurgerChoice.Price + IceCreamChoice.Price) * .75m);

        /// <summary>
        /// The calories for the burger and ice cream.
        /// </summary>
        public uint Calories => (BurgerChoice.Calories + IceCreamChoice.Calories);

        /// <summary>
        /// The preparation information for the burger and ice cream.
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                instructions.Add($"Burger: {BurgerChoice.Name}");
                foreach (string topping in BurgerChoice.PreparationInformation)
                {
                    instructions.Add($"\t {topping}");
                }

                instructions.Add($"Ice Cream: {IceCreamChoice.Name}");
                foreach (string topping in IceCreamChoice.PreparationInformation)
                {
                    instructions.Add($"\t {topping}");
                }

                return instructions;
            }
        }

        /// <summary>
        /// Finds the name of the items.
        /// </summary>
        /// <returns>The name of the items.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
