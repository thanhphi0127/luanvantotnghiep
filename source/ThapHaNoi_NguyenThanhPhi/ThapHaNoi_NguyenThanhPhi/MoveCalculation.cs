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
    class MoveCalculation
    {
        DiskControl diskTemp;

        int from = -1;
        int to = -1;




        public int GetNamCanvas(Canvas _canvas)
        {
            switch (_canvas.Name)
            {
                case "CavasRodA":
                    return 0;
                case "CavasRodB":
                    return 1;
                case "CavasRodC":
                    return 2;
                default:
                    return -1;
            }

        }
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



    }
}
