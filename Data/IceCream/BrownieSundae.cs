namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of BrownieSundae class
    /// </summary>
    public class BrownieSundae
    {
        /// <summary>
        /// The name of the BrownieSundae instance
        /// </summary>
        public string Name { get; } = "Brownie Sundae";

        /// <summary>
        /// The description of this sundae
        /// </summary>
        public string Description { get; } = "A decadent sundae with two scoops of ice cream, whipped cream, cherry, and hot fudge on top of a gooey brownie";

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
        /// The default sauce for this sundae.
        /// </summary>
        private IceCreamSauce _defaultSauce = IceCreamSauce.HotFudge;

        /// <summary>
        /// The type of sauces that can go on this sundae.
        /// </summary>
        public IceCreamSauce TypeOfSauce
        {
            get => _defaultSauce;
            set
            {
                if(value == _defaultSauce || value == IceCreamSauce.None)
                {
                    _defaultSauce = value;
                }
                else
                {
                    throw new ArgumentException("The only sauces allowed are Hot Fudge or none.");
                }

            }
        }

        /// <summary>
        /// The number of scoops of ice cream on this sundae.
        /// </summary>
        public int Scoops => 2;
        

        /// <summary>
        /// The price of this sundae.
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 5.99m;
                if(Peanuts == true)
                {
                    cost += .50m;
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
                uint cals = 910;

                if(WhippedCream == false)
                {
                    cals -= 80;
                }
                else if(Cherry == false)
                {
                    cals -= 10;
                }
                else if(TypeOfSauce != IceCreamSauce.HotFudge)
                {
                    cals -= 130;
                }
                else if(Peanuts == true)
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
                else if(WhippedCream == false)
                {
                    instructions.Add("Hold Whipped Cream");
                }
                else if(Cherry == false)
                {
                    instructions.Add("Hold Cherry");
                }
                else if(Peanuts == true)
                {
                    instructions.Add("Add Peanuts");
                }               

                return instructions;
            }
        }

    }
}
