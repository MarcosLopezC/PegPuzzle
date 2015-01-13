namespace PegPuzzle
{
	partial class SolveDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.solveLastButton = new System.Windows.Forms.Button();
			this.solveAnyButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Last Peg";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(67, 12);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(125, 20);
			this.numericUpDown1.TabIndex = 1;
			// 
			// solveLastButton
			// 
			this.solveLastButton.Location = new System.Drawing.Point(33, 38);
			this.solveLastButton.Name = "solveLastButton";
			this.solveLastButton.Size = new System.Drawing.Size(138, 23);
			this.solveLastButton.TabIndex = 2;
			this.solveLastButton.Text = "Solve for Last";
			this.solveLastButton.UseVisualStyleBackColor = true;
			this.solveLastButton.Click += new System.EventHandler(this.solveLastButton_Click);
			// 
			// solveAnyButton
			// 
			this.solveAnyButton.Location = new System.Drawing.Point(33, 67);
			this.solveAnyButton.Name = "solveAnyButton";
			this.solveAnyButton.Size = new System.Drawing.Size(138, 23);
			this.solveAnyButton.TabIndex = 2;
			this.solveAnyButton.Text = "Solve for Any";
			this.solveAnyButton.UseVisualStyleBackColor = true;
			this.solveAnyButton.Click += new System.EventHandler(this.solveAnyButton_Click);
			// 
			// SolveDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(204, 100);
			this.Controls.Add(this.solveAnyButton);
			this.Controls.Add(this.solveLastButton);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SolveDialog";
			this.Text = "Solve Puzzle";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SolveDialog_FormClosing);
			this.Load += new System.EventHandler(this.SolveDialog_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Button solveLastButton;
		private System.Windows.Forms.Button solveAnyButton;
	}
}