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
        AddTravelWindow addTravelWindow = new AddTravelWindow();

        public TravelDetailsWindow(Travel travel)
        {
            InitializeComponent();


            if (travel.GetType() == typeof(Vacation))
            {
                Vacation vacTravel = (Vacation)travel;

                lblMeetingDetailsTD.Visibility = Visibility.Hidden;
                txtMeetingDetailsTD.Visibility = Visibility.Hidden;
                txtQuantityTD.Visibility = Visibility.Hidden;
                cbRequiredTD.Visibility = Visibility.Hidden;

                txtCityTD.Text = vacTravel.DestinationCity;
                txtCityTD.IsEnabled = false;

                txtPeopleTravelingTD.Text = vacTravel.Travelers.ToString();
                txtPeopleTravelingTD.IsEnabled = false;

                cbAllInclusiveTD.IsChecked = vacTravel.IsAllInclusive;
                cbAllInclusiveTD.IsEnabled = false;


                ComboBox item = new();

                foreach (Countrys country in Countrys.GetValues(typeof(Countrys)))
                {
                    item.Tag = country;
                    item.Text = country.ToString();
                    cbxDestinationTD.Items.Add(item);
                }

                int num = (int)vacTravel.Country;
                cbxDestinationTD.SelectedIndex = num;

                cbxDestinationTD.IsEnabled = false;

                List<string> fill2 = addTravelWindow.fill;
                ComboBox item2 = new();

                foreach (string fill in fill2)
                {
                    item2.Text = fill;
                    cbxPurposeTD.Items.Add(item2);
                }

                cbxPurposeTD.SelectedIndex = 2;



            }

            else if (travel!.GetType() == typeof(WorkTrip))
            {
                //Gör travel till en worktrip så att man kan komma åt extra informationen från den klassen
                WorkTrip workTravel = (WorkTrip)travel;

                cbAllInclusiveTD.Visibility = Visibility.Hidden;
                txtQuantityTD.Visibility = Visibility.Hidden;
                cbRequiredTD.Visibility = Visibility.Hidden;

                txtCityTD.Text = workTravel.DestinationCity;
                txtCityTD.IsEnabled = false;

                txtPeopleTravelingTD.Text = workTravel.Travelers.ToString();
                txtPeopleTravelingTD.IsEnabled = false;

                txtMeetingDetailsTD.Text = workTravel.MeetingDetails;
                txtMeetingDetailsTD.IsEnabled = false;

                ComboBox item = new();

                foreach (Countrys country in Countrys.GetValues(typeof(Countrys)))
                {
                    item.Tag = country;
                    item.Text = country.ToString();
                    cbxDestinationTD.Items.Add(item);
                }

                int num = (int)workTravel.Country;
                cbxDestinationTD.SelectedIndex = num;

                cbxDestinationTD.IsEnabled = false;

                List<string> fill2 = addTravelWindow.fill;
                ComboBox item2 = new();

                foreach (string fill in fill2)
                {
                    item2.Text = fill;
                    cbxPurposeTD.Items.Add(item2);
                }

                cbxPurposeTD.SelectedIndex = 1;

            }







        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {



        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow tWin = new TravelsWindow(UserManager.SignedInUser);

            tWin.Show();

            Close();
        }
    }
}
