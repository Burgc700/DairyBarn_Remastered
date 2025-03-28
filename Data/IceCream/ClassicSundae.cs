using System.Diagnostics.Tracing;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of ClassicSundae class
    /// </summary>
    public class ClassicSundae : IceCream
    {
        /// <summary>
        /// The name of the ClassicSundae instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Classic Sundae";

        /// <summary>
        /// The description of this sundae
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "Standard ice cream sundae with toppings";

        /// <summary>
        /// The default value for if this ice cream has peanuts.
        /// </summary>
        private bool _peanuts = false;

        /// <summary>
        /// Whether this sundae contains peanuts
        /// </summary>
        public bool Peanuts
        {
            get => _peanuts;
            set
            {
                _peanuts = value;
                OnPropertyChanged(nameof(Peanuts));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The default value for if this ice cream has whipped cream.
        /// </summary>
        private bool _whippedCream = false;

        /// <summary>
        /// Whether this sundae contains whipped cream
        /// </summary>
        public bool WhippedCream
        {
            get => _whippedCream;
            set
            {
                _whippedCream = value;
                OnPropertyChanged(nameof(WhippedCream));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The default value for if this ice cream has cherry.
        /// </summary>
        private bool _cherry = false;

        /// <summary>
        /// Whether this sundae contains cherry
        /// </summary>
        public bool Cherry
        {
            get => _cherry;
            set
            {
                _cherry = value;
                OnPropertyChanged(nameof(Cherry));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The price of this sundae
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 3.49m;
                if (Peanuts == true)
                {
                    decimal peanutCost = .50m;
                    cost += peanutCost;
                }
                if (WhippedCream == true)
                {
                    decimal whippedCreamCost = .50m;
                    cost += whippedCreamCost;
                }
                if (Scoops == 2)
                {
                    cost += 1.00m;
                }
                if (Scoops == 3)
                {
                    cost += 1.00m;
                    cost += 1.00m;
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
                uint cals = 350;

                //YOU DO THIS: take customizations into account
                if (SauceChoice != IceCreamSauce.HotFudge)
                {
                    cals -= 130;
                }
                if (Peanuts == true)
                {
                    cals += 50;
                }
                if (WhippedCream == true)
                {
                    cals += 80;
                }
                if (Cherry == true)
                {
                    cals += 10;
                }
                if (Scoops == 2)
                {
                    cals += 220;
                }
                if (Scoops == 3)
                {
                    cals += 220;
                    cals += 220;
                }
                if (SauceChoice == IceCreamSauce.Caramel)
                {
                    cals += 130;
                }
                if (SauceChoice == IceCreamSauce.ChocolateSauce)
                {
                    cals += 80;
                }
                if (SauceChoice == IceCreamSauce.StrawberrySauce)
                {
                    cals += 40;
                }
                if (SauceChoice == IceCreamSauce.CrushedPineapple)
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

                if (SauceChoice != IceCreamSauce.HotFudge && SauceChoice == IceCreamSauce.None)
                {
                    instructions.Add("Hold Hot Fudge");
                }
                if (WhippedCream == true)
                {
                    instructions.Add("Add Whipped Cream");
                }
                if (Peanuts == true)
                {
                    instructions.Add("Add Peanuts");
                }
                if (Cherry == true)
                {
                    instructions.Add("Add Cherry");
                }
                //if(Scoops == 1)
                //{
                //    instructions.Add("1 Scoop");
                //}
                if (Scoops == 2)
                {
                    instructions.Add("2 Scoops.");
                }
                if (Scoops == 3)
                {
                    instructions.Add("3 Scoops.");
                }
                if (SauceChoice == IceCreamSauce.Caramel)
                {
                    instructions.Add("Add Caramel.");
                }
                if (SauceChoice == IceCreamSauce.ChocolateSauce)
                {
                    instructions.Add("Add Chocolate Sauce.");
                }
                if (SauceChoice == IceCreamSauce.StrawberrySauce)
                {
                    instructions.Add("Add Strawberry Sauce.");
                }
                if (SauceChoice == IceCreamSauce.CrushedPineapple)
                {
                    instructions.Add("Add Crushed Pineapple.");
                }

                return instructions;
            }
        }

        public ClassicSundae()
        {
            _defaultScoops = 1;
            _minScoops = 1;
            _maxScoops = 3;
            _scoops = 1;
            _sauceChoice = IceCreamSauce.HotFudge;
            _defaultChoice = IceCreamSauce.HotFudge;
            SauceOptions.Add(_defaultChoice);
            SauceOptions.Add(IceCreamSauce.None);
            SauceOptions.Add(IceCreamSauce.StrawberrySauce);
            SauceOptions.Add(IceCreamSauce.ChocolateSauce);
            SauceOptions.Add(IceCreamSauce.Caramel);
            SauceOptions.Add(IceCreamSauce.CrushedPineapple);
        }
    }
}
