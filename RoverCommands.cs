using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mars_Rover
{
    public class RoverCommands
    {
        /// <summary>
        /// initial x and y coordinates of rover, default 0,0
        /// initial direction of rover
        /// </summary>
        private int x = 0;
        private int y = 0;
        private string direction;

        /// <summary>
        /// strings that appear more than once in code
        /// </summary>
        private static string inputErr = "Input Error";
        private static string inputErrIgn = "Input Error in instruction, ignoring error.";
        private static string outOfBounds = "Rover out of bounds, check input";

        /// <summary>
        /// generic flag to check if rover position is in bounds. 
        /// </summary>
        private bool goodToGo = true;

        public string[] InputLines;

        /// <summary>
        /// deletes the bounds from the input in memory and starts the movement
        /// </summary>
        /// <param name="inputLines"></param>
        public RoverCommands(string[] inputLines)
        {
            //delete line containing bounds in memory
            InputLines = deleteFirstLine(inputLines);

            executeCommands(InputLines);
        }

        /// <summary>
        /// handles the movement of the rover for every set of instructions in input
        /// </summary>
        /// <param name="inputLines"></param>
        public void executeCommands(string[] inputLines)
        {
            while (inputLines.Length != 0)
            {
                //set initial coordinates of rover from input
                setInitialCoords(inputLines.First());
                //delete the first line of input in memory, which is rover position from user input
                inputLines = deleteFirstLine(inputLines);
                //check if rover is inside bounds
                goodToGo = Rover.checkRoverPosition(Rover.getmaxX(), Rover.getmaxY(), x, y);
                if (goodToGo)
                {
                    //move the rover
                    executeMove(inputLines.First());
                    //print result rover position and direction into outputTB
                    printResult();
                }
                //delete the line holding the rover rotation and movement from memory
                inputLines = deleteFirstLine(inputLines);
            }
        }

        /// <summary>
        /// prints final position and direction of rover into output textbox
        /// </summary>
        private void printResult()
        {
            string finalPos = getX().ToString() + " " + getY().ToString() + " " + getDirection();
            RichTextBox t = Application.OpenForms["Rover"].Controls["outputTB"] as RichTextBox;
            t.AppendText(finalPos + Environment.NewLine);
        }

        /// <summary>
        /// movement command parser for L R M to figure out which way to turn or move
        /// </summary>
        /// <param name="v">movement line from input</param>
        private void executeMove(string v)
        {
            string temp = v;
            //cycle through each char in the input string
            foreach(char command in temp)
            {
                switch (command)
                {
                    //rotate rover left
                    case 'L':
                        rotateLeft();
                        break;

                    //rotate rover right
                    case 'R':
                        rotateRight();
                        break;

                    //move rover forward 1 unit
                    case 'M':
                        moveForward();
                        break;

                    //any other input that may be here is ignored
                    default:
                        inputError(inputErrIgn);
                        break;
                }
            }
        }

        /// <summary>
        /// move rover forward 1 unit method
        /// </summary>
        private void moveForward()
        {
            string currentDirection = getDirection();
            //moves forward one unit based on current direction of rover
            //then checks to see if rover would be out of bounds
            switch (currentDirection)
            {
                case "N":
                    y += 1;
                    if (y > Rover.getmaxY())
                    {
                        inputError(outOfBounds);
                    }
                    break;

                case "E":
                    x += 1;
                    if (x > Rover.getmaxX())
                    {
                        inputError(outOfBounds);
                    }
                    break;

                case "S":
                    y -= 1;
                    if (y < 0)
                    {
                        inputError(outOfBounds);
                    }
                    break;

                case "W":
                    x -= 1;
                    if (x < 0)
                    {
                        inputError(outOfBounds);
                    }
                    break;
            }
        }

        /// <summary>
        /// rotate rover to the right 90 degrees to the next cardinal direction
        /// </summary>
        private void rotateRight()
        {
            string currentDirection = getDirection();
            switch (currentDirection)
            {
                case "N":
                    setDirection("E");
                    break;

                case "E":
                    setDirection("S");
                    break;

                case "S":
                    setDirection("W");
                    break;

                case "W":
                    setDirection("N");
                    break;
            }
        }

        /// <summary>
        /// rotate rover to the left 90 degrees to the next cardinal direction
        /// </summary>
        private void rotateLeft()
        {
            string currentDirection = getDirection();
            switch (currentDirection)
            {
                case "N":
                    setDirection("W");
                    break;
                case "E":
                    setDirection("N");
                    break;
                case "S":
                    setDirection("E");
                    break;
                case "W":
                    setDirection("S");
                    break;
            }
        }

        /// <summary>
        /// deletes the first line of input in memory
        /// </summary>
        /// <param name="inputLines">current set of user input in memory</param>
        /// <returns>set of user input without the first line</returns>
        public string[] deleteFirstLine(string[] inputLines)
        {
            List<string> temp = new List<string>(inputLines);
            temp.RemoveAt(0);
            inputLines = temp.ToArray();
            return inputLines;
        }

        /// <summary>
        /// set initial coordinates and position of the rover
        /// </summary>
        /// <param name="v">line from user input with initial coords and direction</param>
        private void setInitialCoords(string v)
        {
            string[] firstline = v.Split(' ');
            if (firstline.Length == 3)
            {
                setX(firstline[0]);
                setY(firstline[1]);
                setDirection(firstline[2]);
            }
            else
            {
                inputError(inputErr);
                return;
            }

        }

        /// <summary>
        /// message box error if something goes wrong
        /// </summary>
        /// <param name="x">message to show user where the input is incorrect</param>
        private void inputError(string x)
        {
            MessageBox.Show(x);
        }

        /// <summary>
        /// get x position of rover
        /// </summary>
        /// <returns>returns x position of rover</returns>
        public int getX()
        {
            return x;
        }

        /// <summary>
        /// get y position of rover
        /// </summary>
        /// <returns>returns y position of rover</returns>
        public int getY()
        {
            return y;
        }

        /// <summary>
        /// get direction of rover
        /// </summary>
        /// <returns>return direction of the rover</returns>
        public string getDirection()
        {
            return direction;
        }

        /// <summary>
        /// set x position of rover and convert from string to int
        /// </summary>
        /// <param name="intX">string with rover x position </param>
        public void setX(string intX)
        {
            x = Convert.ToInt32(intX);
        }

        /// <summary>
        /// set y position of rover and convert from string to int
        /// </summary>
        /// <param name="intY">string with rover y position</param>
        public void setY(string intY)
        {
            y = Convert.ToInt32(intY);
        }

        /// <summary>
        /// set direction the rover
        /// </summary>
        /// <param name="initdir">new direction of rover</param>
        public void setDirection(string initdir)
        {
            direction = initdir;
        }
    }
}
