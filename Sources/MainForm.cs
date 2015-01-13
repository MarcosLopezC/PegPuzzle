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
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Made by Marcos López C.");
		}

		private void createToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreateDialog dialog = new CreateDialog();

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				listBox1.Items.Clear();
				solution = null;
				puzzleViewer1.Puzzle = new Puzzle(dialog.Rows, dialog.Hole);
				puzzleViewer1.UpdatePuzzleView();
				solveToolStripMenuItem.Enabled = true;
			}
		}

		private void solveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SolveDialog dialog = new SolveDialog();

			dialog.Puzzle = puzzleViewer1.Puzzle;

			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				listBox1.Items.Clear();

				if (dialog.Solution != null)
				{
					this.solution = dialog.Solution;

					foreach (var item in solution)
					{
						listBox1.Items.Add(item.ToString());
					}
				}
				else
				{
					listBox1.Items.Add("This context does not have a solution.");
				}

				MessageBox.Show(string.Format("Finished in {0:n0} milliseconds.", dialog.Milliseconds), "Finshed",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private List<IPuzzleAction> solution;

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (solution != null)
			{
				puzzleViewer1.Puzzle.SetContext(solution[listBox1.SelectedIndex].Execute());
				puzzleViewer1.UpdatePuzzleView();
			}
		}
	}
}
