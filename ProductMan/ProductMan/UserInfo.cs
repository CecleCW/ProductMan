using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMan
{
    public class UserInfo
    {
        private string userID;
        private string userName;
        private string password;
        private int userType;
        private string fullName;
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public int UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
    }
}
