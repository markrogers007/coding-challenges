using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public string compassPoint { get; private set; }


        public Robot(int x, int y, string compass)
        {
            this.X = x;
            this.Y = y;
            this.compassPoint = compass;
        }

        public void MoveRobot(string move)
        {
            if (move == "L")
            {
                RotateLeft();
            }
            else if (move == "R")
            {
                RotateRight();
            }
            else
            {
                ChangeGridPosition();
            }
        }

        private void ChangeGridPosition()
        {
            switch (compassPoint)
            {
                case "N":
                    Y++;
                    break;
                case "S":
                    Y--;
                    break;
                case "W":
                    X--;
                    break;
                default:
                    X++;
                    break;
            }
        }

        private void RotateRight()
        {
            switch (compassPoint)
            {
                case "N":
                    compassPoint = "E";
                    break;
                case "W":
                    compassPoint = "N";
                    break;
                case "S":
                    compassPoint = "W";
                    break;
                default:
                    compassPoint = "S";
                    break;
            }
        }

        private void RotateLeft()
        {
            switch (compassPoint)
            {
                case "N":
                    compassPoint = "W";
                    break;
                case "W":
                    compassPoint = "S";
                    break;
                case "S":
                    compassPoint = "E";
                    break;
                default:
                    compassPoint = "N";
                    break;
            }
        }

        public string GetPosition()
        {
            return $"{X} {Y} {compassPoint}";
        }
    }
}
