using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Arena
    {
        public int RightHandCornerX { get; private set; }
        public int RightHandCornerY { get; private set; }

        public Arena(int x , int y)
        {
            RightHandCornerX = x;
            RightHandCornerY = y;
        }


    }
}
