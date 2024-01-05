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
	public partial class Members : Form
	{
		Functions Con;
		public Members()
		{
			InitializeComponent();
			Con = new Functions();
			ShowMemberList();
			GetRelationshipTbl(membersPacketCb, "PacketTable", "PacketName", "PacketId");
			GetRelationshipTbl(membersCoachCb, "CoachTable", "CoachName", "CoachId");

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{

		}

		private void CoachMenu_Click(object sender, EventArgs e)
		{
			Coachs coachs = new Coachs();
			coachs.Show();
			this.Hide();
		}

		private void PacketsMenu_Click(object sender, EventArgs e)
		{
			MemberPackets memberPackets = new MemberPackets();
			memberPackets.Show();
			this.Hide();
		}

		private void ReceptionMenu_Click(object sender, EventArgs e)
		{
			Receptions receptions = new Receptions();
			receptions.Show();
			this.Hide();
		}

		private void BillingMenu_Click(object sender, EventArgs e)
		{
			Billing billing = new Billing();
			billing.Show();
			this.Hide();
		}

		private void ShowMemberList()
		{

			string Query = "select * from MemberTable";
			memberList.DataSource = Con.GetData(Query);
		}

		private void Reset()
		{
			memberNameTxt.Text = "";
			memberGenderCb.SelectedItem = -1;
			memberPhoneTxt.Text = "";
			membersPacketCb.SelectedItem = -1;
			membersCoachCb.SelectedItem = -1;
			memberDurationCb.SelectedItem = -1;
			memberStatusCb.SelectedItem = -1;
			memberDboTxt.Text = "";
		}

		private void GetRelationshipTbl(ComboBox table, string tableName, string displayMember, string valueMember)
		{

			string Query = $"select * from {tableName}";
			table.DisplayMember = Con.GetData(Query).Columns[displayMember].ToString();
			table.ValueMember = Con.GetData(Query).Columns[valueMember].ToString();
			table.DataSource = Con.GetData(Query);
		}
		private void saveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (memberNameTxt.Text == "" || memberPhoneTxt.Text == "" || memberDboTxt.Text == "" || memberGenderCb.SelectedIndex == -1 || membersPacketCb.SelectedIndex == -1 || membersCoachCb.SelectedIndex == -1 || memberDurationCb.SelectedIndex == -1 ||
				memberStatusCb.SelectedIndex == -1)
				{
					MessageBox.Show("Üyeye Ait Gerekli Bilgiler Boş veya Hatalı");
				}
				else
				{
					string memberName = memberNameTxt.Text;
					string memberGender = memberGenderCb.SelectedItem.ToString();
					int membersPacket = Convert.ToInt32(membersPacketCb.SelectedValue.ToString());
					int membersCoach = Convert.ToInt32(membersCoachCb.SelectedValue.ToString());
					string memberDuration = memberDurationCb.SelectedItem.ToString();
					string memberStatus = memberStatusCb.SelectedItem.ToString();
					string memberPhone = memberPhoneTxt.Text;
					string Query = "insert into MemberTable values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')";
					Query = string.Format(Query, memberName, memberGender, memberDboTxt.Value, memberStartDate.Value, membersPacket, membersCoach, memberPhone, memberDuration, memberStatus);
					Con.setData(Query);
					ShowMemberList();
					MessageBox.Show("Yeni Üye Kayıt Başarılı");
					Reset();
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
		}

		int key = 0;
		private void memberList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			memberNameTxt.Text = memberList.SelectedRows[0].Cells[1].Value.ToString();
			memberGenderCb.SelectedItem = memberList.SelectedRows[0].Cells[2].Value.ToString();
			memberDboTxt.Text = memberList.SelectedRows[0].Cells[3].Value.ToString();
			memberStartDate.Text = memberList.SelectedRows[0].Cells[3].Value.ToString();
			membersPacketCb.Text = memberList.SelectedRows[0].Cells[4].Value.ToString();
			membersCoachCb.Text = memberList.SelectedRows[0].Cells[6].Value.ToString();
			memberPhoneTxt.Text = memberList.SelectedRows[0].Cells[7].Value.ToString();
			memberDurationCb.Text = memberList.SelectedRows[0].Cells[8].Value.ToString();
			memberStatusCb.Text = memberList.SelectedRows[0].Cells[9].Value.ToString();
			if (memberNameTxt.Text == "")
			{
				key = 0;
			}
			else
			{
				key = Convert.ToInt32(memberList.SelectedRows[0].Cells[0].Value.ToString());
			}

		}

		private void editBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (memberNameTxt.Text == "" || memberPhoneTxt.Text == "" || memberDboTxt.Text == "" || memberGenderCb.SelectedIndex == -1 || membersPacketCb.SelectedIndex == -1 || membersCoachCb.SelectedIndex == -1 || memberDurationCb.SelectedIndex == -1 ||
				memberStatusCb.SelectedIndex == -1)
				{
					MessageBox.Show("Üyeye Ait Gerekli Bilgiler Boş veya Hatalı");
				}
				else
				{
					string memberName = memberNameTxt.Text;
					string memberGender = memberGenderCb.SelectedItem.ToString();
					int membersPacket = Convert.ToInt32(membersPacketCb.SelectedValue.ToString());
					int membersCoach = Convert.ToInt32(membersCoachCb.SelectedValue.ToString());
					string memberDuration = memberDurationCb.SelectedItem.ToString();
					string memberStatus = memberStatusCb.SelectedItem.ToString();
					string memberPhone = memberPhoneTxt.Text;
					string Query = "update MemberTable set memberName='{0}', memberGender='{1}', memberDob='{2}', memberDate='{3}', memberPacket='{4}', memberCoach='{5}', memberPhone='{6}', memberTiming='{7}', memberStatus='{8}' where memberId={9}";
					Query = string.Format(Query, memberName, memberGender, memberDboTxt.Value, memberStartDate.Value, membersPacket, membersCoach, memberPhone, memberDuration, memberStatus, key);
					Con.setData(Query);

					ShowMemberList();
					MessageBox.Show("Üye Bilgileri Düzenlendi! ");
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
		}

		private void deleteBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (key == 0)
				{
					MessageBox.Show("Kaydını Silmek İstediğiniz Üyeyi Seçiniz!");
				}
				else
				{
					string Query = "delete from MemberTable where MemberId = '{0}'";
					Query = string.Format(Query, key);
					Con.setData(Query);
					ShowMemberList();
					MessageBox.Show("Üyenin Kaydı Slindi!");
				}
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
		}

		private void label15_Click(object sender, EventArgs e)
		{
			Login login = new Login();
			login.Show();
			this.Hide();
		}
	}
}
