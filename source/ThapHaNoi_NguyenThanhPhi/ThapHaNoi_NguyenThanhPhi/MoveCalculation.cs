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

        static int[] arrayPascal = {0, 0, 1, 3, 6, 10, 15, 21};

        public static List<Move> moves { get; set; }

        public static List<Move> SolveHanoi3(int numDisk)
        {
            moveCounter = 0;
            moves = new List<Move>();
            Hanoi3(numDisk, 0, 2, 1);
            return moves;
        }

        public static List<Move> SolveHanoi4(int numDisk)
        {
            moveCounter = 0;
            moves = new List<Move>();
            Hanoi4(numDisk, 4, 0, 3, 1, 2);
            return moves;
        }

        public static int GetNumMove()
        {
            return moveCounter;
        }

        /// <summary>
        /// HAM LOI GIAI BAI TOAN 3 COC
        /// </summary>
        /// <param>Tham so n la so luong dia</param>
        /// <purpose>
        /// </purpose>
        public static void Hanoi3(int n, int RodA, int RodC, int RodB)
        {
            if (n == 1)
            {
                moves.Add(new Move(RodA, RodC));
                moveCounter++;
                return;
            }
            Hanoi3(n - 1, RodA, RodB, RodC);
            Hanoi3(1, RodA, RodC, RodB);
            Hanoi3(n - 1, RodB, RodC, RodA);
        }

        /// <summary>
        /// HAM LOI GIAI BAI TOAN 4 COC
        /// </summary>
        /// <param>Tham so n la so luong dia</param>
        /// <purpose>
        /// </purpose>
        public static void Hanoi4(int n, int socot, int cotnguon, int cotdich, int trunggian1, int trunggian2)
        {
            if (n == 1)
            {
                moves.Add(new Move(cotnguon, cotdich));
                return;
            }

            if (n == 2)
            {
                moves.Add(new Move(cotnguon, trunggian1));
                moves.Add(new Move(cotnguon, cotdich));
                moves.Add(new Move(trunggian1, cotdich));
                return;
            }

            //Buoc 1
            //Xac dinh so chia toi uu trong tam giac Pascal
            int l = sochia(n);

            //Buoc 2: Chuyen l dia nho tre cung sang coc trunggian 1, su dung 4 coc
            Hanoi4(l, 4, cotnguon, trunggian1, trunggian2, cotdich);
            Hanoi3(n - l, cotnguon, cotdich, trunggian2);
            Hanoi4(l, 4, trunggian1, cotdich, trunggian2, cotnguon);

        }

        /// <summary>
        /// HAM TINH SO CHIA TOI UU L
        /// </summary>
        /// <param>Tham so n la so luong dia</param>
        /// <purpose>
        /// </purpose>
        public static int sochia(int n)
        {
            int l = 0;
            for (int i = 2; i <= 7; i++)
            {
                if (n == arrayPascal[i])
                {
                    return (n - i + 1);
                }

                if (n < arrayPascal[i])
                {
                    return (n - i + 2);
                }

            }
            return l;
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

        /*
         *             if (n == 3)
            {
                //Phat dia
                moves.Add(new Move(cotnguon, trunggian1));
                moves.Add(new Move(cotnguon, trunggian2));

                //Chuyen tu nguon sang dich
                moves.Add(new Move(cotnguon, cotdich));

                //Thu dia
                moves.Add(new Move(trunggian2, cotdich));
                moves.Add(new Move(trunggian1, cotdich));

                moveCounter += 5;
                return;
            }
         */

    }
}
