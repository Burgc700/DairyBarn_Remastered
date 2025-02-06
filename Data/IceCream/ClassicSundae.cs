using System.Diagnostics.Tracing;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of ClassicSundae class
    /// </summary>
    public class ClassicSundae
    {
        /// <summary>
        /// The name of the ClassicSundae instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Classic Sundae";

        /// <summary>
        /// The description of this sundae
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description => "Standard ice cream sundae with toppings";

        /// <summary>
        /// Whether this sundae contains peanuts
        /// </summary>
        public bool Peanuts { get; set; } = false;

        /// <summary>
        /// Whether this sundae contains whipped cream
        /// </summary>
        public bool WhippedCream { get; set; } = false;

        /// <summary>
        /// Whether this sundae contains cherry
        /// </summary>
        public bool Cherry { get; set; } = false;

        /// <summary>
        /// The type of sauce for this sundae.
        /// </summary>
        public IceCreamSauce TypeOfSauce { get; set; } = IceCreamSauce.HotFudge;

        /// <summary>
        /// Sets the default value for the number of scoops for this sundae.
        /// </summary>
        private int _numOfScoops = 1;

        /// <summary>
        /// The number of scoops this sundae has.
        /// </summary>
        public int Scoops
        {
            get => _numOfScoops;
            set
            {
                if(value == 1 || value == 2 || value == 3)
                {
                    _numOfScoops = value;
                }
            }
        }

        /// <summary>
        /// The price of this sundae
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 3.49m;
                if(Peanuts == true)
                {
                    decimal peanutCost = .50m;
                    cost += peanutCost;
                }
                else if(WhippedCream == true)
                {
                    decimal whippedCreamCost = .50m;
                    cost += whippedCreamCost;
                }
                else if(Scoops == 2)
                {
                    cost += 1.00m;
                }
                else if(Scoops == 3)
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
        public uint Calories
        {
            get
            {
                uint cals = 350;

                //YOU DO THIS: take customizations into account
                if(TypeOfSauce != IceCreamSauce.HotFudge)
                {
                    cals -= 130;
                }
                else if(Peanuts == true)
                {
                    cals += 50;
                }
                else if(WhippedCream == true)
                {
                    cals += 80;
                }
                else if(Cherry == true)
                {
                    cals += 10;
                }
                else if(Scoops == 2)
                {
                    cals += 220;
                }
                else if(Scoops == 3)
                {
                    cals += 220;
                    cals += 220;
                }
                else if(TypeOfSauce == IceCreamSauce.Caramel)
                {
                    cals += 130;
                }
                else if(TypeOfSauce == IceCreamSauce.ChocolateSauce)
                {
                    cals += 80;
                }
                else if(TypeOfSauce == IceCreamSauce.StrawberrySauce)
                {
                    cals += 40;
                }
                else if(TypeOfSauce == IceCreamSauce.CrushedPineapple)
                {
                    cals += 50;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this sundae
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if(TypeOfSauce != IceCreamSauce.HotFudge)
                {
                    instructions.Add("Hold Hot Fudge");
                }
                else if(WhippedCream == true)
                {
                    instructions.Add("Add Whipped Cream");
                }
                else if(Peanuts == true)
                {
                    instructions.Add("Add Peanuts");
                }
                else if(Cherry == true)
                {
                    instructions.Add("Add Cherry");
                }
                else if(Scoops == 1)
                {
                    instructions.Add("1 Scoop.");
                }
                else if(Scoops == 2)
                {
                    instructions.Add("2 Scoops.");
                }
                else if(Scoops == 3)
                {
                    instructions.Add("3 Scoops.");
                }
                else if(TypeOfSauce == IceCreamSauce.Caramel)
                {
                    instructions.Add("Add Caramel.");
                }
                if (TypeOfSauce == IceCreamSauce.ChocolateSauce)
                {
                    instructions.Add("Add Chocolate Sauce.");
                }
                else if(TypeOfSauce == IceCreamSauce.StrawberrySauce)
                {
                    instructions.Add("Add Strawberry Sauce.");
                }
                else if(TypeOfSauce == IceCreamSauce.CrushedPineapple)
                {
                    instructions.Add("Add Crushed Pineapple.");
                }

                return instructions;
            }
        }
    }
}
