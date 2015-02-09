using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace ThapHaNoi_NguyenThanhPhi
{
    public static class MoveCalculation
    {
        static int moveCounter = 0;

        public static List<Move> moves { get; set; }

        public static List<Move> Solve(int numDisk)
        {
            moveCounter = 0;
            moves = new List<Move>();
            Solution(numDisk, 0, 2, 1);
            return moves;
        }

        public static int GetNumMove()
        {
            return moveCounter;
        }


        public static void Solution(int n, int RodA, int RodC, int RodB)
        {
            //System.Threading.Thread.Sleep(1000);
            if (n == -1)
            {
                return;
            }

            if (n == 1)
            {
                moves.Add(new Move(RodA, RodC));
                return;
            }
            else
            {
                Solution(n - 1, RodA, RodB, RodC);
                Solution(1, RodA, RodC, RodB);
                Solution(n - 1, RodB, RodC, RodA);
            }
        }

        /*

        public void Solution(int n, Canvas RodA, Canvas RodC, Canvas RodB, Pole[] _pole)
        {
            //System.Threading.Thread.Sleep(1000);
            
            if (n == 1)
            {
                from = GetNamCanvas(RodA);
                to = GetNamCanvas(RodC);

                _pole[from].SetTopDiskFromPole();
                diskTemp = _pole[from].RemoveDiskFromPole(RodA);
                _pole[to].AddDiskIntoPole(RodC, diskTemp);
                return;
            }
            else
            {
                Solution(n - 1, RodA, RodB, RodC, _pole);
                Solution(1, RodA, RodC, RodB, _pole);
                Solution(n - 1, RodB, RodC, RodA, _pole);
            }
        }
         * */


    }
}
