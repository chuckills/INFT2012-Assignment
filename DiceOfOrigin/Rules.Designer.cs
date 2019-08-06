namespace DiceOfOrigin
{
	partial class Rules
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rules));
			this.tbxRules = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbxRules
			// 
			this.tbxRules.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tbxRules.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbxRules.Location = new System.Drawing.Point(13, 12);
			this.tbxRules.Multiline = true;
			this.tbxRules.Name = "tbxRules";
			this.tbxRules.ReadOnly = true;
			this.tbxRules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbxRules.Size = new System.Drawing.Size(565, 286);
			this.tbxRules.TabIndex = 0;
			this.tbxRules.TabStop = false;
			this.tbxRules.Text = resources.GetString("tbxRules.Text");
			// 
			// Rules
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(590, 310);
			this.Controls.Add(this.tbxRules);
			this.Name = "Rules";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Rules";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Rules_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbxRules;
	}
}