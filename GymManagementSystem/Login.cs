using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
	public partial class Login : Form
	{
		Functions Con;
		public Login()
		{
			InitializeComponent();
			Con = new Functions();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{
			Receptions receptions = new Receptions();
			receptions.Show();
			this.Hide();
		}
		public static int Id;
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			if (loginUserName.Text == "" || loginPassword.Text == "")
			{
				MessageBox.Show("Kullanıcı Adı veya Şifre Boş Bırakılamaz!");
			}
			else
			{
				try
				{
					string Query = "select * from ReceptionTable where ReceptionName = '{0}' and ReceptionPassword = '{1}'";
					Query = string.Format(Query, loginUserName.Text, loginPassword.Text);
					DataTable dt = Con.GetData(Query);
					if (dt.Rows.Count == 0)
					{
						MessageBox.Show("Geçersiz Resepsiyon");
					}
					else
					{
						Id = Convert.ToInt32(dt.Rows[0][0].ToString());
						Members members = new Members();
						members.Show();
						this.Hide();

					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
	}
}
