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
                foreach (IUser user in users)
                {
                    if (username.Trim() == user.UserName)
                        return true;
                }

            }

            return false;

        }


        public bool SignInUser(string username, string password)
        {
            bool isUser = UserName(username);
            //Går igenom listan och kollar om det finns en match i username och lösenord
            //Öppnar då nästa fönster

            if (isUser)
            {
                foreach (IUser user in users)
                {
                    if (password == user.Password)
                    {
                        SignedInUser = user;

                        TravelsWindow travelwin = new TravelsWindow();

                        travelwin.Show();

                        return true;

                    }

                    else
                    {
                        MessageBox.Show("Password not correct, please type in correct password!", "Wrong password");
                    }


                }
            }

            else
            {
                MessageBox.Show("Username not found, please type in correct username!", "User not found");
            }


            return false;

        }


        public bool RegisterUser(string username, string password, string passwordAgain, Countrys country)
        {
            if (!string.IsNullOrEmpty(password.Trim()) && !string.IsNullOrEmpty(passwordAgain.Trim()) && !string.IsNullOrEmpty(username.Trim()))
            {


                if (password == passwordAgain)
                {
                    foreach (IUser user in users)
                    {
                        if (username != user.UserName)
                        {
                            IUser user2 = new User(username, passwordAgain, country);

                            AddingUser(user2);

                            TravelsWindow travelsWindow = new TravelsWindow();
                            travelsWindow.Show();


                            return true;

                        }

                        else
                        {
                            MessageBox.Show("Username already taken, please try again!", "Error username taken");

                            return false;
                        }


                    }


                }
                else
                {
                    MessageBox.Show("Your passwords did not match, please try again", "Password error");
                    return false;
                }

            }

            else
            {
                MessageBox.Show("Please fill out all the information with characters of your choosing", "No information found");
            }

            return false;

        }


    }

}




