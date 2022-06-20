using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestSam.MainClass
{
    class UserSession
    {
        internal static int UserId { get; set; }
        internal static string Username { get; set; }
        internal static bool IsUserEnter = false;
        internal static void GetUsername(TextBox username)
        {
            Username = username.Text;

            
        }
    }
}
