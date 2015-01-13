using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace PegPuzzle
{
	public partial class SolveDialog : Form
	{
		public List<IPuzzleAction> Solution { get; private set; }

		public long Milliseconds { get; private set; }

		public Puzzle Puzzle { get; set; }

		public SolveDialog()
		{
			InitializeComponent();
		}

		private void solveLastButton_Click(object sender, EventArgs e)
		{
			EnterSolving();

			solverThread = new Thread(() =>
			{
				Stopwatch timer = new Stopwatch();

				timer.Start();

				var solver = new PuzzleSolver(Puzzle);
				Solution = solver.Solve((int)numericUpDown1.Value);

				timer.Stop();

				this.Milliseconds = timer.ElapsedMilliseconds;

				this.Invoke((MethodInvoker)(() => 
					{
						DialogResult = DialogResult.OK;
						Close();
					}));
			});

			solverThread.Start();
		}

		private void solveAnyButton_Click(object sender, EventArgs e)
		{
			EnterSolving();

			solverThread = new Thread(() =>
			{
				Stopwatch timer = new Stopwatch();

				timer.Start();

				var solver = new PuzzleSolver(Puzzle);
				Solution = solver.Solve();

				timer.Stop();

				this.Milliseconds = timer.ElapsedMilliseconds;

				this.Invoke((MethodInvoker)(() =>
					{
						this.DialogResult = DialogResult.OK;
						this.Close();
					}));
			});

			solverThread.Priority = ThreadPriority.Highest;

			solverThread.Start();
		}

		private void EnterSolving()
		{
			this.Cursor = Cursors.WaitCursor;

			foreach (Control control in Controls)
			{
				control.Enabled = false;
			}
		}

		private Thread solverThread;

		private void SolveDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (solverThread != null)
			{
				solverThread.Abort();
			}

			if (DialogResult != DialogResult.OK)
			{
				DialogResult = DialogResult.Abort;
			}
		}

		private void SolveDialog_Load(object sender, EventArgs e)
		{
			numericUpDown1.Maximum = Puzzle.Spots - 1;
		}
	}
}
