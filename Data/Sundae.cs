namespace DairyBarn.Data
{
    public class Sundae
    {
        /// <summary>
        /// The name of the Sundae instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Sundae";

        /// <summary>
        /// The description of this sundae
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description => "Ice cream sundae with toppings";

        /// <summary>
        /// Whether this sandwich contains hot fudge
        /// </summary>
        public bool HotFudge { get; set; } = true;

        //YOU DO THIS
        //Add properties for other toppings

        /// <summary>
        /// The price of this sundae
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 0m;

                //YOU DO THIS: take customizations into account

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
                uint cals = 0;

                //YOU DO THIS: take customizations into account

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

                //YOU DO THIS: take customizations into account

                return instructions;
            }
        }
    }
}
