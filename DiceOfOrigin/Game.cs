/* Game
 *
 * Gregory Choice c9311718 & Christopher Booth c3229932
 * 
 * May 16th 2018
 * 
  * This class is for keeping track of round scores throughout a game
  *
  */

namespace DiceOfOrigin
{
    public class Game
    {
        #region Private Attributes

        private Round[] rRoundScores;

        #endregion

        #region Public Properties

        public int iGameNumber { get; set; }

        public int iGameScore { get; private set; }

        public static int iP1Score { get; set; }

        public static int iP2Score { get; set; }

        #endregion

        #region Constructor

        public Game()
        {
            iGameNumber = 1;
            rRoundScores = new Round[6];
            iGameScore = 0;
        }

        #endregion
        
        #region Public Methods

        public void setRound(int iRnd, Round rRound)
        {
            rRoundScores[iRnd-1] = rRound;
            iGameScore += rRound.iRoundTotal;
        }

        #endregion
    }
}
