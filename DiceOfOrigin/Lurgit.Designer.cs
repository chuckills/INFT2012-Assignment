/* Lurgit
 * 
 * The Lurgit class is a windows form which lauches the various
 * game modes of Lurgit
 * 
 */

namespace DiceOfOrigin
{
    partial class Lurgit
    {
        private System.ComponentModel.IContainer components = null;

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
            this.btnSolo = new System.Windows.Forms.Button();
            this.btnTwoP = new System.Windows.Forms.Button();
            this.btnComp = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSolo
            // 
            this.btnSolo.Location = new System.Drawing.Point(76, 40);
            this.btnSolo.Name = "btnSolo";
            this.btnSolo.Size = new System.Drawing.Size(75, 23);
            this.btnSolo.TabIndex = 0;
            this.btnSolo.Text = "Solo";
            this.btnSolo.UseVisualStyleBackColor = true;
            this.btnSolo.Click += new System.EventHandler(this.btnSolo_Click);
            // 
            // btnTwoP
            // 
            this.btnTwoP.Location = new System.Drawing.Point(76, 82);
            this.btnTwoP.Name = "btnTwoP";
            this.btnTwoP.Size = new System.Drawing.Size(75, 23);
            this.btnTwoP.TabIndex = 1;
            this.btnTwoP.Text = "2 Player";
            this.btnTwoP.UseVisualStyleBackColor = true;
            this.btnTwoP.Click += new System.EventHandler(this.btnTwoP_Click);
            // 
            // btnComp
            // 
            this.btnComp.Location = new System.Drawing.Point(76, 126);
            this.btnComp.Name = "btnComp";
            this.btnComp.Size = new System.Drawing.Size(75, 23);
            this.btnComp.TabIndex = 2;
            this.btnComp.Text = "vs Computer";
            this.btnComp.UseVisualStyleBackColor = true;
            this.btnComp.Click += new System.EventHandler(this.btnComp_Click);
            // 
            // btnRules
            // 
            this.btnRules.Location = new System.Drawing.Point(76, 194);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(75, 23);
            this.btnRules.TabIndex = 3;
            this.btnRules.Text = "Rules";
            this.btnRules.UseVisualStyleBackColor = true;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // Lurgit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 245);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.btnComp);
            this.Controls.Add(this.btnTwoP);
            this.Controls.Add(this.btnSolo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Lurgit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lurgit";
            this.Activated += new System.EventHandler(this.Lurgit_Activated);
            this.Deactivate += new System.EventHandler(this.Lurgit_Deactivate);
            this.Resize += new System.EventHandler(this.Lurgit_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSolo;
        private System.Windows.Forms.Button btnTwoP;
        private System.Windows.Forms.Button btnComp;
        private System.Windows.Forms.Button btnRules;
    }
}