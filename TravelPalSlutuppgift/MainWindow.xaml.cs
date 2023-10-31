using System.Windows;

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
            pbPasswordAgain.Visibility = Visibility.Hidden;
            cbxChooseCountryMain.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;





        }

        private void btnLogOrRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = pbPassword.Password;
            //txtPassword.Text.Trim();
            string passwordAgain = pbPasswordAgain.Password;
            //txtPasswordAgain.Text.Trim();
            Countrys country = (Countrys)cbxChooseCountryMain.SelectedItem;




            //Vill logga in
            if (cbNoAccount.IsChecked == false)
            {
                lblPasswordAgain.Visibility = Visibility.Hidden;
                txtPasswordAgain.Visibility = Visibility.Hidden;
                pbPasswordAgain.Visibility = Visibility.Hidden;
                txtPassword.Visibility = Visibility.Hidden;
                cbxChooseCountryMain.Visibility = Visibility.Hidden;

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


            }





        }

        private void cbNoAccount_Checked(object sender, RoutedEventArgs e)
        {

            lblHeader.Content = "Register";
            btnLogOrRegister.Content = "Sign up";
            lblUserName.Content = "Choose a username";
            lblPassword.Content = "Choose a password";

            lblPasswordAgain.Visibility = Visibility;
            //txtPasswordAgain.Visibility = Visibility;
            pbPasswordAgain.Visibility = Visibility;
            cbxChooseCountryMain.Visibility = Visibility;


        }

        private void cbNoAccount_UnChecked(object sender, RoutedEventArgs e)
        {
            lblHeader.Content = "Log in";
            btnLogOrRegister.Content = "Sign in";

            lblPasswordAgain.Visibility = Visibility.Hidden;
            //txtPasswordAgain.Visibility = Visibility.Hidden;
            pbPasswordAgain.Visibility = Visibility.Hidden;
            cbxChooseCountryMain.Visibility = Visibility.Hidden;

        }

        private void cb(object sender, RoutedEventArgs e)
        {

        }
    }
}
