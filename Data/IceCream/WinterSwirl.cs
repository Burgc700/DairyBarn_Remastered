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
        /// The default value for the mix in option for this ice cream.
        /// </summary>
        private IceCreamMixIn _mixInChoice = IceCreamMixIn.Oreos;

        /// <summary>
        /// The list of mix in options
        /// </summary>
        public List<IceCreamMixIn> MixInOptions { get; } = new();

        /// <summary>
        /// What type of Mix-in this sundae has.
        /// </summary>
        public IceCreamMixIn MixInChoice
        {
            get => _mixInChoice;
            set
            {
                _mixInChoice = value;
                OnPropertyChanged(nameof(MixInChoice));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

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
                uint cals = 220 * Scoops;

                if (SauceChoice == IceCreamSauce.ChocolateSauce)
                {
                    cals += 80;
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
                    cals += 40;
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
                if (MixInChoice == IceCreamMixIn.Oreos)
                {
                    cals += 160;
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

                if (SauceChoice != IceCreamSauce.ChocolateSauce && SauceChoice == IceCreamSauce.None)
                {
                    instructions.Add("Hold Chocolate Sauce");
                }
                if (SauceChoice == IceCreamSauce.HotFudge)
                {
                    instructions.Add("Hot Fudge");
                }
                if (SauceChoice == IceCreamSauce.StrawberrySauce)
                {
                    instructions.Add("Strawberry Sauce");
                }
                if (SauceChoice == IceCreamSauce.Caramel)
                {
                    instructions.Add("Caramel");
                }
                if (SauceChoice == IceCreamSauce.CrushedPineapple)
                {
                    instructions.Add("Crushed Pineapple");
                }
                if (MixInChoice != IceCreamMixIn.Oreos)
                {
                    instructions.Add("Hold Oreos");
                }
                if (MixInChoice == IceCreamMixIn.Reeses)
                {
                    instructions.Add("Reeses.");
                }
                if (MixInChoice == IceCreamMixIn.MandMs)
                {
                    instructions.Add("M&M's.");
                }
                if (MixInChoice == IceCreamMixIn.CookieDough)
                {
                    instructions.Add("Cookie Dough");
                }

                return instructions;
            }
        }

        public WinterSwirl()
        {
            _defaultScoops = 2;
            _minScoops = 2;
            _maxScoops = 2;
            _scoops = _defaultScoops;
            _sauceChoice = IceCreamSauce.ChocolateSauce;
            _defaultChoice = IceCreamSauce.ChocolateSauce;
            SauceOptions.Add(_defaultChoice);
            SauceOptions.Add(IceCreamSauce.None);
            SauceOptions.Add(IceCreamSauce.StrawberrySauce);
            SauceOptions.Add(IceCreamSauce.HotFudge);
            SauceOptions.Add(IceCreamSauce.Caramel);
            SauceOptions.Add(IceCreamSauce.CrushedPineapple);
            MixInOptions.Add(IceCreamMixIn.CookieDough);
            MixInOptions.Add(IceCreamMixIn.Oreos);
            MixInOptions.Add(IceCreamMixIn.Reeses);
            MixInOptions.Add(IceCreamMixIn.MandMs);
        }
    }
}
