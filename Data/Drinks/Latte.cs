using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of Latte class.
    /// </summary>
    public class Latte : Drink
    {
        /// <summary>
        /// The name of the Latte instance.
        /// </summary>
        public override string Name { get; } = "Latte";

        /// <summary>
        /// The description of this drink.
        /// </summary>
        public override string Description { get; } = "Espresso and stream milk customized the way you like it.";

        /// <summary>
        /// If this drink has vanilla in it.
        /// </summary>
        public override bool Vanilla
        {
            get => _vanilla;
            set
            {
                _vanilla = value;
                OnPropertyChanged(nameof(Vanilla));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// Whether this drink has cream.
        /// </summary>
        public override bool Cream
        {
            get => _cream;
            set
            {
                if (_cream == false)
                {
                    _cream = value;
                }
                if (_cream == true)
                {
                    _cream = false;
                }
                OnPropertyChanged(nameof(Cream));
            }
        }

        /// <summary>
        /// Whether this drink has sugar
        /// </summary>
        public override bool Sugar
        {
            get => _sugar;
            set
            {
                if (_sugar == false)
                {
                    _sugar = value;
                }
                if (_sugar == true)
                {
                    _sugar = false;
                }
                OnPropertyChanged(nameof(Sugar));
            }
        }

        public Latte()
        {
            _sizeOfCup = CoffeeSize.Tall;
            _decaf = false;
            _iced = false;
            _vanilla = false;
            _sugar = false;
            _cream = false;
            _startingCost = 3.49m;
            _startingCals = 150;
            CupOptions.Add(CoffeeSize.Grande);
            CupOptions.Add(CoffeeSize.Tall);
            CupOptions.Add(CoffeeSize.Venti);
        }
    }
}
