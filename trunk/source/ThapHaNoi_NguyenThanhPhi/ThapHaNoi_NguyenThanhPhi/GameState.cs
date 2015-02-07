using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThapHaNoi_NguyenThanhPhi
{
    class GameState
    {
        Stack<DiskControl> stackA, stackB, stackC;


        public GameState()
        {
            stackA = new Stack<DiskControl>();
            stackB = new Stack<DiskControl>();
            stackC = new Stack<DiskControl>();
        }


    }
}
