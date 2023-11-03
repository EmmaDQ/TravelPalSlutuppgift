using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TravelPalSlutuppgift
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        public List<string> fill = new()
        {
            "Choose the purpose of your trip!",
            "Worktrip",
            "Vacation"
        };

        public List<PackingListItem> Pack { get; set; } = new()
        {

        };

        List<PackingListItem> pack { get; set; } = new List<PackingListItem>();


        ComboBox countryBox = new ComboBox();
        int count = 1;

        public AddTravelWindow()
        {
            InitializeComponent();

            UpdateUI();

        }

        private void cbxPurposeAT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Worktrip
            if (cbxPurposeAT.SelectedIndex == 1)
            {
                txtMeetingDetailsAT.Visibility = Visibility.Visible;
                lblMeetingDetailsAT.Visibility = Visibility.Visible;

                cbAllInclusiveAT.Visibility = Visibility.Hidden;


            }

            else if (cbxPurposeAT.SelectedIndex == 2)
            {
                txtMeetingDetailsAT.Visibility = Visibility.Hidden;
                lblMeetingDetailsAT.Visibility = Visibility.Hidden;

                cbAllInclusiveAT.Visibility = Visibility.Visible;
            }

            else
            {
                txtMeetingDetailsAT.Visibility = Visibility.Hidden;
                lblMeetingDetailsAT.Visibility = Visibility.Hidden;
                cbAllInclusiveAT.Visibility = Visibility.Hidden;

            }
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            Passport();
            bool ok = false;
            if (cbxPurposeAT.SelectedIndex != 0)
            {
                ok = true;
            }

            else
            {
                MessageBox.Show("Please choose a purpose for your travel!", "Error");

            }

            try
            {
                string? city = txtCityAT.Text.Trim();
                Countrys country = (Countrys)cbxDestinationAT.SelectedItem;
                int numPeople = int.Parse(txtPeopleTravelingAT.Text.Trim());
                //string? travelItem = txtTravelItemAT.Text.Trim();
                //int quantity = int.Parse(txtQuantityAT.Text.Trim());

                bool isOk = CheckForNull(lblCity.Text, city) && countryBox.SelectedIndex != 0 && CheckForNumber(lblPeopleTrav.Text, numPeople);

                if (isOk && ok)
                {
                    //om det är en worktrip
                    if (cbxPurposeAT.SelectedIndex == 1)
                    {
                        string? meetingDetail = txtMeetingDetailsAT.Text.Trim();
                        bool isWorktripMeeting = CheckForNull(lblMeetingDetailsAT.Text, meetingDetail);


                        if (isWorktripMeeting)
                        {
                            Travel travel = new WorkTrip(city, country, numPeople, meetingDetail, UserManager.SignedInUser, Pack);

                            TravelManager.AddTravel(travel);

                            MessageBox.Show($"New worktrip to {city} for {numPeople} successfully added!", "New travel");
                        }

                    }

                    //om det är en vacation
                    else if (cbxPurposeAT.SelectedIndex == 2)
                    {
                        bool allInclusive = false;

                        if (cbAllInclusiveAT.IsChecked == true)
                        {
                            allInclusive = true;
                        }


                        Travel travel = new Vacation(city, country, numPeople, allInclusive, UserManager.SignedInUser, Pack);

                        TravelManager.AddTravel(travel);

                        MessageBox.Show($"New vacation to {city} for {numPeople} successfully added!", "New travel");

                    }

                    else
                        MessageBox.Show("Something went wrong, please try again", "Error");


                }


            }

            catch (InvalidCastException ex)
            {
                MessageBox.Show($"Wrong character!\n {ex}", "Error");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong.\n{ex}");
            }


            UpdateUI();


        }

        private void Passport()
        {

            bool isEu = false;
            bool isEuTravel = false;
            bool isNeedingPass = false;
            Countrys countr = UserManager.SignedInUser.Location;
            Countrys country = (Countrys)cbxDestinationAT.SelectedItem;


            foreach (EuCountrys eu in EuCountrys.GetValues(typeof(EuCountrys)))
            {
                if (countr == (Countrys)eu)
                {
                    isEu = true;
                }
            }

            foreach (EuCountrys eu in EuCountrys.GetValues(typeof(EuCountrys)))
            {
                if (country == (Countrys)eu)
                {
                    isEuTravel = true;
                }
            }

            for (int i = 0; i > Pack.Count; i++)
            {
                if (Pack.FirstOrDefault(u => u.Name == "Passport") != null || Pack.FirstOrDefault(u2 => u2.Name == "passport") != null)
                {
                    //Pack.Remove(listItem);
                }
            }

            if (isEu && !isEuTravel)
            {

                PackingListReq item2 = new PackingListReq("Passport", true);

                Pack.Add(item2);
            }

            else if (isEu && isEuTravel)
            {
                PackingListReq item2 = new PackingListReq("Passport", false);

                Pack.Add(item2);
            }

            else if (!isEu)
            {
                PackingListReq item2 = new PackingListReq("Passport", true);

                Pack.Add(item2);
            }
        }

        private bool CheckForNull(string box, string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                return true;

            }

            MessageBox.Show($"Please fill out {box}!", "Empty field");
            return false;
        }

        private bool CheckForNumber(string box, int num)
        {
            if (num > 0)
            {
                return true;
            }

            MessageBox.Show($"Cant add 0 {box}, please add valid number of {box}!", "Number not valid");
            return false;
        }


        private void UpdateUI()
        {
            cbxDestinationAT.Items.Clear();
            cbxPurposeAT.Items.Clear();
            lstPackingAddAT.ItemsSource = null;



            countryBox = (ComboBox)cbxDestinationAT;


            foreach (Countrys country in Countrys.GetValues(typeof(Countrys)))
            {
                countryBox.Tag = country;
                countryBox.Text = country.ToString();

                cbxDestinationAT.Items.Add(country);

            }

            countryBox.SelectedIndex = 0;


            //ComboBox purpose = new ComboBox();
            ComboBox purpose = (ComboBox)cbxPurposeAT;
            foreach (string filler in fill)
            {
                cbxPurposeAT.Items.Add(filler);
            }

            purpose.SelectedIndex = 0;



            /*foreach (PackingListItem packList in Travel.PackingList)
            {

                ListBoxItem item = new ListBoxItem();
                item.Tag = packList;
                item.Content = packList.Name;

                lstPackingAT.Items.Add(item);


                lstPackingAT.ItemsSource = (System.Collections.IEnumerable)packList;


            }*/



            lblMeetingDetailsAT.Visibility = Visibility.Hidden;
            txtMeetingDetailsAT.Visibility = Visibility.Hidden;
            //txtQuantityAT.Visibility = Visibility.Hidden;
            cbRequiredAT.Visibility = Visibility.Hidden;
            cbAllInclusiveAT.Visibility = Visibility.Hidden;
            //txtQuantityAT.Visibility = Visibility.Hidden;
            //lblQuantityAT.Visibility = Visibility.Hidden;

            txtCityAT.Text = "";
            txtMeetingDetailsAT.Text = "";
            txtPeopleTravelingAT.Text = "";
            txtQuantityAT.Text = "";
            txtTravelItemAT.Text = "";

        }



        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            string? item = txtTravelItemAT.Text.Trim();
            lstPackingAddAT.ItemsSource = null;

            if (CheckForNull(lblTravelItem.Text, item) && cbTravelDocumentsAT.IsChecked == true)
            {
                if (cbRequiredAT.IsChecked == true)
                {
                    PackingListReq item2 = new PackingListReq(item, true);
                    Pack.Add(item2);
                }

                else
                {
                    PackingListReq item2 = new PackingListReq(item, false);
                    Pack.Add(item2);
                }


            }


            else
            {
                int num = int.Parse(txtQuantityAT.Text.Trim());

                if (CheckForNumber(lblQuantityAT.Text, num))
                {
                    PackingListQuant item2 = new PackingListQuant(item, num);
                    Pack.Add(item2);
                }


            }

            lstPackingAddAT.ItemsSource = Pack;


            txtTravelItemAT.Text = "";
            txtQuantityAT.Text = "";
            cbTravelDocumentsAT.IsChecked = false;
            cbRequiredAT.IsChecked = false;


        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow tWin = new TravelsWindow(UserManager.SignedInUser);
            tWin.Show();

            Close();
        }


        private void cbTravelDocumentsAT_Checked(object sender, RoutedEventArgs e)
        {

            cbRequiredAT.Visibility = Visibility.Visible;

            txtQuantityAT.Visibility = Visibility.Hidden;
            lblQuantityAT.Visibility = Visibility.Hidden;

        }

        private void cbTravelDocumentsAT_Unchecked(object sender, RoutedEventArgs e)
        {

            txtQuantityAT.Visibility = Visibility.Visible;
            lblQuantityAT.Visibility = Visibility.Visible;

            cbRequiredAT.Visibility = Visibility.Hidden;

        }
    }
}
