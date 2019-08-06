using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

/* Player
 *
 * Gregory Choice c9311718 & Christopher Booth c3229932
 * 
 * May 16th 2018
 * 
 * This class is a windows form for displaying and handling
 * game events for a player in the game of Lurgit
 * 
 */

namespace DiceOfOrigin
{
    public partial class Player : Form
    {
        #region Private Attributes

        private String sPlayerName;
        private Session sesPlayerSession;
        private static int _iNumPlayers;
        private static int _iGameCounter;
        private Round rouRound;
        private DiceWindow dwDice;
        private Game gGame;
        private bool bLurgit;
        private bool bSequence;
        #endregion
        
        #region Public Properties

        // This property method sets and returns the player colour
        public Color cPlayerColour { get; private set; }

        // This property method sets and returns the players current roll
        public int iRollCounter { get; private set; }

        // This property method sets and returns the player number
        public int iPlayerNumber { get; }

        // This property method sets and returns the players current round
        public int iRoundCounter { get; private set; }

        #endregion

        #region Constructor

        // Constructor creates a new Player receiving a name from ibxInputBox, access to the dice window
        // through dwDiceWin and a number of players as parameters
        public Player(InputBox ibxInputBox, DiceWindow dwDiceWin, int iPlayers = 1)
        {
            InitializeComponent();

            bLurgit = false;

            // Hides "Games Won" label because it makes no sense in this case
            if (iPlayers == 1)
            {
                lblSession.Visible = false;
            }

            // Instantiate a new game session
            sesPlayerSession = new Session();

            // Initialise counters
            _iNumPlayers++;
            iPlayerNumber = _iNumPlayers;
            iRollCounter = 0;
            iRoundCounter = 1;
            _iGameCounter = 1;

            // Initialise dice window
            dwDice = dwDiceWin;

            // Instantiate the first game
            gGame = new Game();

            // Instantiate first round
            rouRound = new Round(1);

            // Dice have no reason to be user lockable at this point
            dwDice.disableAllDice();

            // Set the properties of the player windows
            Top = dwDiceWin.Top;
            if (_iNumPlayers == 1)
            {
                cPlayerColour = Color.LightBlue;
                Left = dwDiceWin.Left - 50 - Width;
            }
            else
            {
                cPlayerColour = Color.LightPink;
                Left = dwDiceWin.Right + 50;
                Enabled = false;
            }
            BackColor = cPlayerColour;

            // Set the title of the player windows
            if (ibxInputBox.sName == null)
            {
                sPlayerName = "Computer";
                btnRoll.Visible = false;
            }
            else
            {
                sPlayerName = ibxInputBox.sName;
            }
            Text = sPlayerName;
        }

        #endregion
              
        #region AI Methods

        // This method controls dice rolling for the computer controlled player
        private void aiPlayer()
        {
            MessageBox.Show("Computer's turn!", "Turn Over", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);

            // Pause then Roll once
            Application.DoEvents();
            Thread.Sleep(1000);
            btnRoll_Click(this, EventArgs.Empty);

            // If no Lurgit occurred pause and roll a second time
            if (!bLurgit)
            {
                Application.DoEvents();
                Thread.Sleep(1000);
                btnRoll_Click(this, EventArgs.Empty);
            }

            // If no Lurgit occurred pause and roll a third time
            if (!bLurgit)
            {
                Application.DoEvents();
                Thread.Sleep(1000);
                btnRoll_Click(this, EventArgs.Empty);
            }
        }

        // This helper method decides which dice the computer controlled player chooses to keep
        private void chooseDice()
        {
            switch (iRoundCounter)
            {
                case 1:
                    if (!ruleTwo())
                        ruleOne();
                    break;
                case 2:
                    if (!ruleTwo())
                        ruleOne();
                    break;
                case 3:
                    if (!ruleTwo())
                        ruleOne();
                    break;
                case 4:
                    if (!ruleThree())
                        ruleOne();
                    break;
                case 5:
                    if (!ruleOne())
                        ruleThree();
                    break;
                case 6:
                    if (!ruleOne())
                        ruleThree();
                    break;
            }
        }

        // This method simply chooses the dice that match the round number
        private bool ruleOne()
        {
            bool bChanged = false;

            // Die 1
            if (dwDice.dieDice[0].iFace == iRoundCounter && !dwDice.dieDice[0].bLocked)
            {
                if(dwDice.dieDice[1].iFace != iRoundCounter && dwDice.dieDice[1].bLocked)
                    dwDice.changeLock(2);
                if (dwDice.dieDice[2].iFace != iRoundCounter && dwDice.dieDice[2].bLocked)
                    dwDice.changeLock(3);
                dwDice.changeLock(1);
                bChanged = true;
            }

            // Die 2
            if (dwDice.dieDice[1].iFace == iRoundCounter && !dwDice.dieDice[1].bLocked)
            {
                if (dwDice.dieDice[0].iFace != iRoundCounter && dwDice.dieDice[0].bLocked)
                    dwDice.changeLock(1);
                if (dwDice.dieDice[2].iFace != iRoundCounter && dwDice.dieDice[2].bLocked)
                    dwDice.changeLock(3);
                dwDice.changeLock(2);
                bChanged = true;
            }

            // Die 2
            if (dwDice.dieDice[2].iFace == iRoundCounter && !dwDice.dieDice[2].bLocked)
            {
                if (dwDice.dieDice[1].iFace != iRoundCounter && dwDice.dieDice[1].bLocked)
                    dwDice.changeLock(2);
                if (dwDice.dieDice[0].iFace != iRoundCounter && dwDice.dieDice[0].bLocked)
                    dwDice.changeLock(1);
                dwDice.changeLock(3);
                bChanged = true;
            }

            return bChanged;
        }

        // This method saves two dice for a possible sequence
        private bool ruleTwo()
        {
            if (!bSequence)
            {
                if (!dwDice.dieDice[0].bLocked && !dwDice.dieDice[1].bLocked && !dwDice.dieDice[2].bLocked)
                {
                    // Dice 1 and 2
                    if (Math.Abs(dwDice.dieDice[0].iFace - dwDice.dieDice[1].iFace) == 1)
                    {
                        dwDice.changeLock(1);
                        dwDice.changeLock(2);
                        return true;
                    }

                    // Dice 2 and 3
                    else if (Math.Abs(dwDice.dieDice[1].iFace - dwDice.dieDice[2].iFace) == 1)
                    {
                        dwDice.changeLock(2);
                        dwDice.changeLock(3);
                        return true;
                    }

                    // Dice 1 and 3
                    else if (Math.Abs(dwDice.dieDice[0].iFace - dwDice.dieDice[2].iFace) == 1)
                    {
                        dwDice.changeLock(1);
                        dwDice.changeLock(3);
                        return true;
                    }
                }
                // If one die is already selected
                else
                {
                    //Die 1
                    if (dwDice.dieDice[0].bLocked && !dwDice.dieDice[1].bLocked && !dwDice.dieDice[2].bLocked)
                    {
                        if (Math.Abs(dwDice.dieDice[0].iFace - dwDice.dieDice[1].iFace) == 1 || dwDice.dieDice[1].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(2);
                        }
                        else if (Math.Abs(dwDice.dieDice[0].iFace - dwDice.dieDice[2].iFace) == 1 || dwDice.dieDice[2].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(3);
                        }
                        return true;
                    }

                    // Die 2
                    if (dwDice.dieDice[1].bLocked && !dwDice.dieDice[0].bLocked && !dwDice.dieDice[2].bLocked)
                    {
                        if (Math.Abs(dwDice.dieDice[1].iFace - dwDice.dieDice[2].iFace) == 1 || dwDice.dieDice[2].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(3);
                        }
                        else if (Math.Abs(dwDice.dieDice[1].iFace - dwDice.dieDice[0].iFace) == 1 || dwDice.dieDice[0].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(1);
                        }
                        return true;
                    }

                    // Die 3
                    if (dwDice.dieDice[2].bLocked && !dwDice.dieDice[0].bLocked && !dwDice.dieDice[1].bLocked)
                    {
                        if (Math.Abs(dwDice.dieDice[2].iFace - dwDice.dieDice[1].iFace) == 1 || dwDice.dieDice[1].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(2);
                        }
                        else if (Math.Abs(dwDice.dieDice[2].iFace - dwDice.dieDice[0].iFace) == 1 || dwDice.dieDice[0].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(1);
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        // This method saves two dice for a possible sequence except for ones and sixes
        private bool ruleThree()
        {
            if (!bSequence && dwDice.dieDice[0].iFace != 6 && dwDice.dieDice[0].iFace != 1 
                && dwDice.dieDice[1].iFace != 6 && dwDice.dieDice[1].iFace != 1 
                && dwDice.dieDice[2].iFace != 6 && dwDice.dieDice[2].iFace != 1)
            {
                if (!dwDice.dieDice[0].bLocked && !dwDice.dieDice[1].bLocked && !dwDice.dieDice[2].bLocked)
                {
                    // Dice 1 and 2
                    if (Math.Abs(dwDice.dieDice[0].iFace - dwDice.dieDice[1].iFace) == 1
                        && dwDice.dieDice[2].iFace != iRoundCounter)
                    {
                        dwDice.changeLock(1);
                        dwDice.changeLock(2);
                        return true;
                    }

                    // Dice 2 and 3
                    if (Math.Abs(dwDice.dieDice[1].iFace - dwDice.dieDice[2].iFace) == 1
                        && dwDice.dieDice[0].iFace != iRoundCounter)
                    {
                        dwDice.changeLock(2);
                        dwDice.changeLock(3);
                        return true;
                    }

                    // Dice 1 and 3
                    if (Math.Abs(dwDice.dieDice[0].iFace - dwDice.dieDice[2].iFace) == 1
                        && dwDice.dieDice[1].iFace != iRoundCounter)
                    {
                        dwDice.changeLock(1);
                        dwDice.changeLock(3);
                        return true;
                    }
                }
                // If one die is already selected
                else
                {
                    // Die 1
                    if (dwDice.dieDice[0].bLocked && !dwDice.dieDice[1].bLocked && !dwDice.dieDice[2].bLocked)
                    {
                        if (Math.Abs(dwDice.dieDice[0].iFace - dwDice.dieDice[1].iFace) == 1 || dwDice.dieDice[1].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(2);
                        }
                        else if (Math.Abs(dwDice.dieDice[0].iFace - dwDice.dieDice[2].iFace) == 1 || dwDice.dieDice[2].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(3);
                        }
                        return true;
                    }

                    // Die 2
                    if (dwDice.dieDice[1].bLocked && !dwDice.dieDice[0].bLocked && !dwDice.dieDice[2].bLocked)
                    {
                        if (Math.Abs(dwDice.dieDice[1].iFace - dwDice.dieDice[2].iFace) == 1 || dwDice.dieDice[2].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(3);
                        }
                        else if (Math.Abs(dwDice.dieDice[1].iFace - dwDice.dieDice[0].iFace) == 1 || dwDice.dieDice[0].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(1);
                        }
                        return true;
                    }

                    // Die 3
                    if (dwDice.dieDice[2].bLocked && !dwDice.dieDice[0].bLocked && !dwDice.dieDice[1].bLocked)
                    {
                        if (Math.Abs(dwDice.dieDice[2].iFace - dwDice.dieDice[1].iFace) == 1 || dwDice.dieDice[1].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(2);
                        }
                        else if (Math.Abs(dwDice.dieDice[2].iFace - dwDice.dieDice[0].iFace) == 1 || dwDice.dieDice[0].iFace == iRoundCounter)
                        {
                            dwDice.changeLock(1);
                        }
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion

        #region Private Methods

        // This helper method prevents the player from keeping an entire sequence
        private void sequenceLock(Roll rRoll, bool bSeq)
        {
            if (bSeq)
            {
                MessageBox.Show(sPlayerName + " got a Sequence!", "Sequence", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                
                if (rRoll.iDie1 != iRoundCounter)
                    dwDice.disableDieOne();
                if (rRoll.iDie2 != iRoundCounter)
                    dwDice.disableDieTwo();
                if (rRoll.iDie3 != iRoundCounter)
                    dwDice.disableDieThree();
            }
        }

        // This helper method decides which player is the winner
        private String selectWinner()
        {
            Game.iP2Score = gGame.iGameScore;

            if (Game.iP2Score > Game.iP1Score)
            {
                sesPlayerSession.iGamesWon++;
                lblSession.Text = "Games Won: " + sesPlayerSession.iGamesWon;
                return "Player 2 wins!\r\n\r\n";
            }
            if (Game.iP1Score > Game.iP2Score)
            {
                return "Player 1 wins!\r\n\r\n";
            }

            return "Game is a tie!\r\n\r\n";
        }

        // This helper method clears all game and round data from the player window
        private void resetPlayerWindow()
        {
            iRoundCounter = 0;
            iRollCounter = 0;
            dwDice.resetRound();
            gGame = new Game();
            rouRound = new Round(1);
        }

        #endregion

        #region Button Click Event Handlers

        // This event handler method occurs when the Roll button is clicked
        private void btnRoll_Click(object sender, EventArgs e)
        {
            // Clear the player window for a new game
            if (iRoundCounter == 0)
            {
                lbxGame.Items.Clear();
                lbxRound.Items.Clear();
                lblTotal.Text = "Game Total: 0";
                iRoundCounter = 1;
            }

            // Increment counters
            if (iRollCounter < 3)
            {
                iRollCounter++;
            }
            else
            {
                iRollCounter = 1;
                iRoundCounter++;
                rouRound = new Round(iRoundCounter);
                lbxRound.Items.Clear();
            }

            // Instantiate a new dice roll
            Roll rDiceRoll = new Roll(iRoundCounter);
            rDiceRoll.iRollNumber = iRollCounter;

            // Roll the dice
            btnRoll.Enabled = false;
            dwDice.roll(this);
            btnRoll.Enabled = true;

            // Enable the dice for user selection
            if (dwDice.dieDice[0].bInactive)
            {
                dwDice.enableDieOne();
            }
            if (dwDice.dieDice[1].bInactive)
            {
                dwDice.enableDieTwo();
            }
            if (dwDice.dieDice[2].bInactive)
            {
                dwDice.enableDieThree();
            }

            // Store the dice roll
            rDiceRoll.iDie1 = dwDice.dieDice[0].iFace;
            rDiceRoll.iDie2 = dwDice.dieDice[1].iFace;
            rDiceRoll.iDie3 = dwDice.dieDice[2].iFace;

            // Check for a Lurgit condition
            bLurgit = false;
            if (!dwDice.dieDice[0].bLocked && !dwDice.dieDice[1].bLocked && !dwDice.dieDice[2].bLocked)
            {
                bLurgit = rDiceRoll.checkLurgit();
                if (bLurgit)
                {
                    MessageBox.Show(sPlayerName + " got a Lurgit! Whoopdee Dooo!", "Lurgit", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                    iRollCounter = 3;
                }
            }

            // Check for a sequence condition
            bSequence = rDiceRoll.checkSequence();

            // Add the roll to the player's round and display in the roll list
            rouRound.setRoll(rDiceRoll, iRollCounter);
            lbxRound.Items.Add(rDiceRoll.ToString());

            // Prevent the player from keeping the sequence
            sequenceLock(rDiceRoll, bSequence);

            if (!bLurgit && sPlayerName == "Computer")
            {
                chooseDice();
            }

            // End the round
            if (iRollCounter >= 3)
            {
                dwDice.disableAllDice();

                // Add round to the round list and game scores
                lbxGame.Items.Add(rouRound.ToString());
                gGame.setRound(iRoundCounter, rouRound);

                // Display running points total
                lblTotal.Text = "Game Total: " + gGame.iGameScore;

                // Switch player windows for two player
                if (_iNumPlayers > 1)
                {
                    if (iRoundCounter < 6)
                    {
                        if (sPlayerName == "Computer")
                            MessageBox.Show("Player's turn!", "Turn Over");
                        else
                            MessageBox.Show("Player's turn finished!", "Turn Over");
                    }

                    // Disable this window
                    Enabled = false;

                    List<Form> lstPlayers = new List<Form>();

                    foreach (Form frmForm in Application.OpenForms)
                    {
                        if (frmForm.Name == "Player")
                            lstPlayers.Add(frmForm);
                    }

                    // Cycle open forms to find the other player form
                    foreach (Form frmPlayer in lstPlayers)
                    {
                        if (frmPlayer != this)
                        {
                            frmPlayer.Enabled = true;
                        }
                    }
                }

                // Check for end of game
                if (iRoundCounter < 6)
                {
                    if (_iNumPlayers == 1)
                    {
                        MessageBox.Show("Player's turn finished!", "Turn Over");
                    }

                    // Player cannot choose dice
                    dwDice.disableAllDice();

                    // If a Lurgit occurred, move on to the next round
                    if (bLurgit)
                    {
                        iRollCounter = 0;
                        iRoundCounter++;
                        rouRound = new Round(iRoundCounter);
                        lbxRound.Items.Clear();
                    }
                }
                else
                {
                    // Set the game number and the high score
                    gGame.iGameNumber = _iGameCounter;
                    dwDice.iHighScore = gGame.iGameScore;

                    // After the last roll choose to play again or quit
                    if (_iNumPlayers == 1 || iPlayerNumber == 2)
                    {
                        // Add game data to the list of games in the session
                        sesPlayerSession.lstGameList.Add(gGame);

                        String sWinner = "";

                        // Determine which player was the winner
                        if (iPlayerNumber == 2)
                        {
                            sWinner = selectWinner();
                        }
                        _iGameCounter++;

                        // Show message box with options
                        DialogResult drResult = MessageBox.Show(sWinner + "Another game?", "Play Again", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);

                        // Act on user selection
                        if (drResult == DialogResult.Yes)
                        {
                            // Reset player two window
                            resetPlayerWindow();

                            if (_iNumPlayers == 2)
                            {
                                // Disable this window
                                Enabled = false;

                                // Return to player one window
                                foreach (Form frmForm in Application.OpenForms)
                                {
                                    if (frmForm.Name.Equals("Player") && frmForm != this)
                                    {
                                        frmForm.Enabled = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            dwDice.Close();
                        }
                    }
                    else
                    {
                        //Game.iP1Score = gGame.iGameScore;
                        if (Game.iP1Score > Game.iP2Score)
                        {
                            sesPlayerSession.iGamesWon++;
                            lblSession.Text = "Games Won: " + sesPlayerSession.iGamesWon;
                        }
                        //sesPlayerSession.lstGameList.Add(gGame);

                        dwDice.disableAllDice();

                        resetPlayerWindow();
                    }
                }
            }
        }

        #endregion

        #region Form Event Handlers

        // This event handler method closes all game windows if this one is closed
        private void Player_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Reset the number of players in case another game is started
            _iNumPlayers = 0;
            
            // Return the menu window to the screen
            Application.OpenForms["Lurgit"].WindowState = FormWindowState.Normal;
        }

        private void Player_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled && sPlayerName == "Computer")
            {
                aiPlayer();

                // Disable this window
                Enabled = false;

                // Cycle open forms to find the other player form
                foreach (Form frmForm in Application.OpenForms)
                {
                    if (frmForm.Name.Equals("Player") && frmForm != this)
                    {
                        frmForm.Enabled = true;                        
                    }
                }
            }
            else if (!Enabled && iPlayerNumber == 1 && iRoundCounter == 6)
            {
                Game.iP1Score = gGame.iGameScore;
                sesPlayerSession.lstGameList.Add(gGame);
            }
        }

        #endregion
    }
}
