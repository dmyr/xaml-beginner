using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RestaurantManager.UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderPage : Page
    {
        private List<string> selectedOrderItems;

        public OrderPage()
        {
            this.InitializeComponent();

            selectedOrderItems = SelectedOrderItemsList.ItemsSource as List<string>;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                if (this.Frame.CanGoBack)
                {
                    this.Frame.GoBack();
                } else
                {
                    this.Frame.Navigate(typeof(MainPage));
                }
            }
        }

        private void SubmitOrderButton_Click(object sender, RoutedEventArgs e)
        {
            string menuItems = String.Join(", ", selectedOrderItems.ToArray());

            (Application.Current.Resources["DataManager"] as RestaurantManager.Models.DataManager).OrderItems.Add(menuItems);

            selectedOrderItems.Clear();
        }

        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrderItemsList.SelectedItems.Count > 0)
            {
                selectedOrderItems.Add(OrderItemsList.SelectedItem.ToString());
            }

        }
    }
}
