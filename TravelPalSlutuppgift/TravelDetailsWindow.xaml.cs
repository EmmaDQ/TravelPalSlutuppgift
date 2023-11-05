using System.Collections.Generic;
using System.Windows;

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
            cbxDestinationTD.Items.Clear();
            cbxPurposeTD.Items.Clear();


            if (travel.GetType() == typeof(Vacation))
            {
                Vacation vacTravel = (Vacation)travel;

                lblMeetingDetailsTD.Visibility = Visibility.Hidden;
                txtMeetingDetailsTD.Visibility = Visibility.Hidden;
                txtQuantityTD.Visibility = Visibility.Hidden;

                txtCityTD.Text = vacTravel.DestinationCity;
                txtCityTD.IsEnabled = false;

                txtPeopleTravelingTD.Text = vacTravel.Travelers.ToString();
                txtPeopleTravelingTD.IsEnabled = false;

                cbAllInclusiveTD.IsChecked = vacTravel.IsAllInclusive;
                cbAllInclusiveTD.IsEnabled = false;


                foreach (Countrys country in Countrys.GetValues(typeof(Countrys)))
                {
                    cbxDestinationTD.Items.Add(country);
                }

                int num = (int)vacTravel.Country;
                cbxDestinationTD.SelectedIndex = num;
                cbxDestinationTD.IsEnabled = false;


                List<string> fill2 = addTravelWindow.fill;

                foreach (string fill in fill2)
                {
                    cbxPurposeTD.Items.Add(fill);
                }

                cbxPurposeTD.SelectedIndex = 2;
                cbxPurposeTD.IsEnabled = false;

                List<PackingListItem> list = travel.PackingList;

                lstPackingTD.ItemsSource = list;
                lstPackingTD.IsEnabled = false;



            }

            else if (travel!.GetType() == typeof(WorkTrip))
            {
                //Gör travel till en worktrip så att man kan komma åt extra informationen från den klassen
                WorkTrip workTravel = (WorkTrip)travel;

                cbAllInclusiveTD.Visibility = Visibility.Hidden;
                txtQuantityTD.Visibility = Visibility.Hidden;

                txtCityTD.Text = workTravel.DestinationCity;
                txtCityTD.IsEnabled = false;

                txtPeopleTravelingTD.Text = workTravel.Travelers.ToString();
                txtPeopleTravelingTD.IsEnabled = false;

                txtMeetingDetailsTD.Text = workTravel.MeetingDetails;
                txtMeetingDetailsTD.IsEnabled = false;


                foreach (Countrys country in Countrys.GetValues(typeof(Countrys)))
                {
                    cbxDestinationTD.Items.Add(country);
                }

                int num = (int)workTravel.Country;
                cbxDestinationTD.SelectedIndex = num;

                cbxDestinationTD.IsEnabled = false;

                List<string> fill2 = addTravelWindow.fill;

                foreach (string fill in fill2)
                {
                    cbxPurposeTD.Items.Add(fill);
                }

                cbxPurposeTD.SelectedIndex = 1;
                cbxPurposeTD.IsEnabled = false;

                lstPackingTD.ItemsSource = travel.PackingList;
                lstPackingTD.IsEnabled = false;


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
