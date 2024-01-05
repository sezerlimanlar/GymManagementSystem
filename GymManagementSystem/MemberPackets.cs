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
	public partial class MemberPackets : Form
	{
		Functions Con;
		public MemberPackets()
		{
			InitializeComponent();
			Con = new Functions();
			ShowPacketList();
		}


		private void Reset()
		{
			PacketNameTxt.Text = "";
			PacketPriceTxt.Text = "";
			PacketGoalTxt.Text = "";
			PacketDurationTxt.Text = "";
		}
		private void ShowPacketList()
		{

			string Query = "select * from PacketTable";
			PacketList.DataSource = Con.GetData(Query);
		}
		private void SaveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (PacketNameTxt.Text == "" || PacketPriceTxt.Text == "" || PacketGoalTxt.Text == "" || PacketDurationTxt.Text == "")
				{
					MessageBox.Show("Yeni Paket'e Ait Gerekli Bilgiler Boş veya Hatalı");
				}
				else
				{
					string packetName = PacketNameTxt.Text;
					int packetDuration = Convert.ToInt32(PacketDurationTxt.Text);
					string packetGoal = PacketGoalTxt.Text;
					int packetPrice = Convert.ToInt32(PacketPriceTxt.Text);
					string Query = "insert into PacketTable values('{0}','{1}','{2}','{3}')";
					Query = string.Format(Query, packetName, packetDuration, packetGoal, packetPrice);
					Con.setData(Query);
					ShowPacketList();
					MessageBox.Show("Yeni Üye Paketi Oluşturuldu!");
					Reset();
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
		}

		int key = 0;
		private void PacketList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			PacketNameTxt.Text = PacketList.SelectedRows[0].Cells[1].Value.ToString();
			PacketDurationTxt.Text = PacketList.SelectedRows[0].Cells[2].Value.ToString();
			PacketGoalTxt.Text = PacketList.SelectedRows[0].Cells[3].Value.ToString();
			PacketPriceTxt.Text = PacketList.SelectedRows[0].Cells[4].Value.ToString();
			if (PacketNameTxt.Text == "")
			{
				key = 0;
			}
			else
			{
				key = Convert.ToInt32(PacketList.SelectedRows[0].Cells[0].Value.ToString());
			}


		}

		private void DeleteBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (key == 0)
				{
					MessageBox.Show("Kaldırmak İstediğiniz Üyelik Paketini Seçiniz!");
				}
				else
				{
					string Query = "delete from PacketTable where PacketId = '{0}'";
					Query = string.Format(Query, key);
					Con.setData(Query);
					ShowPacketList();
					MessageBox.Show("Mevcut Paket Kaldırıldı!");
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (PacketNameTxt.Text == "" || PacketGoalTxt.Text == "" || PacketDurationTxt.Text == "" || PacketPriceTxt.Text == "")
				{
					MessageBox.Show("Pakete Ait Gerekli Bilgiler Boş veya Hatalı");
				}
				else
				{
					string packetName = PacketNameTxt.Text;
					string packetDuration = PacketDurationTxt.Text;
					string packetGoal = PacketGoalTxt.Text;
					string packetPrice = PacketPriceTxt.Text;
					string Query = "update PacketTable set packetName='{0}', packetDuration='{1}', packetGoal='{2}', packetCost='{3}' where PacketId='{4}'";
					Query = string.Format(Query, packetName, packetDuration, packetGoal, packetPrice, key);
					Con.setData(Query);

					ShowPacketList();
					MessageBox.Show("Paket Bilgileri Düzenlendi! ");
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
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

		private void label6_Click(object sender, EventArgs e)
		{
			Receptions receptions = new Receptions();
			receptions.Show();
			this.Hide();
		}

		private void label14_Click(object sender, EventArgs e)
		{
			Billing billing = new Billing();
			billing.Show();
			this.Hide();
		}

		private void label15_Click(object sender, EventArgs e)
		{
			Login login = new Login();
			login.Show();
			this.Hide();
		}
	}
}
