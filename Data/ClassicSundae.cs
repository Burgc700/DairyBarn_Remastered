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
        /// Whether this sundae contains hot fudge
        /// </summary>
        public bool HotFudge { get; set; } = true;

        /// <summary>
        /// Whether this sundae contains peanuts.
        /// </summary>
        public bool Peanuts { get; set; } = false;

        /// <summary>
        /// Whether this sundae contains whipped cream.
        /// </summary>
        public bool WhippedCream { get; set; } = false;

        /// <summary>
        /// Whether this sundae contains cherrys.
        /// </summary>
        public bool Cherry { get; set; } = false;

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
                if(HotFudge == false)
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

                if(HotFudge == false)
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

                return instructions;
            }
        }
    }
}
