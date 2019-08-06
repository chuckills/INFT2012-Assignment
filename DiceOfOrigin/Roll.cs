using System;

/* Roll
 *
 * Gregory Choice c9311718 & Christopher Booth c3229932
 * 
 * May 16th 2018
 * 
 * The roll class stores numerical data related to each dice roll
 * 
 */

namespace DiceOfOrigin
{
    public class Roll
    {
        #region Private Attributes

        private int iRoundNumber;

        #endregion

        #region Public Properties

        // This property method sets and returns the roll number from 1 to 3 inclusive
        public int iRollNumber { get; set; }

        // This property method sets and returns the face value of the first die
        public int iDie1 { get; set; }

        // This property method sets and returns the face value of the second die
        public int iDie2 { get; set; }

        // This property method sets and returns the face value of the third die
        public int iDie3 { get; set; }

        // This property method sets and returns the sequence bonus
        public int iSequenceBonus { get; private set; }

        // This property method sets and returns the lurgit bonus
        public int iLurgitBonus { get; private set; }

        #endregion
        
        #region Constructor

        public Roll(int iRound)
        {
            iRoundNumber = iRound;
        }

        #endregion

        #region Public Methods

        // This method checks for a sequence in the roll and updates increases the bonus
        public bool checkSequence()
        {
            bool bSequence = false;

            // Checks all possible dice combinations for a sequence
            if (Math.Abs(iDie1 - iDie2) == 1 && Math.Abs(iDie2 - iDie3) == 1 && Math.Abs(iDie1 - iDie3) == 2
                || Math.Abs(iDie1 - iDie3) == 1 && Math.Abs(iDie2 - iDie3) == 1 && Math.Abs(iDie1 - iDie2) == 2
                || Math.Abs(iDie1 - iDie2) == 1 && Math.Abs(iDie1 - iDie3) == 1 && Math.Abs(iDie2 - iDie3) == 2)
            {
                iSequenceBonus += 10;
                bSequence = true;
            }

            return bSequence;
        }

        // This method checks for a Lurgit in the roll and increases the bonus
        public bool checkLurgit()
        {
            bool bLurgit = false;

            // Checks if all the dice equal the round number
            if (iDie1 == iRoundNumber && iDie2 == iRoundNumber && iDie3 == iRoundNumber)
            {
                bLurgit = true;
                iLurgitBonus += 20;
            }

            return bLurgit;
        }

        // This method creates a string representation of the roll for display
        public override string ToString() => $"{iRollNumber,-5}{iDie1,6}{iDie2,4}{iDie3,4}{iSequenceBonus,5}{iLurgitBonus,5}";

        #endregion
    }
}
