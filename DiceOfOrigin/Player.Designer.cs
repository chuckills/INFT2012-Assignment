/* Player
 *
 * This class is a windows form for displaying and handling
 * game events for a player in the game of Lurgit
 * 
 */

namespace DiceOfOrigin
{
    partial class Player
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
            this.btnRoll = new System.Windows.Forms.Button();
            this.lbxRound = new System.Windows.Forms.ListBox();
            this.lblRound = new System.Windows.Forms.Label();
            this.lblGame = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.lbxGame = new System.Windows.Forms.ListBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(100, 292);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(75, 23);
            this.btnRoll.TabIndex = 0;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // lbxRound
            // 
            this.lbxRound.BackColor = System.Drawing.SystemColors.Window;
            this.lbxRound.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxRound.FormattingEnabled = true;
            this.lbxRound.Location = new System.Drawing.Point(41, 36);
            this.lbxRound.Name = "lbxRound";
            this.lbxRound.Size = new System.Drawing.Size(192, 56);
            this.lbxRound.TabIndex = 5;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(41, 17);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(181, 13);
            this.lblRound.TabIndex = 6;
            this.lblRound.Text = "Roll Die: 1   2   3  Seq  Lur";
            // 
            // lblGame
            // 
            this.lblGame.AutoSize = true;
            this.lblGame.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGame.Location = new System.Drawing.Point(41, 116);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(175, 13);
            this.lblGame.TabIndex = 8;
            this.lblGame.Text = "Round  Dice  Seq  Lur  Total";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSession.Location = new System.Drawing.Point(154, 266);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(79, 13);
            this.lblSession.TabIndex = 9;
            this.lblSession.Text = "Games Won: 0";
            // 
            // lbxGame
            // 
            this.lbxGame.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxGame.FormattingEnabled = true;
            this.lbxGame.Location = new System.Drawing.Point(41, 132);
            this.lbxGame.Name = "lbxGame";
            this.lbxGame.Size = new System.Drawing.Size(192, 121);
            this.lbxGame.TabIndex = 10;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(41, 266);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(85, 13);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Game Total: 0";
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 329);
            this.ControlBox = false;
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lbxGame);
            this.Controls.Add(this.lblSession);
            this.Controls.Add(this.lblGame);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.lbxRound);
            this.Controls.Add(this.btnRoll);
            this.Name = "Player";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Player_FormClosed);
            this.EnabledChanged += new System.EventHandler(this.Player_EnabledChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Label lblRound;
        protected internal System.Windows.Forms.ListBox lbxRound;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.ListBox lbxGame;
        private System.Windows.Forms.Label lblTotal;
    }
}