﻿using System;
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
		public Members()
		{
			InitializeComponent();
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
	}
}
