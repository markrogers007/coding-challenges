using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class RobotWars
    {
        private Arena arena;
        private int maxMoves = 0;
        private List<string> moves;
        private List<string> lines;
        private List<Robot> robots;

        public RobotWars()
        {
            moves = new List<string>();
            lines = new List<string>();
            robots = new List<Robot>();
        }

        public void StartWar()
        {
            lines = ReadWarFile.ReadFromFile("../../Wars.txt");
            //lines = ReadWarFile.ReadFromFile("../../WarsInvalidArguments.txt");
            //lines = ReadWarFile.ReadFromFile("../../WarsInvalidGrid.txt");

            // Validate the Arena coordinates

            try
            {
                ValidateArenaCoordinates(lines);
                ValidateRobotAndMoves(lines, moves, out maxMoves,robots);
                int moveCount = 0;
                while (moveCount < maxMoves)
                {
                    for (int i = 0; i < robots.Count; i++)
                    {
                        if (moveCount < moves[i].Length)
                        {
                            robots[i].MoveRobot(moves[i].Substring(moveCount, 1));
                        }
                    }
                    moveCount++;
                }

                foreach (var robot in robots)
                {
                    Console.WriteLine(robot.GetPosition());
                }

            }
            catch (Exception ex )
            {
                throw ex;
            }

        }

        private void ValidateRobotAndMoves(List<string> lines, List<string> moves, out int maxMoves,List<Robot> robots)
        {
            for (int i = 1; i < lines.Count; i = i+2)
            {
                string[] robotDetails = lines[i].Trim().Split(' ');
                moves.Add(lines[i + 1]);
                int x = 0;
                int.TryParse(robotDetails[0], out x); 
                int y = 0;
                int.TryParse(robotDetails[1], out y);
                string compass = robotDetails[2];

                Robot robot = new Robot(x, y, compass);

                robots.Add(robot);
            }
            maxMoves = 0;
            foreach (var item in moves)
            {
                if (maxMoves < item.Length)
                {
                    maxMoves = item.Length;
                }
            }

        } // End of ValidateRobotAndMoves

        private void ValidateArenaCoordinates(List<string> lines)
        {
            string[] arenaCoordinates = lines[0].Trim().Split(' ');

            int x = -1;
            int y = -1;

            if (!int.TryParse(arenaCoordinates[0], out x))
            {
                throw new ArgumentException($"{arenaCoordinates[0]} is not an integer");
            }
            if (!int.TryParse(arenaCoordinates[1], out y))
            {
                throw new ArgumentException($"{arenaCoordinates[1]} is not an integer");
            }

            if (x < 0 || y < 0)
            {
                throw new ArgumentOutOfRangeException($"{x} or {y} is not a valid grid reference");
            }

            arena = new Arena(x, y);
        } // End of ValidateArenaCoordinates


    }
}
