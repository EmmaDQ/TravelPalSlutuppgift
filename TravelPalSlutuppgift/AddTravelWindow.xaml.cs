using System;
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
        public List<string> fill = new()
        {
            "Choose the purpose of your trip!",
            "Worktrip",
            "Vacation"
        };

        public List<PackingListItem> Pack { get; set; } = new()
        {

        };

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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            if (cbxPurposeAT.SelectedIndex == 0)
            {
                MessageBox.Show("Please choose a purpose for your travel!", "Error");
            }

            try
            {
                string? city = txtCityAT.Text.Trim();
                Countrys country = (Countrys)cbxDestinationAT.SelectedItem;
                int numPeople = int.Parse(txtPeopleTravelingAT.Text.Trim());
                string? travelItem = txtTravelItemAT.Text.Trim();
                int quantity = int.Parse(txtQuantityAT.Text.Trim());

                bool isOk = CheckForNull(lblCity.Text, city) && countryBox.SelectedIndex != 0 && CheckForNumber(lblPeopleTrav.Text, numPeople) && CheckForNull(lblTravelItem.Text, travelItem) && CheckForNumber(lblQuantityAT.Text, quantity);

                if (isOk)
                {
                    //om det är en worktrip
                    if (cbxPurposeAT.SelectedIndex == 1)
                    {
                        string? meetingDetail = txtMeetingDetailsAT.Text.Trim();
                        bool isWorktripMeeting = CheckForNull(lblMeetingDetailsAT.Text, meetingDetail);

                        if (isWorktripMeeting)
                        {
                            Travel travel = new WorkTrip(city, country, numPeople, meetingDetail, UserManager.SignedInUser);

                            TravelManager.AddTravel(travel);


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

                        Travel travel = new Vacation(city, country, numPeople, allInclusive, UserManager.SignedInUser);

                        TravelManager.AddTravel(travel);


                    }

                    else
                        MessageBox.Show("Something went wrong, please try again", "Error");

                    UpdateUI();

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

            foreach (PackingList packList in Travel.PackingList)
            {
                CheckBox cb2 = new CheckBox();
                CheckBox cb = new CheckBox();
                cb.Tag = packList;
                cb.Content = packList.Name;
                cb.Name = packList.Name;

                cb2.Tag = cb;
                cb2.Content = cb.Name + "Required ";
                cb2.Name = cb.Name + "Req";

                lstPackingAT.Items.Add(cb2);
            }

            foreach (PackingList packList in Pack)
            {
                ListBoxItem item = new ListBoxItem();
                item.Tag = packList;
                item.Content = packList.Name;
                lstPackingAddAT.Items.Add(item);
            }


            lblMeetingDetailsAT.Visibility = Visibility.Hidden;
            txtMeetingDetailsAT.Visibility = Visibility.Hidden;
            //txtQuantityAT.Visibility = Visibility.Hidden;
            cbRequiredAT.Visibility = Visibility.Hidden;
            cbAllInclusiveAT.Visibility = Visibility.Hidden;
            txtQuantityAT.Visibility = Visibility.Hidden;
            lblQuantityAT.Visibility = Visibility.Hidden;

            txtCityAT.Text = "";
            txtMeetingDetailsAT.Text = "";
            txtPeopleTravelingAT.Text = "";
            txtQuantityAT.Text = "";
            txtTravelItemAT.Text = "";

        }


        private void lstPackingAT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckBox choosen = (CheckBox)lstPackingAT.SelectedItem;

            if (choosen.IsChecked == true)
            {
                PackingList item = (PackingList)lstPackingAT.SelectedItem;

                Pack.Add(item);

            }

            lstPackingAT.SelectedItem = null;

            UpdateUI();
        }


        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            string? item = txtTravelItemAT.Text.Trim();
            int num = int.Parse(txtQuantityAT.Text.Trim());



            bool isOk = CheckForNull(lblTravelItem.Text, item) && CheckForNumber(lblQuantityAT.Text, num);

            if (isOk)
            {
                if (cbTravelDocumentsAT.IsChecked == true)
                {
                    cbRequiredAT.Visibility = Visibility.Visible;

                    bool isChecked = true;
                    PackingList packingList = new PackingList(item, isChecked);


                    Pack.Add(packingList);
                }

                else
                {
                    txtQuantityAT.Visibility = Visibility.Visible;
                    lblQuantityAT.Visibility = Visibility.Visible;



                }

            }





        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow tWin = new TravelsWindow(UserManager.SignedInUser);
            tWin.Show();

            Close();
        }


    }
}
