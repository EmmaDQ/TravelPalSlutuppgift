﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TravelPalSlutuppgift
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        IUser? umSignedIn = (IUser?)UserManager.SignedInUser;

        public TravelsWindow()
        {

            InitializeComponent();


            lblTitleTravelWin.Content = $"Welcome {umSignedIn?.UserName} from {umSignedIn?.Location}";



            UpdateUI();

        }



        private void btnUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow();
            addTravelWindow.Show();

            Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show
                ("Welcome to TravelPal, your ultimate travel companion\n" +
                "for adventures around the world. \n" +
                "We are dedicated to crafting memorable journeys and \n" +
                "experiences tailored to your preferences. \n" +
                "Whether you're longing for relaxation on a tropical beach, \n" +
                "thrilling urban exploration, or a cultural immersion, \n" +
                "TravelPal is your trusted partner on the path to your dream vacation. \n" +
                "With us, every trip is an opportunity to \n" +
                "create your own travel memories. \n" +
                "Welcome to TravelPal - your journey, your companion.\n" +
                "\n" +
                "" +
                "How to use you user page: \n" +
                "USER takes you to your user page. Here you \n" +
                "can change your personal information. \n" +
                "ADD TRAVEL takes you to the page were you \n" +
                "can plan for your new trip. \n" +
                "DETAILS get you more details on the trip \n" +
                "you already have registred. Just click on \n" +
                "the one you want to know more about and then\n" +
                "press DETAILS.\n" +
                "REMOVE let's you remove a trip from your triplist,\n" +
                "Just click on the trip you want to remove and\n" +
                "then press the REMOVE botton.\n" +
                "The SIGN OUT botton lets you sign out and takes \n" +
                "you back to the LOG IN page.", "Information");
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            umSignedIn = null;

            Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

            ListBoxItem? selectedItem = (ListBoxItem)lstTravelInfo.SelectedItem;

            if (selectedItem != null)
            {
                Travel travel = (Travel)selectedItem.Tag;

                lstTravelInfo.Items.Remove(travel);


                List<Travel> travelsList = (List<Travel>)TravelManager.Travels;

                travelsList.Remove(travel);

                TravelManager.Travels.Remove(travel);


                UpdateUI();
            }

            else MessageBox.Show("Please choose a travel to remove", "No selection");



        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem? selectedItem = (ListBoxItem)lstTravelInfo.SelectedItem;

            if (selectedItem != null)
            {

                Travel travel = (Travel)selectedItem.Tag;

                TravelDetailsWindow trvlDetailsWin = new TravelDetailsWindow(travel);

                trvlDetailsWin.Show();

                Close();

            }


            else MessageBox.Show("Please choose a travel to get more detailed information", "No selection");


        }

        private void lstTravelInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateUI()
        {
            lstTravelInfo.Items.Clear();

            List<Travel> travels = TravelManager.Travels;


            if (umSignedIn?.GetType() == typeof(Admin))
            {
                foreach (Travel travel in travels)
                {
                    ListBoxItem item = new();
                    item.Tag = travel;
                    item.Content = $"{travel.User.UserName}, {travel.Country} - ({travel.DestinationCity})";

                    lstTravelInfo.Items.Add(item);
                }
            }


            else
            {
                foreach (Travel travel in travels)
                {
                    if (travel.User.UserName == umSignedIn?.UserName)
                    {
                        ListBoxItem item = new();
                        item.Tag = travel;
                        item.Content = $"{travel.Country} - ({travel.DestinationCity})";

                        lstTravelInfo.Items.Add(item);

                    }

                }



            }


        }
    }
}
