namespace PegPuzzle
{
	partial class CreateDialog
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
			this.label2 = new System.Windows.Forms.Label();
			this.rowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.holeIndexNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.createButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.holeIndexNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Rows";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Hole";
			// 
			// rowsNumericUpDown
			// 
			this.rowsNumericUpDown.Location = new System.Drawing.Point(52, 12);
			this.rowsNumericUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.rowsNumericUpDown.Name = "rowsNumericUpDown";
			this.rowsNumericUpDown.Size = new System.Drawing.Size(120, 20);
			this.rowsNumericUpDown.TabIndex = 2;
			this.rowsNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.rowsNumericUpDown.ValueChanged += new System.EventHandler(this.rowsNumericUpDown_ValueChanged);
			// 
			// holeIndexNumericUpDown
			// 
			this.holeIndexNumericUpDown.Location = new System.Drawing.Point(52, 38);
			this.holeIndexNumericUpDown.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
			this.holeIndexNumericUpDown.Name = "holeIndexNumericUpDown";
			this.holeIndexNumericUpDown.Size = new System.Drawing.Size(120, 20);
			this.holeIndexNumericUpDown.TabIndex = 3;
			// 
			// createButton
			// 
			this.createButton.Location = new System.Drawing.Point(57, 73);
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(75, 23);
			this.createButton.TabIndex = 4;
			this.createButton.Text = "Create";
			this.createButton.UseVisualStyleBackColor = true;
			this.createButton.Click += new System.EventHandler(this.createButton_Click);
			// 
			// CreateDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(188, 111);
			this.Controls.Add(this.createButton);
			this.Controls.Add(this.holeIndexNumericUpDown);
			this.Controls.Add(this.rowsNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CreateDialog";
			this.Text = "Create Puzzle";
			((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.holeIndexNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown rowsNumericUpDown;
		private System.Windows.Forms.NumericUpDown holeIndexNumericUpDown;
		private System.Windows.Forms.Button createButton;
	}
}