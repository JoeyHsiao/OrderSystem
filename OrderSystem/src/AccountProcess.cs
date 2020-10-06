using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.src
{
    class AccountProcess
    {
        private string UsersAccountPath = @".\Usersinfo.csv";
        private enum UserAttributes
        {
            Account=0,
            Password=1,
            Email=2
        }

        /**
         * 
         * Check account is exist ot not
         * return <bool>
         *      file is exist or not
         * 
        **/
        private bool CheckAccountFile()
        {
            if (!File.Exists(UsersAccountPath))
            {
                string fileAttributes = "";
                foreach (string s in Enum.GetNames(typeof(UserAttributes)))
                {
                    fileAttributes = fileAttributes + s + ",";
                }
                fileAttributes = fileAttributes.Remove(fileAttributes.Length - 1, 1) + "\n";
                File.WriteAllText(UsersAccountPath, fileAttributes);

                return false;
            }

            return true;
        }

        /**
         * 
         * Register user account
         * return <bool>
         *      register is success or not
         * 
        **/
        public bool Register(string userAccount, string userPassword, string userEmail)
        {
            // Create csv file for users' account
            CheckAccountFile();

            string[] accountFileLines = System.IO.File.ReadAllLines(UsersAccountPath);

            for ( int i = 1; i < accountFileLines.Length; i++ )
            {
                if ( userAccount == accountFileLines[i].Split(',')[0] )
                    return false;
            }

            string userinfo = userAccount + "," + userPassword + "," + userEmail + "\n";
            File.AppendAllText(UsersAccountPath, userinfo);
            
            return true;
        }

        /**
         * 
         * Search user's password
         * return <string, string>
         *      first is user's password
         *      if password not found will return error type in second
         * 
        **/
        public Tuple<string, string> SearchPassword(string userAccount, string userEmail)
        {
            if ( !CheckAccountFile() )
                return Tuple.Create("", "NOACCOUNT");

            string[] fileLines = System.IO.File.ReadAllLines(UsersAccountPath);
            int accountIndex = (int)UserAttributes.Account;
            int passwordIndex = (int)UserAttributes.Password;
            int emailIndex = (int)UserAttributes.Email;

            for ( int i = 1; i < fileLines.Length; i++ )
            {
                string[] a = fileLines[i].Split(',');
                if (userAccount == a[accountIndex] )
                {
                    if ( userEmail == a[emailIndex] )
                    {
                        return Tuple.Create(a[passwordIndex], "");
                    }
                    else
                    {
                        return Tuple.Create("", "ERRORMATCH");
                    }

                }
            }

            return Tuple.Create("", "NOACCOUNT");
        }

        /**
         * 
         * Compare account and password is correct or not
         * return <bool>
         *      account and password is correct or not
         * 
        **/
        public bool Login(string userAccount, string userPassword)
        {
            if ( !CheckAccountFile() )
                return false;

            string[] fileLines = System.IO.File.ReadAllLines(UsersAccountPath);
            int accountIndex = (int)UserAttributes.Account;
            int passwordIndex = (int)UserAttributes.Password;

            for ( int i = 1; i < fileLines.Length; i++ )
            {
                string[] a = fileLines[i].Split(',');
                if ( userAccount == a[accountIndex] )
                {
                    if ( userPassword == a[passwordIndex] )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            
            return false;
        }
    }
}
