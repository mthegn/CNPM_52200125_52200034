using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DangNhap : Form
    {
        DTO_Users users;
        DTO_Users userPresent;
        BUS_Users bus;

        public DangNhap()
        {
            InitializeComponent();
            users = new DTO_Users();
            userPresent = new DTO_Users();
            bus = new BUS_Users();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtpass.Text;

            users.User = user;
            users.Pass = pass;

            string isValidLogin = bus.CheckLogin_BUS(user, pass);

            if (isValidLogin == "User is null. Please, enter your user.")
            {
                MessageBox.Show("User is null. Please, enter your user.");
                return;
            }
            else if (isValidLogin == "Password is null. Please, enter your password.")
            {
                MessageBox.Show("Password is null. Please, enter your password.");
                return;
            }          
            else if (isValidLogin == "User or Password failed")
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }
            else if (isValidLogin == "Successful")
            {
                DTO_Users userInfo = bus.GetUserInfo_BUS(users);

                if (userInfo != null)
                {
                    userPresent.User = userInfo.User;
                    userPresent.Pass = userInfo.Pass;
                    userPresent.IdAccess = userInfo.IdAccess;
                }

                if (userPresent.IdAccess == 1)
                {
                    TrangChuQL trangChuQL = new TrangChuQL(userPresent.User, userPresent.Pass, userPresent.IdAccess);
                    trangChuQL.Show();
                    this.Hide();
                }
                else
                {
                    TrangChuST trangChuST = new TrangChuST(userPresent.User, userPresent.Pass, userPresent.IdAccess);
                    trangChuST.Show();
                    this.Hide();
                }
            }           
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = false;
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox2.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = true;
            pictureBox1.Enabled = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox2.Enabled = false;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtUser.Text = "admin1";
            txtpass.Text = "p1234";
        }
    }
}
