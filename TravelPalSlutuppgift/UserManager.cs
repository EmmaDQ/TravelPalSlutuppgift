using System.Collections.Generic;
using System.Windows;

namespace TravelPalSlutuppgift
{
    internal static class UserManager
    {
        public static List<IUser> Users { get; set; } = new()

        {
            new Admin("username", "password", Countrys.Sweden),
            new User("kalle88", "hej", Countrys.Canada),
            new User("kawaii", "hej", Countrys.Japan),

        };

        public static IUser? SignedInUser { get; set; }


        public static bool AddingUser(IUser user)
        {

            Users.Add(user);

            return true;
        }


        public static void RemoveUser(IUser user)
        {
            Users.Remove(user);
        }


        public static bool UppdateUserName(IUser user, string newUser)
        {
            bool isTaken = UserName(newUser.Trim());

            if (!isTaken)
            {
                user.UserName = newUser;
                return true;
            }

            return false;

        }


        private static bool UserName(string? username)
        {

            if (!string.IsNullOrWhiteSpace(username))
            {
                foreach (IUser user in Users)
                {
                    if (user.UserName == username)
                        return true;
                }

            }

            return false;

        }


        public static bool SignInUser(string username, string password)
        {
            bool isUser = UserName(username);
            //Går igenom listan och kollar om det finns en match i username och lösenord
            //Öppnar då nästa fönster

            if (isUser)
            {
                foreach (IUser user in Users)
                {
                    if (user.UserName == username && user.Password == password)
                    {
                        //SignedInUser sätts till null här.. Fixa det!
                        //
                        //
                        SignedInUser = user;    //<------------------

                        TravelsWindow travelwin = new TravelsWindow(user);

                        travelwin.Show();

                        return true;

                    }

                }
                MessageBox.Show("Password not correct, please type in correct password!", "Wrong password");
                return false;
            }

            else
            {
                MessageBox.Show("Username not found, please type in correct username!", "User not found");
                return false;
            }


            return false;

        }


        public static bool RegisterUser(string username, string password, string passwordAgain, Countrys country)
        {
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(passwordAgain) && !string.IsNullOrEmpty(username))
            {


                if (password == passwordAgain)
                {

                    if (!UserName(username))
                    {
                        IUser newUser = new User(username, password, country);


                        AddingUser(newUser);

                        SignedInUser = newUser;

                        TravelsWindow travelsWindow = new TravelsWindow(newUser);
                        travelsWindow.Show();


                        return true;

                    }

                    else
                    {
                        MessageBox.Show("Username already taken, please try again!", "Error username taken");

                        return false;
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




