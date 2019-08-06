using System.Collections.Generic;

/* Session
 *
 * Gregory Choice c9311718 & Christopher Booth c3229932
 * 
 * May 16th 2018
 * 
 * This class is for keeping track of the games played in a session
 */

namespace DiceOfOrigin
{
    public class Session
    {
        #region Public Properties

        public List<Game> lstGameList { get; set; }

        public int iGamesWon { get; set; }

        #endregion

        #region Constructor

        public Session()
        {
            lstGameList = new List<Game>();
            iGamesWon = 0;
        }

        #endregion
    }
}
