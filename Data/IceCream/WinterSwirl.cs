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
    public class WinterSwirl
    {
        /// <summary>
        /// The name of the WinterSwirl instance.
        /// </summary>
        public string Name { get; } = "Winter Swirl";

        /// <summary>
        /// The description of this sundae.
        /// </summary>
        public string Description { get; } = "A blend of vanilla ice cream with your favorite sauce and mix-in.";

        /// <summary>
        /// What type of sauce this sundae has.
        /// </summary>
        public IceCreamSauce SauceChoice { get; set; } = IceCreamSauce.ChocolateSauce;

        /// <summary>
        /// What type of Mix-in this sundae has.
        /// </summary>
        public IceCreamMixIn MixInChoice { get; set; } = IceCreamMixIn.Oreos;

        /// <summary>
        /// The price of this sundae.
        /// </summary>
        public decimal Price
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
        public uint Calories
        {
            get
            {
                uint cals = 440;

                if(SauceChoice != IceCreamSauce.ChocolateSauce)
                {
                    cals -= 80;
                }
                else if(SauceChoice == IceCreamSauce.HotFudge)
                {
                    cals += 130;
                }
                else if(SauceChoice == IceCreamSauce.Caramel)
                {
                    cals += 130;
                }
                else if(SauceChoice == IceCreamSauce.StrawberrySauce)
                {
                    cals += 80;
                }
                else if(SauceChoice == IceCreamSauce.CrushedPineapple)
                {
                    cals += 50;
                }
                else if(MixInChoice == IceCreamMixIn.MandMs)
                {
                    cals += 120;
                }
                else if(MixInChoice == IceCreamMixIn.CookieDough)
                {
                    cals += 90;
                }
                else if(MixInChoice == IceCreamMixIn.Reeses)
                {
                    cals += 90;
                }
                else if(MixInChoice != IceCreamMixIn.Oreos)
                {
                    cals -= 160;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this sundae.
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if(SauceChoice != IceCreamSauce.ChocolateSauce)
                {
                    instructions.Add("Hold Chocolate Sauce.");
                }
                else if(SauceChoice == IceCreamSauce.HotFudge)
                {
                    instructions.Add("Add Hot Fudge.");
                }
                else if(SauceChoice == IceCreamSauce.StrawberrySauce)
                {
                    instructions.Add("Add Strawberry Sauce.");
                }
                else if(SauceChoice == IceCreamSauce.Caramel)
                {
                    instructions.Add("Add Caramel.");
                }
                else if(SauceChoice == IceCreamSauce.CrushedPineapple)
                {
                    instructions.Add("Add Crushed Pineapple");
                }
                else if(MixInChoice != IceCreamMixIn.Oreos)
                {
                    instructions.Add("Hold Oreos.");
                }
                else if(MixInChoice == IceCreamMixIn.Reeses)
                {
                    instructions.Add("Add Reeses.");
                }
                else if(MixInChoice == IceCreamMixIn.MandMs)
                {
                    instructions.Add("Add M&M's.");
                }
                else if(MixInChoice == IceCreamMixIn.CookieDough)
                {
                    instructions.Add("Add Cookies Dough.");
                }

                return instructions;
            }
        }
    }
}
