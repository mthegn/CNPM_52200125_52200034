using DAL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BUS_Users
    {
        // Change pass
        public string ChangePass_BUS(DTO_Users user, string oldPass, string confirmPass, string passCorrect)
        {
            if (oldPass == "" || confirmPass == "" || user.Pass == "")
            {
                return "Please, enter all infomation.";
            } else if  (passCorrect != oldPass)
            {
                return "Old password wrong.";
            } else if (user.Pass != confirmPass)
            {
                return "The new password and the confirmation password are not the same.";
            } else if (oldPass == user.Pass)
            {
                return "The new password and old password are the same";
            }

            DAL_Users.ChangePass_DAL(user.User, user.Pass);
            return "Password change successfully";
        }
        // Get User
        public DTO_Users GetUserInfo_BUS(DTO_Users user)
        {
            DTO_Users dt = new DTO_Users();
            dt = DAL_Users.GetUserInfo_DAL(user);
            return dt;
        }
        // Check login
        public string CheckLogin_BUS(string user, string pass)
        {
            if (string.IsNullOrEmpty(user))
            {
                return "User is null. Please, enter your user.";
            }
            if (string.IsNullOrEmpty(pass))
            {
                return "Password is null. Please, enter your password.";
            }

            if (DAL_Users.CheckLogin_DAL(user, pass))
            {
                return "Successful";
            } else
            {
                return "User or Password failed";
            }
        }
    }
}
