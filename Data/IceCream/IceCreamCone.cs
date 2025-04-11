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
    public class IceCreamCone : IceCream
    {
        /// <summary>
        /// The name of the IceCreamCone instance
        /// </summary>
        public override string Name { get; } = "Ice Cream Cone";

        /// <summary>
        /// The description of the ice cream cone.
        /// </summary>
        public override string Description { get; } = "Vanilla ice cream in your choice of cone or cup";

        /// <summary>
        /// The default value for if this ice cream is dipped.
        /// </summary>
        private bool _dipped = false;

        /// <summary>
        /// Whether the ice cream cone is dipped
        /// </summary>
        public bool Dipped
        {
            get => _dipped;
            set
            {
                _dipped = value;
                OnPropertyChanged(nameof(Dipped));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The default value for the type of cone for this ice cream.
        /// </summary>
        private Cone _typeOfCone = Cone.Cake;

        /// <summary>
        /// The type of cone the ice cream comes in.
        /// </summary>
        public Cone TypeOfCone
        {
            get => _typeOfCone;
            set
            {
                _typeOfCone = value;
                OnPropertyChanged(nameof(TypeOfCone));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The price of this ice cream cone
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 2.49m;

                if (Dipped == true)
                {
                    cost += .50m;
                    if(Scoops == 2)
                    {
                        cost += .50m;
                    }
                }
                
                if (Scoops == 2)
                {
                    cost += 1.00m;
                }
                if (TypeOfCone == Cone.Waffle)
                {
                    cost += 1.00m;
                }
                if (TypeOfCone == Cone.ChocolateWaffle)
                {
                    cost += 1.50m;
                }

                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in this ice cream cone
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 245;

                if (TypeOfCone != Cone.Cake)
                {
                    cals -= 25;
                }
                if (Dipped == true && Scoops == 1)
                {
                    cals += 100;
                }
                if(Dipped == false && Scoops == 2)
                {
                    cals += 220;
                }
                if (Scoops == 2 && Dipped == true)
                {
                    cals += 220;
                    cals += 100;
                }
                if (TypeOfCone == Cone.Waffle)
                {
                    cals += 130;
                }
                if (TypeOfCone == Cone.ChocolateWaffle)
                {
                    cals += 180;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this ice cream cone
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (TypeOfCone != Cone.Cake && TypeOfCone == Cone.None)
                {
                    instructions.Add("In Cup");
                }
                if (Dipped == true)
                {
                    instructions.Add("Dipped");
                }
                if (Scoops == 2)
                {
                    instructions.Add("2 Scoops");
                }
                if (TypeOfCone == Cone.ChocolateWaffle)
                {
                    instructions.Add("Add Chocolate Waffle Cone.");
                }
                if (TypeOfCone == Cone.Waffle)
                {
                    instructions.Add("Add Waffle cone.");
                }

                return instructions;
            }    
        }

        /// <summary>
        /// Default Cone Option
        /// </summary>
        protected Cone _coneOption;

        /// <summary>
        /// The default cone choice for the ice cream cone.
        /// </summary>
        protected Cone _defaultCone = Cone.Cake;

        /// <summary>
        /// List of valid cones
        /// </summary>
        public List<Cone> ConeOptions { get; } = new();

        /// <summary>
        /// The constructor.
        /// </summary>
        public IceCreamCone()
        {
            _defaultScoops = 1;
            _minScoops = 1;
            _maxScoops = 2;
            _scoops = _defaultScoops;
            _coneOption = _defaultCone;
            ConeOptions.Add(_defaultCone);
            ConeOptions.Add(Cone.Waffle);
            ConeOptions.Add(Cone.ChocolateWaffle);
            ConeOptions.Add(Cone.None);
        }
    }
}
