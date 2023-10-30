﻿using System.Windows;

namespace TravelPalSlutuppgift
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();


            //Fyller comboboxen men länder
            foreach (var country in Countrys.GetValues(typeof(Countrys)))
            {
                cbxChooseCountryMain.Items.Add(country);
            }

            lblPasswordAgain.Visibility = Visibility.Hidden;
            txtPasswordAgain.Visibility = Visibility.Hidden;
            cbxChooseCountryMain.Visibility = Visibility.Hidden;



        }

        private void btnLogOrRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string passwordAgain = txtPasswordAgain.Text.Trim();
            Countrys country = (Countrys)cbxChooseCountryMain.SelectedItem;


            //UserManager signInUser = (UserManager)UserManager.SignInUser(username, password);
            //UserManager registerUser = (UserManager)UserManager.RegisterUser(username, password, passwordAgain, country);



            //Vill logga in
            if (cbNoAccount.IsChecked == false)
            {

                bool isUser = UserManager.SignInUser(username, password);

                if (isUser)
                {
                    Close();
                }

            }

            else
            {

                if (cbxChooseCountryMain.SelectedIndex != 0)
                {
                    bool isRegisterd = UserManager.RegisterUser(username, password, passwordAgain, country);


                    if (isRegisterd)
                    {
                        Close();

                    }
                }

                else
                {
                    MessageBox.Show("Please choose a country of origin!", "No country selected");
                }


                //Checkbox är ibockad och användaren vill registrera sig
                //Lägg till användare i listan av users




                /*{
                    MessageBox.Show("Username and or password is allready taken");
                }*/
            }





        }

        private void cbNoAccount_Checked(object sender, RoutedEventArgs e)
        {


            if (cbNoAccount.IsChecked == true)
            {
                lblHeader.Content = "Register";
                btnLogOrRegister.Content = "Sign up";
                lblUserName.Content = "Choose a username";
                lblPassword.Content = "Choose a password";

                lblPasswordAgain.Visibility = Visibility;
                txtPasswordAgain.Visibility = Visibility;
                cbxChooseCountryMain.Visibility = Visibility;
            }


            //Ändras inte tillbaka när man checkar av boxen igen.. Kolla in detta sen!!
            else
            {
                lblHeader.Content = "Log in";
                btnLogOrRegister.Content = "Sign in";
            }


        }
    }
}
