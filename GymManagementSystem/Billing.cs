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
		public Billing()
		{
			InitializeComponent();
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
	}
}
