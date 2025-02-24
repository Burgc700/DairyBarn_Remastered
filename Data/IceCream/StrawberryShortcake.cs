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
    public class StrawBerryShortcake : IceCream
    {
        /// <summary>
        /// The name of the StrawberryShortcake instance
        /// </summary>
        public override string Name { get; } = "Strawberry Shortcake";

        /// <summary>
        /// The description of this sundae
        /// </summary>
        public override string Description { get; } = "A sundae with two scoops of ice cream, strawberry sauce, whipped cream, and a cherry all on top of buttery pound cake";

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
        public override decimal Price
        {
            get
            {
                decimal cost = 5.99m;

                if (Peanuts == true)
                {
                    cost += .50m;
                }

                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in this sundae
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 770;

                if (SauceChoice != IceCreamSauce.StrawberrySauce)
                {
                    cals -= 40;
                }
                if (WhippedCream == false)
                {
                    cals -= 80;
                }
                if (Cherry == false)
                {
                    cals -= 10;
                }
                if (Peanuts == true)
                {
                    cals += 50;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this sundae
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (SauceChoice != IceCreamSauce.StrawberrySauce)
                {
                    instructions.Add("Hold Strawberry Sauce");
                }
                if (WhippedCream == false)
                {
                    instructions.Add("Hold Whipped Cream");
                }
                if (Cherry == false)
                {
                    instructions.Add("Hold Cherry");
                }
                if (Peanuts == true)
                {
                    instructions.Add("Add Peanuts");
                }

                return instructions;
            }
        }

        public StrawBerryShortcake()
        {
            _defaultScoops = 2;
            _minScoops = 2;
            _maxScoops = 2;
            _scoops = _defaultScoops;
            _sauceChoice = IceCreamSauce.StrawberrySauce;
            _defaultChoice = IceCreamSauce.StrawberrySauce;
            SauceOptions.Add(_defaultChoice);
            SauceOptions.Add(IceCreamSauce.None);
        }
    }
}
