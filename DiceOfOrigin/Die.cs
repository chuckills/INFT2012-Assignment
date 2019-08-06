using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

/* Die
 *
 * Gregory Choice c9311718 & Christopher Booth c3229932
 * 
 * May 16th 2018
 * 
 * This class is for anything related to a single die
 */

namespace DiceOfOrigin
{
    public class Die
    {
        #region Private Attributes

        private Graphics graPaper;
        private PictureBox pbxPictureBox;
        private Color cDieColour;
        private Random rndRand;

        #endregion

        #region Public Properties

        // This property method sets and returns the die face value
        public int iFace { get; private set; }

        // This property method sets and returns if the user has locked the die
        public bool bLocked { get; set; }

        // This property method sets and returns if the game has disabled user interaction with the die
        public bool bInactive { get; set; }

        #endregion

        #region Constructor

        public Die(PictureBox pbxBox, Random rndRandom, Color cColour)
        {
            pbxPictureBox = pbxBox;
            graPaper = pbxPictureBox.CreateGraphics();
            cDieColour = cColour;
            rndRand = rndRandom;
            bLocked = false;
            bInactive = false;
        }

        #endregion

        #region Public Methods

        // This method controls the roll action of the die
        public void roll()
        {
            // Clear the previous die face
            graPaper.Clear(cDieColour);

            // Generate a new face value
            iFace = rndRand.Next(1, 7);

            // Generate a random roll time
            int iRoll = rndRand.Next(10, 20);

            // Roll the die
            for (int i = 0; i < iRoll; i++)
            {
                Thread.Sleep(20);
                displayFace(rndRand.Next(1, 7));
                Thread.Sleep(20);
                graPaper.Clear(cDieColour);
            }

            // Display the face value
            displayFace(iFace);
        }

        #endregion

        #region Private Methods

        // This method chooses which die face to draw
        private void displayFace(int iFace)
        {
            switch (iFace)
            {
                case 1:
                    one();
                    break;
                case 2:
                    two();
                    break;
                case 3:
                    three();
                    break;
                case 4:
                    four();
                    break;
                case 5:
                    five();
                    break;
                case 6:
                    six();
                    break;
            }
        }             

        // The methods in this region draw individual die faces
        #region Draw Die Faces
        private void one()
        {
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.45), Convert.ToInt32(pbxPictureBox.Width * 0.45), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
        }

        private void two()
        {
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
        }

        private void three()
        {
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.45), Convert.ToInt32(pbxPictureBox.Width * 0.45), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
        }

        private void four()
        {
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
        }

        private void five()
        {
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.45), Convert.ToInt32(pbxPictureBox.Width * 0.45), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
        }

        private void six()
        {
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.45), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.2), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.45), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
            graPaper.FillEllipse(Brushes.Black, Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.7), Convert.ToInt32(pbxPictureBox.Width * 0.1), Convert.ToInt32(pbxPictureBox.Width * 0.1));
        }
        #endregion

        #endregion
    }
}
