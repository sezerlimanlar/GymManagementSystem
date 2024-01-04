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
	public partial class Coachs : Form
	{
		Functions Con;
		public Coachs()
		{
			InitializeComponent();
			Con = new Functions();
			ShowCoachList();

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void ShowCoachList()
		{

			string Query = "select * from CoachTable";
			coachList.DataSource = Con.GetData(Query);
		}

		private void SaveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (coachNameTxt.Text == "" || coachPhoneTxt.Text == "" || coachExperienceTxt.Text == "" || coachPasswordTxt.Text == "" || coachGenderTxt.SelectedIndex == -1 || coachAddressTxt.Text == "")
				{
					MessageBox.Show("Antrenöre Ait Gerekli Bilgiler Boş veya Hatalı");
				}
				else
				{
					string coachName = coachNameTxt.Text;
					string coachGender = coachGenderTxt.SelectedItem.ToString();
					string coachPhone = coachPhoneTxt.Text;
					int coachExperience = Convert.ToInt32(coachExperienceTxt.Text);
					string coachAddress = coachAddressTxt.Text;
					string coachPassword = coachPasswordTxt.Text;
					string Query = "insert into CoachTable values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
					Query = string.Format(Query, coachName, coachDobTxt.Value, coachExperience, coachAddress, coachPassword, coachPhone, coachGender);
					Con.setData(Query);
					ShowCoachList();
					MessageBox.Show("Yeni Antrenör Kayıt Başarılı");
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
		}

		int key = 0;
		private void coachList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			coachNameTxt.Text = coachList.SelectedRows[0].Cells[1].Value.ToString();
			CoachDboTxt.Text = coachList.SelectedRows[0].Cells[2].Value.ToString();
			coachExperienceTxt.Text = coachList.SelectedRows[0].Cells[3].Value.ToString();
			coachAddressTxt.Text = coachList.SelectedRows[0].Cells[4].Value.ToString();
			coachPasswordTxt.Text = coachList.SelectedRows[0].Cells[5].Value.ToString();
			coachPhoneTxt.Text = coachList.SelectedRows[0].Cells[6].Value.ToString();
			coachGenderTxt.SelectedItem = coachList.SelectedRows[0].Cells[7].Value.ToString();
			if (coachNameTxt.Text == "")
			{
				key = 0;
			}
			else
			{
				key = Convert.ToInt32(coachList.SelectedRows[0].Cells[0].Value.ToString());
			}


		}

		private void DeleteBtn_Click(object sender, EventArgs e)
		{

			try
			{
				if (key == 0)
				{
					MessageBox.Show("Görevini Sonlandırmak İstediğiniz Antrenörü Seçiniz!");
				}
				else
				{
					string coachName = coachNameTxt.Text;
					string coachGender = coachGenderTxt.SelectedItem.ToString();
					string coachPhone = coachPhoneTxt.Text;
					int coachExperience = Convert.ToInt32(coachExperienceTxt.Text);
					string coachAddress = coachAddressTxt.Text;
					string coachPassword = coachPasswordTxt.Text;
					string Query = "delete from CoachTable where CoachId = '{0}'";
					Query = string.Format(Query, key);
					Con.setData(Query);
					ShowCoachList();
					MessageBox.Show("Antrenörün Görevi Sonlandırıldı!");
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
				if (coachNameTxt.Text == "" || coachPhoneTxt.Text == "" || coachExperienceTxt.Text == "" || coachPasswordTxt.Text == "" || coachGenderTxt.SelectedIndex == -1 || coachAddressTxt.Text == "")
				{
					MessageBox.Show("Antrenöre Ait Gerekli Bilgiler Boş veya Hatalı");
				}
				else
				{
					string coachName = coachNameTxt.Text;
					string coachGender = coachGenderTxt.SelectedItem.ToString();
					string coachPhone = coachPhoneTxt.Text;
					int coachExperience = Convert.ToInt32(coachExperienceTxt.Text);
					string coachAddress = coachAddressTxt.Text;
					string coachPassword = coachPasswordTxt.Text;
					string Query = "update CoachTable set coachName='{0}', coachDob='{1}', coachExperience={2}, coachAddress='{3}', coachPassword='{4}', coachPhone='{5}', coachGender='{6}' where CoachId={7}";
					Query = string.Format(Query, coachName, coachDobTxt.Value, coachExperience, coachAddress, coachPassword, coachPhone, coachGender, key);
					Con.setData(Query);

					ShowCoachList();
					MessageBox.Show("Antrenör Bilgileri Düzenlendi! ");
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
		}
	}
}
