using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of the WinterSwirl class.
    /// </summary>
    public class WinterSwirl : IceCream
    {
        /// <summary>
        /// The name of the WinterSwirl instance.
        /// </summary>
        public override string Name { get; } = "Winter Swirl";

        /// <summary>
        /// The description of this sundae.
        /// </summary>
        public override string Description { get; } = "A blend of vanilla ice cream with your favorite sauce and mix-in.";

        /// <summary>
        /// What type of Mix-in this sundae has.
        /// </summary>
        public IceCreamMixIn MixInChoice { get; set; } = IceCreamMixIn.Oreos;

        /// <summary>
        /// The price of this sundae.
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 4.99m;

                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in this sundae.
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 440;

                if (SauceChoice != IceCreamSauce.ChocolateSauce)
                {
                    cals -= 80;
                }
                if (SauceChoice == IceCreamSauce.HotFudge)
                {
                    cals += 130;
                }
                if (SauceChoice == IceCreamSauce.Caramel)
                {
                    cals += 130;
                }
                if (SauceChoice == IceCreamSauce.StrawberrySauce)
                {
                    cals += 80;
                }
                if (SauceChoice == IceCreamSauce.CrushedPineapple)
                {
                    cals += 50;
                }
                if (MixInChoice == IceCreamMixIn.MandMs)
                {
                    cals += 120;
                }
                if (MixInChoice == IceCreamMixIn.CookieDough)
                {
                    cals += 90;
                }
                if (MixInChoice == IceCreamMixIn.Reeses)
                {
                    cals += 90;
                }
                if (MixInChoice != IceCreamMixIn.Oreos)
                {
                    cals -= 160;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this sundae.
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (SauceChoice != IceCreamSauce.ChocolateSauce)
                {
                    instructions.Add("Hold Chocolate Sauce.");
                }
                if (SauceChoice == IceCreamSauce.HotFudge)
                {
                    instructions.Add("Add Hot Fudge.");
                }
                if (SauceChoice == IceCreamSauce.StrawberrySauce)
                {
                    instructions.Add("Add Strawberry Sauce.");
                }
                if (SauceChoice == IceCreamSauce.Caramel)
                {
                    instructions.Add("Add Caramel.");
                }
                if (SauceChoice == IceCreamSauce.CrushedPineapple)
                {
                    instructions.Add("Add Crushed Pineapple");
                }
                if (MixInChoice != IceCreamMixIn.Oreos)
                {
                    instructions.Add("Hold Oreos.");
                }
                if (MixInChoice == IceCreamMixIn.Reeses)
                {
                    instructions.Add("Add Reeses.");
                }
                if (MixInChoice == IceCreamMixIn.MandMs)
                {
                    instructions.Add("Add M&M's.");
                }
                if (MixInChoice == IceCreamMixIn.CookieDough)
                {
                    instructions.Add("Add Cookies Dough.");
                }

                return instructions;
            }
        }

        public WinterSwirl()
        {
            _defaultScoops = 2;
            _maxScoops = 2;
            _scoops = _defaultScoops;
            _sauceChoice = IceCreamSauce.ChocolateSauce;
            _defaultChoice = IceCreamSauce.ChocolateSauce;
            SauceOptions.Add(_defaultChoice);
            SauceOptions.Add(IceCreamSauce.None);
            SauceOptions.Add(IceCreamSauce.StrawberrySauce);
            SauceOptions.Add(IceCreamSauce.ChocolateSauce);
            SauceOptions.Add(IceCreamSauce.Caramel);
            SauceOptions.Add(IceCreamSauce.CrushedPineapple);
        }
    }
}
