using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DairyBarn.PointOfSale
{
    /// <summary>
    /// Interaction logic for CountBox.xaml
    /// </summary>
    public partial class CountBox : UserControl
    {
        /// <summary>
        /// Gets the count in the box.
        /// </summary>
        public uint Count
        {
            get
            {
                return (uint)GetValue(PattyCount);
            }
            set
            {
                SetValue(PattyCount, value);
            }
        }

        /// <summary>
        /// Creates the property for the count to go off of.
        /// </summary>
        public static readonly DependencyProperty PattyCount = DependencyProperty.Register(nameof(Count), typeof(uint), typeof(CountBox), new PropertyMetadata(1u));

        public CountBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Describes what will happen if the + button is selected.
        /// </summary>
        /// <param name="sender">The + button.</param>
        /// <param name="e">Increments the count property by one.</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if(Count < uint.MaxValue)
            {
                Count++;
            }
        }

        /// <summary>
        /// Describes what will happen if the - button is selected.
        /// </summary>
        /// <param name="sender">The - button.</param>
        /// <param name="e">Decrements the count property by one.</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if(Count > 0)
            {
                Count--;
            }
        }
    }
}
