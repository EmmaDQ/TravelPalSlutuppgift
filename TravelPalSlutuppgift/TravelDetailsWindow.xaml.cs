using System.Windows;
using System.Windows.Controls;

namespace TravelPalSlutuppgift
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        //TravelManager tManager = new();

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

                CheckBox item = new();
                item.Content = vacTravel.Country;
                cbxDestinationTD.Items.Add(item);
                cbxDestinationTD.SelectedIndex = 0;
                cbxDestinationTD.IsEnabled = false;


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


                CheckBox item = new();
                item.Content = workTravel.Country;
                cbxDestinationTD.Items.Add(item);
                cbxDestinationTD.SelectedIndex = 0;
                cbxDestinationTD.IsEnabled = false;
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
