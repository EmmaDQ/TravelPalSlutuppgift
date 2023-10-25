using System.Collections.Generic;
using System.Windows;

namespace TravelPalSlutuppgift
{
    internal class UserManager
    {
        public List<IUser> users = new List<IUser>()

        {
            new Admin("username", "password", Countrys.Sweden),

        };

        public IUser? SignedInUser { get; set; }


        public bool AddingUser(IUser user)
        {


            users.Add(user);

            return true;
        }


        public void RemoveUser(IUser user)
        {

        }


        public bool UppdateUserName(IUser user, string newUser)
        {
            return true;
        }


        private bool UserName(string? username)
        {
            if (!string.IsNullOrWhiteSpace(username.Trim()))
            {
                return true;
            }

            return false;

        }


        public bool SignInUser(string username, string password)
        {
            //Går igenom listan och kollar om det finns en match i username och lösenord
            //Öppnar då nästa fönster

            foreach (IUser user in users)
            {
                if (username == user.UserName && password == user.Password)
                {
                    TravelsWindow travelwin = new TravelsWindow();

                    travelwin.Show();


                    MainWindow main = new MainWindow();

                    main.Close();

                    return true;

                }

                else
                {
                    MessageBox.Show("Something went wrong, please type in correct information!", "User not found");
                }


            }

            return false;

        }


        public bool RegisterUser(string username, string password, string passwordAgain, Countrys country)
        {
            if (!string.IsNullOrEmpty(password.Trim()) && !string.IsNullOrEmpty(passwordAgain.Trim()) && !string.IsNullOrEmpty(username.Trim()))
            {


                if (password == passwordAgain)
                {
                    IUser user2 = new User(username, passwordAgain, country);


                    for (int i = 0; i < users.Count; i++)
                    {
                        AddingUser(user2);

                        TravelsWindow travelsWindow = new TravelsWindow();
                        travelsWindow.Show();

                        MainWindow main = new MainWindow();
                        main.Close();

                        break;
                    }
                    return true;
                }

            }

            else
            {
                MessageBox.Show("");
            }

            return false;

        }


    }

}




