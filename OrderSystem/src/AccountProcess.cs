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
            Mail=2
        }

        public bool Register(string account, string password, string email)
        {
            if ( !File.Exists(UsersAccountPath) )
                File.WriteAllText(UsersAccountPath, "Account,Password,Mail\n");

            string[] accountFileLines = System.IO.File.ReadAllLines(UsersAccountPath);
            for ( int i=1; i<accountFileLines.Length; i++)
            {
                if ( account == accountFileLines[i].Split(',')[0] )
                    return false;
            }

            string userinfo = account + "," + password + "," + email + "\n";
            File.AppendAllText(UsersAccountPath, userinfo);
            
            return true;
        }

        public Tuple<string, string> SearchPassword(string account, string email)
        {
            if (!File.Exists(UsersAccountPath))
                return Tuple.Create("", "NOACCOUNT");

            string[] fileLines = System.IO.File.ReadAllLines(UsersAccountPath);
            string[] fileAttributes = fileLines[0].Split(',');
            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] a = fileLines[i].Split(',');
                if (account == a[Array.IndexOf(fileAttributes, "Account")] )
                {
                    if ( email == a[Array.IndexOf(fileAttributes, "Mail")] )
                    {
                        return Tuple.Create(a[Array.IndexOf(fileAttributes, "Password")], "");
                    }
                    else
                    {
                        return Tuple.Create("", "ERRORMATCH");
                    }

                }
            }

            return Tuple.Create("", "NOACCOUNT");
        }

        public bool Login(string account, string password)
        {
            string[] fileLines = System.IO.File.ReadAllLines(UsersAccountPath);
            int accountIndex = (int)UserAttributes.Account;
            int passwordIndex = (int)UserAttributes.Password;

            for (int i = 0; i < fileLines.Length; i++)
            {
                string[] a = fileLines[i].Split(',');
                if ( account == a[accountIndex] )
                {
                    if ( password == a[passwordIndex] )
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
