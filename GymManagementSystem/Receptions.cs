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
	public partial class Receptions : Form
	{
		Functions Con;
		public Receptions()
		{
			InitializeComponent();
			Con = new Functions();
			ShowReceptionList();
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void ShowReceptionList()
		{

			string Query = "select * from ReceptionTable";
			ReceptionList.DataSource = Con.GetData(Query);
		}

		private void Reset()
		{
			ReceptionAddressTxt.Text = "";
			ReceptionGenderTxt.SelectedIndex = -1;
			ReceptionDobTxt.Text = "";
			ReceptionNameTxt.Text = "";
			ReceptionPasswordTxt.Text = "";
			ReceptionPhoneTxt.Text = "";
		}

		private void SaveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (ReceptionAddressTxt.Text == "" || ReceptionDobTxt.Text == "" || ReceptionGenderTxt.SelectedIndex == -1 || ReceptionNameTxt.Text == "" || ReceptionPasswordTxt.Text == "" || ReceptionPhoneTxt.Text == "")
				{
					MessageBox.Show("Resepsiyon'a Ait Gerekli Bilgiler Boş veya Hatalı");
				}
				else
				{
					string receptionName = ReceptionNameTxt.Text;
					string receptionGender = ReceptionGenderTxt.SelectedItem.ToString();
					string receptionPhone = ReceptionPhoneTxt.Text;
					string receptionPassword = ReceptionPasswordTxt.Text;
					string receptionAddress = ReceptionAddressTxt.Text;

					string Query = "insert into ReceptionTable values('{0}','{1}','{2}','{3}','{4}','{5}')";
					Query = string.Format(Query, receptionName, receptionGender, receptionPhone, receptionPassword, ReceptionDobTxt.Value, receptionAddress);
					Con.setData(Query);
					ShowReceptionList();
					MessageBox.Show("Yeni Resepsiyon Kayıt Başarılı");
					Reset();
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
		}
		int key = 0;
		private void ReceptionList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			ReceptionNameTxt.Text = ReceptionList.SelectedRows[0].Cells[1].Value.ToString();
			ReceptionGenderTxt.SelectedItem = ReceptionList.SelectedRows[0].Cells[2].Value.ToString();
			ReceptionPhoneTxt.Text = ReceptionList.SelectedRows[0].Cells[3].Value.ToString();
			ReceptionPasswordTxt.Text = ReceptionList.SelectedRows[0].Cells[4].Value.ToString();
			ReceptionDobTxt.Text = ReceptionList.SelectedRows[0].Cells[5].Value.ToString();
			ReceptionAddressTxt.Text = ReceptionList.SelectedRows[0].Cells[6].Value.ToString();
			if (ReceptionNameTxt.Text == "")
			{
				key = 0;
			}
			else
			{
				key = Convert.ToInt32(ReceptionList.SelectedRows[0].Cells[0].Value.ToString());
			}
		}

		private void DeleteBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (key == 0)
				{
					MessageBox.Show("Görevini Sonlandırmak İstediğiniz Recepsiyonu Seçiniz!");
				}
				else
				{
					string receptionName = ReceptionNameTxt.Text;
					string receptionGender = ReceptionGenderTxt.SelectedItem.ToString();
					string receptionPhone = ReceptionPhoneTxt.Text;
					string receptionPassword = ReceptionPasswordTxt.Text;
					string receptionDob = ReceptionDobTxt.Text;
					string receptionAddress = ReceptionAddressTxt.Text;
					string Query = "delete from ReceptionTable where ReceptionId = '{0}'";
					Query = string.Format(Query, key);
					Con.setData(Query);
					ShowReceptionList();
					MessageBox.Show("Resepsiyonun Görevi Sonlandırıldı!");
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
		}

		private void UpdateBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (ReceptionNameTxt.Text == "" || ReceptionPhoneTxt.Text == "" || ReceptionPasswordTxt.Text == "" || ReceptionDobTxt.Text == "" || ReceptionGenderTxt.SelectedIndex == -1 || ReceptionAddressTxt.Text == "")
				{
					MessageBox.Show("Resepsiyona Ait Gerekli Bilgiler Boş veya Hatalı");
				}
				else
				{
					string receptionName = ReceptionNameTxt.Text;
					string receptionGender = ReceptionGenderTxt.SelectedItem.ToString();
					string receptionPhone = ReceptionPhoneTxt.Text;
					string receptionPassword = ReceptionPasswordTxt.Text;
					string receptionAddress = ReceptionAddressTxt.Text;
					string Query = "update ReceptionTable set receptionName='{0}', receptionGender='{1}', receptionPhone={2}, receptionPassword='{3}', receptionDob='{4}', receptionAddress='{5}' where ReceptionId={6}";
					Query = string.Format(Query, receptionName, receptionGender, receptionPhone, receptionPassword, ReceptionDobTxt.Value, receptionAddress, key);
					Con.setData(Query);

					ShowReceptionList();
					MessageBox.Show("Resepsiyon Bilgileri Düzenlendi! ");
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

		private void label12_Click(object sender, EventArgs e)
		{
			MemberPackets memberPackets = new MemberPackets();
			memberPackets.Show();
			this.Hide();
		}

		private void label14_Click(object sender, EventArgs e)
		{
			Billing billing = new Billing();
			billing.Show();
			this.Hide();
		}
	}
}
