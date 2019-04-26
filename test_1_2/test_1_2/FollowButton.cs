using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_1_2
{
    /// <summary>
    /// This class presents the window with the button, which runs away from mouse when in comes up.
    /// The window closes, when the button is clicked.
    /// </summary>
    public partial class FollowButton : Form
    {
        public FollowButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function makes application close when user clicks the button.
        /// </summary>
        private void buttonFollow_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// This function makes the button run away from the mouse when it comes up to the button.
        /// </summary>
        private void buttonFollow_MouseMove(object sender, MouseEventArgs e)
        {
            int change = 2;

            int boardLeftUpX = 12;
            int boardLeftUpY = 12;

            int boardRightDownX = 668;
            int boardRightDownY = 382;

            if (buttonFollow.Location.X == boardLeftUpX)
            {
                if (buttonFollow.Location.Y + change <= boardRightDownY)
                {
                    buttonFollow.Location = new Point(buttonFollow.Location.X, buttonFollow.Location.Y + change);
                }
                else
                {
                    buttonFollow.Location = new Point(boardLeftUpX, boardRightDownY);
                }
            }

            if (buttonFollow.Location.Y == boardRightDownY)
            {
                if (buttonFollow.Location.X + change <= boardRightDownX)
                {
                    buttonFollow.Location = new Point(buttonFollow.Location.X + change, buttonFollow.Location.Y);
                }
                else
                {
                    buttonFollow.Location = new Point(boardRightDownX, boardRightDownY);
                }
            }

            if (buttonFollow.Location.X == boardRightDownX)
            {
                if (buttonFollow.Location.Y - change >= boardLeftUpY)
                {
                    buttonFollow.Location = new Point(buttonFollow.Location.X, buttonFollow.Location.Y - change);
                }
                else
                {
                    buttonFollow.Location = new Point(boardRightDownX, boardLeftUpY);
                }
            }

            if (buttonFollow.Location.Y == boardLeftUpY)
            {
                if (buttonFollow.Location.X - change >= boardLeftUpX)
                {
                    buttonFollow.Location = new Point(buttonFollow.Location.X - change, buttonFollow.Location.Y);
                }
                else
                {
                    buttonFollow.Location = new Point(boardLeftUpX, boardLeftUpY);
                }
            }
        }

        
    }
}
