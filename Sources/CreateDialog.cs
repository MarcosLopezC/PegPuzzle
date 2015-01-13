using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PegPuzzle
{
	public partial class CreateDialog : Form
	{
		public int Rows { get; private set; }
		public int Hole { get; private set; }

		public CreateDialog()
		{
			InitializeComponent();
		}

		private void createButton_Click(object sender, EventArgs e)
		{
			Rows = (int)rowsNumericUpDown.Value;
			Hole = (int)holeIndexNumericUpDown.Value;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void rowsNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			holeIndexNumericUpDown.Maximum = Puzzle.GetMaxSpotCount((int)rowsNumericUpDown.Value) - 1;
		}
	}
}
