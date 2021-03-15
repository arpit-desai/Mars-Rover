using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Mars_Rover
{
    public partial class Rover : Form
    {
        /// <summary>
        /// generic flag used in input formatting
        /// </summary>
        private bool charFlag = true;

        /// <summary>
        /// maxX - max X axis bound
        /// maxY - max Y axis bound
        /// lineNum - line number from input box
        /// roverX - rover current x position
        /// roverY - rover current y position
        /// </summary>
        private static int maxX, maxY;

        /// <summary>
        /// strings that appear more than once
        /// </summary>
        private static string inputErr = "Please fix input error";
        private static string boundErr = "Incorrect bounds, please fix bounds";
        private static string missingLines = "missing lines in input, please fix input";

        /// <summary>
        /// generic flag for rover position in bounds
        /// </summary>
        private bool initialstart = true;

        /// <summary>
        /// direction - rover is facing which direction
        /// </summary>
        public string direction;

        public Rover()
        {
            InitializeComponent();
        }

        /// <summary>
        /// if the bool flag is set to false, allows the inputted character to be put into text box
        /// Anything else is not allowed. Also, autocapitalizes the letters. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Auto capitalize letter
            e.KeyChar = Char.ToUpper(e.KeyChar);

            //checks flag from keydown event
            if (charFlag == false)
            {
                //stops the character from being inputted
                e.Handled = true;
            }
        }

        /// <summary>
        /// Active event on input text, to limit which characters can be typed into the input box. 
        /// Only digits 0-9 and letters L R M N E W S are allowed in the text box.
        /// and the space ' ' from spacebar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputTB_KeyDown(object sender, KeyEventArgs e)
        {
            charFlag = true;

            // Check if the event occurs from top of keyboard numbers
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Check if NumPad is used
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Only these letters allowed L R M N E W S
                    if (!(e.KeyCode == Keys.L || e.KeyCode == Keys.R || e.KeyCode == Keys.M
                        || e.KeyCode == Keys.N || e.KeyCode == Keys.E || e.KeyCode == Keys.W
                        || e.KeyCode == Keys.S || e.KeyCode == Keys.Space))
                    {
                        // Backspace
                        if (e.KeyCode != Keys.Back)
                        {
                            charFlag = false;
                        }
                    }
                }
            }

            // if shift key is selected for ! @ # $ etc, then ignore keypress
            if (Control.ModifierKeys == Keys.Shift)
            {
                charFlag = false;
            }
        }

        /// <summary>
        /// stop the usage of control + V to paste into input box because wont be autoformated
        /// into proper allowable characters. Can change in the future if there is time left. 
        /// </summary>
        /// <param name="sender">default event parameter</param>
        /// <param name="e">default event parameter</param>
        private void inputTB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.V && Control.ModifierKeys == Keys.Control)
            {
                MessageBox.Show("CTRL + V is not allowed");
            }
        }

        /// <summary>
        /// start button to start rover movement
        /// </summary>
        /// <param name="sender">default event parameter</param>
        /// <param name="e">default event parameter</param>
        private void startButton_Click(object sender, EventArgs e)
        {
            //user cannot change input after start click
            inputTB.ReadOnly = true;
            //clear output text box
            outputTB.Clear();
            
            string[] inputLines = inputTB.Lines;
            
            //checks to make sure there are atleast 3 lines for input
            //and an odd number of lines for input
            if ((inputLines.Length < 3) || (inputLines.Length % 2 == 0))
            {
                MessageBox.Show(missingLines);
                initialstart = false;
            }

            //set bounds
            
            try
            {
                string firstLine = inputLines[0];
                int[] initialCoord = firstLine.Split(' ').Select(int.Parse).ToArray();
                //check bound coordinates for proper formatting
                if (initialCoord.Length == 2)
                {
                    setMaxX(initialCoord[0]);
                    setMaxY(initialCoord[1]);
                }
                if (initialCoord.Length != 2)
                {
                    MessageBox.Show(boundErr);
                    initialstart = false;
                }
            }                
            catch (FormatException)
            {
                MessageBox.Show(boundErr);
                initialstart = false;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show(missingLines);
                initialstart = false;
            }

            if (initialstart == true)
            {
                //check initial rover position for proper formatting
                string[] tempSecondLine = inputLines[1].Split(" ");
                if (tempSecondLine.Length != 3 || tempSecondLine[2] == "")
                {
                    MessageBox.Show("Incorrect initial coordinates");
                    initialstart = false;
                }

                //check if initial rover position is within bounds set
                initialstart = checkRoverPosition(maxX, maxY, Int32.Parse(tempSecondLine[0]), Int32.Parse(tempSecondLine[1]));
            }


            //execute the commands for the rover if no errors found in initial checks
            if (initialstart == true)
            {
                RoverCommands rover = new RoverCommands(inputLines);
            }
            else
            {
                MessageBox.Show(inputErr);
            }

            //turn input box on for new input
            inputTB.ReadOnly = false;

        }

        /// <summary>
        /// check if rover initial position is within bounds
        /// </summary>
        /// <param name="maxX">max X axis bound</param>
        /// <param name="maxY">max Y Axis bound</param>
        /// <param name="x">rover initial x position</param>
        /// <param name="y">rover initial y position</param>
        /// <returns>false if out of bounds, true otherwise</returns>
        public static bool checkRoverPosition(int maxX, int maxY, int x, int y)
        {
            if (x > maxX || y > maxY)
            {
                MessageBox.Show(inputErr);
                return false;
            }
            return true;
        }

        /// <summary>
        /// get max X Bound set by user
        /// </summary>
        /// <returns>max X Bound of grid</returns>
        public static int getmaxX()
        {
            return maxX;
        }

        /// <summary>
        /// get max Y Bound set by user
        /// </summary>
        /// <returns>max Y bound of grid</returns>
        public static int getmaxY()
        {
            return maxY;
        }

        /// <summary>
        /// set max X Bound
        /// </summary>
        /// <param name="x">user input x coordinate</param>
        public void setMaxX(int x)
        {
            maxX = x;
        }

        /// <summary>
        /// quit button to close the application
        /// </summary>
        /// <param name="sender">default event parameter</param>
        /// <param name="e">default event parameter</param>
        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// set max Y Bound
        /// </summary>
        /// <param name="y">user input y coordinate</param>
        public void setMaxY(int y)
        {
            maxY = y;
        }


    }
}
