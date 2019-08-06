using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

/* DiceWindow
 *
 * Gregory Choice c9311718 & Christopher Booth c3229932
 * 
 * May 16th 2018
 * 
 * This class is a Windows form to display dice and dice actions
 *
 */

namespace DiceOfOrigin
{
    public partial class DiceWindow : Form
    {
        #region Private Attributes

        private Thread tRollDie1, tRollDie2, tRollDie3;
        private int iMyHighScore;

        #endregion

        #region Public Properties

        // This property method returns the Die array
        public Die[] dieDice { get; }

        // This property method sets and returns the high score
        public int iHighScore
        {
            get => iMyHighScore;
            set
            {
                if (value >= iMyHighScore)
                {
                    iMyHighScore = value;
                    lblHiScore.Text = "High Score: " + iMyHighScore;
                }
            }
        }

        #endregion

        #region Constructor

        public DiceWindow()
        {
            InitializeComponent();
            dieDice = new Die[3];
        }

        #endregion

        #region Public Methods

        // This method rolls three dice in a random manner
        public void roll(Player pPlayer)
        {
            // Change the cursor to indicate activity
            Cursor = Cursors.AppStarting;

            // Update the game counters on the window
            lblRoll.Text = "Dice Roll: " + pPlayer.iRollCounter;
            lblRound.Text = "Round: " + pPlayer.iRoundCounter;
            
            Random rndRandom = new Random();

            // If the die is not locked by the user a new Die is run in a new Thread
            #region Die Threads

            // Die1
            if (pbxBorder1.BackColor == Color.Transparent)
            {
                disableDieOne();
                dieDice[0] = new Die(pbxDie1, rndRandom, pPlayer.cPlayerColour);
                tRollDie1 = new Thread(dieDice[0].roll);
                tRollDie1.Start();
                enableDieOne();
            }

            // Die2
            if (pbxBorder2.BackColor == Color.Transparent)
            {
                disableDieTwo();
                dieDice[1] = new Die(pbxDie2, rndRandom, pPlayer.cPlayerColour);
                tRollDie2 = new Thread(dieDice[1].roll);
                tRollDie2.Start();
                enableDieTwo();
            }

            // Die3
            if (pbxBorder3.BackColor == Color.Transparent)
            {
                disableDieThree();
                dieDice[2] = new Die(pbxDie3, rndRandom, pPlayer.cPlayerColour);
                tRollDie3 = new Thread(dieDice[2].roll);
                tRollDie3.Start();
                enableDieThree();
            }

            // Threads are joined to wait for the longest thread to finish
            if (tRollDie1.IsAlive)
                tRollDie1.Join();

            if (tRollDie2.IsAlive)
                tRollDie2.Join();

            if (tRollDie3.IsAlive)
                tRollDie3.Join();

            #endregion

            // Captures mouse clicks while the button is disabled
            Application.DoEvents();

            Cursor = Cursors.Default;
        }

        // This method resets the round counter on the window
        public void resetRound()
        {
            lblRound.Text = "Round: 1";
            lblRoll.Text = "Dice Roll: 1";
        }              

        // The methods in this region disable user interaction with the dice
        #region Disable Dice

        // The dice can be disabled individually or altogether
        public void disableAllDice()
        {
            disableDieOne();
            disableDieTwo();
            disableDieThree();
        }

        public void disableDieOne()
        {
            pbxBorder1.BackColor = Color.Transparent;
            pbxDie1.MouseLeave -= pbxDie1_MouseLeave;
            pbxDie1.MouseEnter -= pbxDie1_MouseEnter;
            pbxDie1.Click -= pbxDie1_Click;
        }

        public void disableDieTwo()
        {
            pbxBorder2.BackColor = Color.Transparent;
            pbxDie2.MouseLeave -= pbxDie2_MouseLeave;
            pbxDie2.MouseEnter -= pbxDie2_MouseEnter;
            pbxDie2.Click -= pbxDie2_Click;
        }

        public void disableDieThree()
        {
            pbxBorder3.BackColor = Color.Transparent;
            pbxDie3.MouseLeave -= pbxDie3_MouseLeave;
            pbxDie3.MouseEnter -= pbxDie3_MouseEnter;
            pbxDie3.Click -= pbxDie3_Click;
        }

        #endregion

        // The methods in this region enable user interaction with the dice
        #region Enable Dice

        // The dice can be enabled individually or altogether
        public void enableAllDice()
        {
            enableDieOne();
            enableDieTwo();
            enableDieThree();
        }

        public void enableDieOne()
        {
            pbxDie1.MouseLeave += pbxDie1_MouseLeave;
            pbxDie1.MouseEnter += pbxDie1_MouseEnter;
            pbxDie1.Click += pbxDie1_Click;
        }

        public void enableDieTwo()
        {
            pbxDie2.MouseLeave += pbxDie2_MouseLeave;
            pbxDie2.MouseEnter += pbxDie2_MouseEnter;
            pbxDie2.Click += pbxDie2_Click;
        }

        public void enableDieThree()
        {
            pbxDie3.MouseLeave += pbxDie3_MouseLeave;
            pbxDie3.MouseEnter += pbxDie3_MouseEnter;
            pbxDie3.Click += pbxDie3_Click;
        }

        #endregion

        #endregion

        #region Mouse Event Handlers

        // When the mouse enters the die area its border is highlighted red and transparent on leaving 
        private void pbxDie1_MouseEnter(object sender, EventArgs e)
        {
            pbxBorder1.BackColor = Color.Red;
        }

        private void pbxDie2_MouseEnter(object sender, EventArgs e)
        {
            pbxBorder2.BackColor = Color.Red;
        }

        private void pbxDie3_MouseEnter(object sender, EventArgs e)
        {
            pbxBorder3.BackColor = Color.Red;
        }

        private void pbxDie1_MouseLeave(object sender, EventArgs e)
        {
            pbxBorder1.BackColor = Color.Transparent;
        }

        private void pbxDie2_MouseLeave(object sender, EventArgs e)
        {
            pbxBorder2.BackColor = Color.Transparent;
        }

        private void pbxDie3_MouseLeave(object sender, EventArgs e)
        {
            pbxBorder3.BackColor = Color.Transparent;
        }

        #endregion

        #region Click Event Handlers

        // When each die is clicked its border alternates between black(locked) and red(unlocked)
        private void pbxDie1_Click(object sender, EventArgs e)
        {
            if (!dieDice[0].bLocked)
            {
                pbxDie1.MouseLeave -= pbxDie1_MouseLeave;
                pbxDie1.MouseEnter -= pbxDie1_MouseEnter;
            }
            else
            {
                pbxDie1.MouseLeave += pbxDie1_MouseLeave;
                pbxDie1.MouseEnter += pbxDie1_MouseEnter;
            }
            changeLock(1);
        }

        private void pbxDie2_Click(object sender, EventArgs e)
        {
            if (!dieDice[1].bLocked)
            {
                pbxDie2.MouseLeave -= pbxDie2_MouseLeave;
                pbxDie2.MouseEnter -= pbxDie2_MouseEnter;
            }
            else
            {
                pbxDie2.MouseLeave += pbxDie2_MouseLeave;
                pbxDie2.MouseEnter += pbxDie2_MouseEnter;
            }
            changeLock(2);
        }

        private void pbxDie3_Click(object sender, EventArgs e)
        {
            if (!dieDice[2].bLocked)
            {
                pbxDie3.MouseLeave -= pbxDie3_MouseLeave;
                pbxDie3.MouseEnter -= pbxDie3_MouseEnter;
            }
            else
            {
                pbxDie3.MouseLeave += pbxDie3_MouseLeave;
                pbxDie3.MouseEnter += pbxDie3_MouseEnter;
            }
            changeLock(3);
        }

        public void changeLock(int iDieNum)
        {
            PictureBox pbxBorder = pbxBorder1;

            if (iDieNum == 2)
                pbxBorder = pbxBorder2;
            if (iDieNum == 3)
                pbxBorder = pbxBorder3;

            if (!dieDice[iDieNum-1].bLocked)
            {
                pbxBorder.BackColor = Color.Black;
                dieDice[iDieNum-1].bLocked = true;
                pbxBorder.Refresh();
            }
            else
            {
                pbxBorder.BackColor = Color.Transparent;
                dieDice[iDieNum-1].bLocked = false;
                pbxBorder.Refresh();
            }
        }

        #endregion

        #region Form Event Handlers

        // When the dice window is first show it is moved up so message boxes don't cover it
        private void DiceWindow_Shown(object sender, EventArgs e)
        {
            Top -= 150;
        }

        private void DiceWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                foreach (Form frmForm in Application.OpenForms)
                {
                    frmForm.WindowState = FormWindowState.Minimized;
                }
            }
        }

        // This event handler method closes all game windows if this one is closed
        private void DiceWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Set the output file for saving the high score
                FileStream fsOutputStream = new FileStream("./hiScore.dat", FileMode.Create);
                BinaryWriter bwOutputFile = new BinaryWriter(fsOutputStream);

                // Write the high score
                bwOutputFile.Write(iHighScore);

                // Close the file
                bwOutputFile.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            //==================================================================================
            // Reference: Externally Sourced Code
            // Purpose: Close all open forms (did not know about the Application.OpenForms property)
            // Date: 3 May 2018
            // Source: stackoverflow
            // "Author": Dmitry Bychenko (I used quotes because who knows if he really authored it?)
            // url: https://stackoverflow.com/questions/23054410/close-specific-form-by-its-name 
            // Adaptaion required: changed variable names and literals
            //==================================================================================

            // Instantiate a new list of Forms
            List<Form> lstPlayer = new List<Form>();

            // Add each open player form to the list
            foreach (Form frmForm in Application.OpenForms)
            {
                if (frmForm.Name == "Player")
                {
                    lstPlayer.Add(frmForm);
                }

                if (frmForm.Name == "Lurgit")
                {
                    frmForm.Enabled = true;
                    frmForm.BringToFront();
                }

            }

            // Close each form in the list
            foreach (Form frmForm in lstPlayer)
            {
                frmForm.Close();
            }
            //==================================================================================
            // End Reference
            //==================================================================================

            // Restore the game menu window
            Application.OpenForms["Lurgit"].WindowState = FormWindowState.Normal;
        }

        // This event handler method loads the high score from a binary file
        private void DiceWindow_Load(object sender, EventArgs e)
        {
            try
            {
                // Attempt to find an existing file
                FileStream fsInputStream = new FileStream("./hiScore.dat", FileMode.Open);
                BinaryReader brInputfile = new BinaryReader(fsInputStream);

                // Read the file
                iHighScore = brInputfile.ReadInt32();

                // Close the file
                brInputfile.Close();
            }
            catch (FileNotFoundException)
            {
                // If the file is not found, create a new file
                FileStream fsOutputStream = new FileStream("./hiScore.dat", FileMode.Create);
                BinaryWriter bwOutputFile = new BinaryWriter(fsOutputStream);

                // Write zero to the file
                bwOutputFile.Write(0);

                // Close the file
                bwOutputFile.Close();
            }
        }

        #endregion
    }
}
