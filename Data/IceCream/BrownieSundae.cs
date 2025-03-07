using System.Xml.Linq;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of BrownieSundae class
    /// </summary>
    public class BrownieSundae : IceCream
    {
        /// <summary>
        /// The name of the BrownieSundae instance
        /// </summary>
        public override string Name { get; } = "Brownie Sundae";

        /// <summary>
        /// The description of this sundae
        /// </summary>
        public override string Description { get; } = "A decadent sundae with two scoops of ice cream, whipped cream, cherry, and hot fudge on top of a gooey brownie";

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
                uint cals = 220 * Scoops;

                if (WhippedCream == true)
                {
                    cals += 80;
                }
                if (Cherry == true)
                {
                    cals += 10;
                }
                if (SauceChoice == IceCreamSauce.HotFudge)
                {
                    cals += 130;
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

                if (SauceChoice == IceCreamSauce.HotFudge)
                {
                    instructions.Add("Hot Fudge");
                }
                if (WhippedCream == true)
                {
                    instructions.Add("Whipped Cream");
                }
                if (Cherry == true)
                {
                    instructions.Add("Cherry");
                }
                if (Peanuts == true)
                {
                    instructions.Add("Peanuts");
                }

                return instructions;
            }
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        public BrownieSundae()
        {
            _defaultScoops = 2;
            _minScoops = 2;
            _maxScoops = 2;
            _scoops = 2;
            _sauceChoice = IceCreamSauce.HotFudge;
            _defaultChoice = IceCreamSauce.HotFudge;
            SauceOptions.Add(_defaultChoice);
            SauceOptions.Add(IceCreamSauce.None);
        }
    }
}
