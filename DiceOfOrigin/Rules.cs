using System.Windows.Forms;

/* Rules
 *
 * Gregory Choice c9311718 & Christopher Booth c3229932
 * 
 * May 16th 2018
 * 
 * The Rules class is simply a windows form that displays the rules of the game
 * 
 */

namespace DiceOfOrigin
{
    public partial class Rules : Form
    {
        #region Private Attributes

        private Lurgit lLurgitMenu;

        #endregion

        #region Constructor

        public Rules(Lurgit lMenu)
        {
            InitializeComponent();

            lLurgitMenu = lMenu;
        }

        #endregion

        #region Form Event Handlers

        private void Rules_FormClosed(object sender, FormClosedEventArgs e)
        {
            lLurgitMenu.WindowState = FormWindowState.Normal;
        }

        #endregion
    }
}
