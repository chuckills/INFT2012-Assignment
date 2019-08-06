/* Round
 *
 * Gregory Choice c9311718 & Christopher Booth c3229932
 * 
 * May 16th 2018
 * 
 * The Round class is for anything to do with the round score
 * 
 */

namespace DiceOfOrigin
{
    public class Round
    {
        #region Private Attributes

        private Roll[] iRoll;
        private int iDiceScore;
        private int iSequenceBonus;
        private int iLurgitBonus;

        #endregion

        #region Public Properties

        // This property method sets and returns the round number
        public int iRoundNumber { get; set; }

        // This property method gets the round total
        public int iRoundTotal => (iDiceScore + iSequenceBonus + iLurgitBonus);

        #endregion

        #region Constructor

        public Round(int iRoundNum)
        {
            iRoundNumber = iRoundNum;
            iRoll = new Roll[3];
        }

        #endregion

        #region Public Methods

        // This method sets the round scores
        public void setRoll(Roll rllDiceRoll, int iRollNum)
        {
            // Store the dice roll
            iRoll[iRollNum-1] = rllDiceRoll;

            // Calculate the score of the dice roll
            iDiceScore = 0;
            if (rllDiceRoll.iDie1 == iRoundNumber)
                iDiceScore += rllDiceRoll.iDie1;
            if (rllDiceRoll.iDie2 == iRoundNumber)
                iDiceScore += rllDiceRoll.iDie2;
            if (rllDiceRoll.iDie3 == iRoundNumber)
                iDiceScore += rllDiceRoll.iDie3;

            // Set any sequence and Lurgit bonus
            iSequenceBonus += rllDiceRoll.iSequenceBonus;
            iLurgitBonus += rllDiceRoll.iLurgitBonus;
        }

        // This method creates a string representation of the round for display
        public override string ToString() => $"{iRoundNumber,-5}{iDiceScore,6}{iSequenceBonus,5}{iLurgitBonus,5}{iRoundTotal,7}";

        #endregion
    }
}
