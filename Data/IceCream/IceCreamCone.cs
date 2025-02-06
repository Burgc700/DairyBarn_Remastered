using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of IceCreamCone class
    /// </summary>
    public class IceCreamCone
    {
        /// <summary>
        /// The name of the IceCreamCone instance
        /// </summary>
        public string Name { get; } = "Ice Cream Cone";

        /// <summary>
        /// The description of the ice cream cone.
        /// </summary>
        public string Description { get; } = "Vanilla ice cream in your choice of cone or cup";

        /// <summary>
        /// Whether the ice cream cone is dipped
        /// </summary>
        public bool Dipped { get; set; } = false;

        /// <summary>
        /// The default number of scoops of ice cream.
        /// </summary>
        private int _defaultScoops = 1;

        /// <summary>
        /// The number of scoops of ice cream allowed in the cone.
        /// </summary>
        public int Scoops
        {
            get => _defaultScoops;
            set
            {
                if(value == _defaultScoops || value == 2)
                {
                    _defaultScoops = value;
                }
            }
        }

        /// <summary>
        /// The type of cone the ice cream comes in.
        /// </summary>
        public Cone TypeOfCone { get; set; } = Cone.Cake;
       
        /// <summary>
        /// The price of this ice cream cone
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 2.49m;

                if(Dipped == true)
                {
                    cost += .50m;
                }
                else if(Scoops == 2 || TypeOfCone == Cone.Waffle)
                {
                    cost += 1.00m;
                }
                else if(TypeOfCone == Cone.ChocolateWaffle)
                {
                    cost += 1.50m;
                }
                else if(Scoops == 2)
                {
                    cost += .50m;
                    cost += .50m;
                }
                
                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in this ice cream cone
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 245;

                if(TypeOfCone != Cone.Cake)
                {
                    cals -= 25;
                }
                else if(Dipped == true)
                {
                    cals += 100;
                }
                else if(Scoops == 2 && Dipped == true)
                {
                    cals += 100;
                    cals += 100;
                }
                else if(TypeOfCone == Cone.Waffle)
                {
                    cals += 130;
                }
                else if(TypeOfCone == Cone.ChocolateWaffle)
                {
                    cals += 180;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this ice cream cone
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if(TypeOfCone != Cone.Cake)
                {
                    instructions.Add("In Cup");
                }
                else if(Dipped == true)
                {
                    instructions.Add("Dipped");
                }
                else if(Scoops == 2)
                {
                    instructions.Add("Double");
                }
                else if(TypeOfCone == Cone.ChocolateWaffle)
                {
                    instructions.Add("Add Chocolate Waffle Cone.");
                }
                else if(TypeOfCone == Cone.Waffle)
                {
                    instructions.Add("Add Waffle cone.");
                }

                return instructions;
            }
        }
    }
}
