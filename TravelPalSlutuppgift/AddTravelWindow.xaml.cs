using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TravelPalSlutuppgift
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        private List<string> fill = new()
        {
            "Choose the purpose of your trip!",
            "Worktrip",
            "Vacation"
        };

        public AddTravelWindow()
        {
            InitializeComponent();

            ComboBox countryBox = new ComboBox();
            countryBox = (ComboBox)cbxDestinationAT;


            foreach (Countrys country in Countrys.GetValues(typeof(Countrys)))
            {
                countryBox.Tag = country;
                countryBox.Text = country.ToString();

                cbxDestinationAT.Items.Add(country);

            }

            countryBox.SelectedIndex = 0;


            ComboBox purpose = new ComboBox();
            purpose = (ComboBox)cbxPurposeAT;
            foreach (string filler in fill)
            {
                cbxPurposeAT.Items.Add(filler);
            }

            purpose.SelectedIndex = 0;


            lblMeetingDetailsAT.Visibility = Visibility.Hidden;
            txtMeetingDetailsAT.Visibility = Visibility.Hidden;
            txtQuantityAT.Visibility = Visibility.Hidden;
            cbRequiredAT.Visibility = Visibility.Hidden;
            cbAllInclusiveAT.Visibility = Visibility.Hidden;
            txtQuantityAT.Visibility = Visibility.Hidden;
            cbRequiredAT.Visibility = Visibility.Hidden;




        }
    }
}
