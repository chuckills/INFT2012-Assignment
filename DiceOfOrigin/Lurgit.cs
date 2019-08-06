using System;
using System.Windows.Forms;

/* Lurgit
 *
 * Gregory Choice c9311718 & Christopher Booth c3229932
 * 
 * May 16th 2018
 * 
 * The Lurgit class is a windows form which lauches the various
 * game modes of Lurgit
 * 
 */
namespace DiceOfOrigin
{
    public partial class Lurgit : Form
    {
        #region Constructor

        public Lurgit()
        {
            InitializeComponent();
        }

        #endregion

        #region Button Click Event Handlers

        // This event handler method lauches a one player game when the button is clicked
        private void btnSolo_Click(object sender, EventArgs e)
        {
            // Instantiate and display a new DiceWindow
            DiceWindow dwSolo = new DiceWindow();
            dwSolo.Show();

            // Minimise the menu button window
            WindowState = FormWindowState.Minimized;

            // Instantiate and display a name entry InputBox dialog
            InputBox ibxName = new InputBox(1);
            ibxName.ShowDialog();

            // Instantiate and display the game window
            Player frmPlayer = new Player(ibxName, dwSolo);
            frmPlayer.Show();
        }

        // This event handler method lauches a two player game when the button is clicked
        private void btnTwoP_Click(object sender, EventArgs e)
        {
            // Instantiate and display a new DiceWindow
            DiceWindow dwTwoPlayer = new DiceWindow();
            dwTwoPlayer.Show();

            // Minimise the menu button window
            WindowState = FormWindowState.Minimized;

            // Instantiate and display a name entry InputBox dialog for player one
            InputBox ibxP1Name = new InputBox(1);
            ibxP1Name.ShowDialog();

            // Instantiate and display a name entry InputBox dialog for player two
            InputBox ibxP2Name = new InputBox(2);
            ibxP2Name.ShowDialog();

            // Instantiate and display the game windows
            Player frmPlayer1 = new Player(ibxP1Name, dwTwoPlayer, 2);
            Player frmPlayer2 = new Player(ibxP2Name, dwTwoPlayer, 2);
            frmPlayer1.Show();
            frmPlayer2.Show();
        }

        // This event handler method lauches a one player game against the computer when the button is clicked
        private void btnComp_Click(object sender, EventArgs e)
        {
            // Instantiate and display a new DiceWindow
            DiceWindow dwTwoPlayer = new DiceWindow();
            dwTwoPlayer.Show();

            // Minimise the menu button window
            WindowState = FormWindowState.Minimized;

            // Instantiate and display a name entry InputBox dialog
            InputBox ibxP1Name = new InputBox(1);
            ibxP1Name.ShowDialog();

            // Instantiate and display the game windows
            Player frmPlayer1 = new Player(ibxP1Name, dwTwoPlayer, 2);            
            Player frmComputer = new Player(new InputBox(0), dwTwoPlayer, 2);
            frmPlayer1.Show();
            frmComputer.Show();
        }
        
        // This event handler method simply shows a window containing the game rules
        private void btnRules_Click(object sender, EventArgs e)
        {
            Rules frmRules = new Rules(this);
            frmRules.Show();
        }

        #endregion

        #region Form Event Handlers

        // This event handler method makes sure the menu window cannot be accessed while the game windows are open
        private void Lurgit_Activated(object sender, EventArgs e)
        {
            BringToFront();
            foreach (Form frmForm in Application.OpenForms)
            {
                if (frmForm.Name == "Lurgit")
                    continue;
                if (frmForm.WindowState == FormWindowState.Normal)
                    frmForm.BringToFront();

            }
        }

        private void Lurgit_Deactivate(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Lurgit_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                foreach (Form frmForm in Application.OpenForms)
                {
                    if (frmForm.Name == "Lurgit")
                        continue;
                    if (frmForm.WindowState == FormWindowState.Minimized)
                        frmForm.WindowState = FormWindowState.Normal;

                }
            }
        }

        #endregion
    }
}
