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
	public partial class Billing : Form
	{
		Functions Con;
		public Billing()
		{
			InitializeComponent();
			Con = new Functions();
			ShowBillingList();
			GetRelationshipTbl(billingMemberTxt, "MemberTable", "MemberName", "MemberId");
		}

		private void GetRelationshipTbl(ComboBox table, string tableName, string displayMember, string valueMember)
		{

			string Query = $"select * from {tableName}";
			table.DisplayMember = Con.GetData(Query).Columns[displayMember].ToString();
			table.ValueMember = Con.GetData(Query).Columns[valueMember].ToString();
			table.DataSource = Con.GetData(Query);
		}
		private void ShowBillingList()
		{

			string Query = "select * from BillingTable";
			BillingList.DataSource = Con.GetData(Query);
		}
		private void label10_Click(object sender, EventArgs e)
		{
			Coachs coachs = new Coachs();
			coachs.Show();
			this.Hide();
		}

		private void label11_Click(object sender, EventArgs e)
		{
			Members members = new Members();
			members.Show();
			this.Hide();
		}

		private void label12_Click(object sender, EventArgs e)
		{
			MemberPackets memberPackets = new MemberPackets();
			memberPackets.Show();
			this.Hide();
		}

		private void label6_Click(object sender, EventArgs e)
		{
			Receptions receptions = new Receptions();
			receptions.Show();
			this.Hide();
		}

		private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

		private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
		private void Reset()
		{
			billingMemberTxt.Text = "";
			billingDateTxt.Text = "";
			billingPriceTxt.Text = "";
			billingStartDateTxt.Text = "";
		}
		private void confirmBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (billingMemberTxt.Text == "" || billingPriceTxt.Text == "")
				{
					MessageBox.Show("Ödemeye Ait Gerekli Bilgiler Boş veya Hatalı");
				}
				else
				{
					int Agent = Login.Id;
					int billingMember = Convert.ToInt32(billingMemberTxt.SelectedValue.ToString());
					string billingPrice = billingPriceTxt.Text;
					string Query = "insert into BillingTable values('{0}','{1}','{2}','{3}','{4}')";
					Query = string.Format(Query, Agent, billingMember, billingStartDateTxt.Value, billingDateTxt.Value, billingPrice);
					Con.setData(Query);
					ShowBillingList();
					MessageBox.Show("Ödeme Başarılı");
					Reset();
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			billingPriceTxt.Text = "";
			billingMemberTxt.SelectedIndex = -1;
		}

		private void label15_Click(object sender, EventArgs e)
		{
			Login login = new Login();
			login.Show();
			this.Hide();
		}
	}
}
