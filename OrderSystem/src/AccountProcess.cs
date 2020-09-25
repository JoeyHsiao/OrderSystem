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
    }
}
