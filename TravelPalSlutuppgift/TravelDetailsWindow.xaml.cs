using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TravelPalSlutuppgift
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        TravelManager tManager = new TravelManager();
        public TravelDetailsWindow(Travel travel)
        {
            InitializeComponent();

            //lblMeetingDetailsTD.Visibility = Visibility.Hidden;
            //txtMeetingDetailsTD.Visibility = Visibility.Hidden;
            cbAllInclusiveTD.Visibility = Visibility.Hidden;
            txtQuantityTD.Visibility = Visibility.Hidden;
            cbRequiredTD.Visibility = Visibility.Hidden;





            txtCityTD.Text = travel.DestinationCity;
            txtCityTD.IsEnabled = false;
            txtPeopleTravelingTD.Text = travel.Travelers.ToString();
            txtPeopleTravelingTD.IsEnabled = false;

            List<Travel> travel2 = tManager.Travels;



            txtMeetingDetailsTD.Text = travel.


            CheckBox item = new();
            item.Content = travel.Country;
            cbxDestinationTD.Items.Add(item);
            cbxDestinationTD.SelectedIndex = 0;
            cbxDestinationTD.IsEnabled = false;



        }


    }
}
