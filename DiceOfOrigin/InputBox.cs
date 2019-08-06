using System;
using System.Windows.Forms;

/* InputBox
 *
 * Gregory Choice c9311718 & Christopher Booth c3229932
 * 
 * May 16th 2018
 * 
 * The InputBox class simply collects a player name for the game window
 * 
 */

namespace DiceOfOrigin
{
    public partial class InputBox : Form
    {
        #region Private Attributes

        private String sMyName;

        #endregion

        #region Public Properties

        // This property method sets and returns the player name
        public String sName
        {
            get => sMyName;
            set => sMyName = tbxName.Text;
        }

        #endregion
        
        #region Constructor

        public InputBox(int iPlayerNum)
        {
            InitializeComponent();
            
            Text = "Player " + iPlayerNum + " name";
        }

        #endregion

        #region Button Click Event Handlers

        // This event handler method submits the player name to the game window when the button is clicked
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbxName.Text == "")
            {
                MessageBox.Show("Human players must have a name!", "Enter a name");
                tbxName.Focus();
            }
            else if (tbxName.Text == "Computer")
            {
                MessageBox.Show("Computers can't type! Enter a human name.", "Enter a name");
                tbxName.Clear();
                tbxName.Focus();
            }
            else
            {
                sName = tbxName.Text;
                Close();
            }
        }

        #endregion
    }
}
