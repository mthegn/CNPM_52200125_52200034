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
    public partial class DoiMatKhau : Form
    {
        private string us;
        private string ps;
        private int idAcc;
        BUS_Users chg;
        DTO_Users user1;
        public DoiMatKhau(string userPre, string passPre,int idAcc)
        {
            InitializeComponent();
            us = userPre;
            ps = passPre;
            this.idAcc = idAcc;
            chg = new BUS_Users();
            user1 = new DTO_Users();
        }

        private void bntXacNhan_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            string acpPass = txtAcpPass.Text;

            user1.User = us;
            user1.Pass = newPass;
            user1.IdAccess = idAcc;

            string isPasswordChanged = chg.ChangePass_BUS(user1, oldPass, acpPass, ps);

            if (isPasswordChanged == "Please, enter all infomation.")
            {
                MessageBox.Show(isPasswordChanged);
                return;
            } else if (isPasswordChanged == "Old password wrong.")
            {
                MessageBox.Show(isPasswordChanged);
            } else if (isPasswordChanged == "The new password and the confirmation password are not the same.")
            {
                MessageBox.Show(isPasswordChanged);
                return;
            }
            else if (isPasswordChanged == "The new password and old password are the same")
            {
                MessageBox.Show(isPasswordChanged);
                return;
            }
            else if (isPasswordChanged == "Password change successfully")
            {
                MessageBox.Show(isPasswordChanged); 
                if (idAcc == 1)
                {
                    TrangChuQL trangChuQL = new TrangChuQL(us, newPass, idAcc);
                    trangChuQL.Show();
                    this.Hide();
                }
                else
                {
                    TrangChuST trangChuKT = new TrangChuST(us, newPass, idAcc);
                    trangChuKT.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void DoiMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (idAcc == 1)
            {
                TrangChuQL trangChuQL = new TrangChuQL(us,ps, idAcc);
                trangChuQL.Show();
                this.Hide();
            }
            else
            {
                TrangChuST trangChuKT = new TrangChuST(us, ps, idAcc);
                trangChuKT.Show();
                this.Hide();
            }
        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            if (idAcc == 1)
            {
                TrangChuQL trangChuQL = new TrangChuQL(us, ps, idAcc);
                trangChuQL.Show();
                this.Hide();
            }
            else
            {
                TrangChuST trangChuKT = new TrangChuST(us, ps, idAcc);
                trangChuKT.Show();
                this.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtOldPass.UseSystemPasswordChar = false;
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox2.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtOldPass.UseSystemPasswordChar = true;
            pictureBox2.Enabled = false;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            txtNewPass.UseSystemPasswordChar = false;
            pictureBox4.Enabled = false;
            pictureBox4.Visible = false;
            pictureBox3.Visible = true;
            pictureBox3.Enabled = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtNewPass.UseSystemPasswordChar = true;
            pictureBox3.Enabled = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            pictureBox4.Enabled = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            txtAcpPass.UseSystemPasswordChar = false;
            pictureBox6.Enabled = false;
            pictureBox6.Visible = false;
            pictureBox5.Visible = true;
            pictureBox5.Enabled = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txtAcpPass.UseSystemPasswordChar = true;
            pictureBox5.Enabled = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = true;
            pictureBox6.Enabled = true;
        }
    }
}
