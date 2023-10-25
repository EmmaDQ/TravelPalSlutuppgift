using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TravelPalSlutuppgift
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<User> users = new List<User>
        {
            new User("username", "password", Countrys.Sweden),
        };


        public MainWindow()
        {
            InitializeComponent();

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
            if (cbNoAccount.IsChecked == false)
            {

                //Går igenom listan och kollar om det finns en match i username och lösenord
                //Öppnar då nästa fönster
                foreach (User user in users)
                {
                    if (txtUserName.Text == user.UserName && txtPassword.Text == user.Password)
                    {
                        TravelsWindow travelwin = new TravelsWindow();

                        travelwin.Show();

                        Close();
                    }

                    else
                    {
                        MessageBox.Show("Something went wrong, please type in correct information!", "User not found");
                    }
                }
            }

            else
            {
                //Checkbox är ibockad och användaren vill registrera sig
                //Lägg till användare i listan av users

                if (!string.IsNullOrEmpty(txtPassword.Text.Trim()) && !string.IsNullOrEmpty(txtPasswordAgain.Text.Trim()) && !string.IsNullOrEmpty(txtUserName.Text.Trim()) && cbxChooseCountryMain.SelectedIndex != 0)
                {
                    if (txtPassword.Text == txtPasswordAgain.Text)
                    {
                        ComboBox chooseCountry = new ComboBox();
                        ComboBox selectedItem = (ComboBox)chooseCountry.SelectedItem;



                        Countrys country = (Countrys)selectedItem.Tag;


                        User user = new(txtUserName.Text, txtPasswordAgain.Text, country);

                        foreach (User user2 in users)
                        {
                            if (user2 == user)
                            {
                                MessageBox.Show("Username and or password is allready taken");
                            }

                            else
                            {
                                users.Add(user);
                            }
                        }

                    }

                    else MessageBox.Show("Your passwords doen't match, please try again", "Password discreppency");
                }

                else MessageBox.Show("Please fill in all the details!", "Empty boxes");
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
            if (cbNoAccount.IsChecked == false)
            {
                lblHeader.Content = "Log in";
                btnLogOrRegister.Content = "Sign in";
            }


        }
    }
}
