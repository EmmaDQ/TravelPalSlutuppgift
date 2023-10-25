using System.Collections.Generic;

namespace TravelPalSlutuppgift
{
    internal class UserManager
    {
        public List<IUser> users = new List<IUser>()
        {

        };


        public IUser? SignedInUser { get; set; }


        public bool AddingUser(IUser user)
        {
            return true;
        }


        public void RemoveUser(IUser user)
        {

        }


        public bool UppdateUserName(IUser user, string newUser)
        {
            return true;
        }


        private bool UserName(string username)
        {
            return true;
        }


        public bool SignInUser(string username, string password)
        {
            return true;
        }
    }
}
