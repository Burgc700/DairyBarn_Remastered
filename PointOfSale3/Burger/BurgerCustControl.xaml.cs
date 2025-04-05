using DairyBarn.Data;
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
    /// Interaction logic for BurgerCustControl.xaml
    /// </summary>
    public partial class BurgerCustControl : UserControl
    {
        public event EventHandler<MenuItemEventArgs>? BurgerEvent;

        public BurgerCustControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the toppings that are included by default or can be included onto the burger.
        /// </summary>
        public void LoadBurgerToppings()
        {
            ingredients.Children.Clear();
            if(DataContext is Burger b)
            {
                foreach (Burger.BurgerIngredient topping in b.AllToppings.Values)
                {
                    CheckBox box = new CheckBox();
                    
                    box.Margin = new Thickness(0, 2, 0, 2);
                    box.DataContext = topping;
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath(nameof(topping.Included));
                    binding.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(box, CheckBox.IsCheckedProperty, binding);

                    TextBlock name = new TextBlock();
                    name.TextWrapping = TextWrapping.Wrap;
                    name.Text = topping.Name;
                    box.Content = name;

                    ingredients.Children.Add(box);
                }   
            }
        }

        /// <summary>
        /// Click event for the pick two button in the burger control.
        /// </summary>
        /// <param name="sender">The pick two button.</param>
        /// <param name="e">Add pick two to the order control.</param>
        public void PickTwoClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                if(DataContext is Burger burger)
                {
                    if(b.Name == "pickTwoButton")
                    {
                        burger.PartOfPickTwo = true;
                        BurgerEvent?.Invoke(this, new MenuItemEventArgs(burger));
                        
                    }
                }
            }
        }
    }
}
