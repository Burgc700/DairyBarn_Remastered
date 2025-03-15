using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DairyBarn.Data;

namespace DairyBarn.PointOfSale;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new Order();
    }

    /// <summary>
    /// Clears every item from an order.
    /// </summary>
    /// <param name="sender">The cancel order click.</param>
    /// <param name="e">The button click on the button.</param>
    public void CancelOrderClick(object sender, RoutedEventArgs e)
    {
        if(DataContext is Order order)
        {
            order.Clear();
        }
    }
}