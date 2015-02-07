using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Animation;


namespace ThapHaNoi_NguyenThanhPhi
{
    public class Pole
    {
        public Stack<DiskControl> stack;
        Function func = new Function();
        public Pole()
        {
            stack = new Stack<DiskControl>();
        }

        public Pole(Canvas CavasRod)
        {
            CavasRod.Tag = stack = new Stack<DiskControl>();
        }

        /// <summary>
        /// HAM KHOI TAO
        /// </summary>
        /// <param name="numDiskContinue">KHOI TAO SO LUONG DIA MAC DINH KHI NGUOI CHOI CHON</param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao so luong dia theo tham so dau vao tu class DiskControl
        ///       2.Them vao CanvasA cac dia vua duoc tao (do rong cua dia lon nhat la 140, dia tiep theo co do rong giam di 10 don vi, 
        ///       dich chuyen qua ben trai 5 don vi) va tuong tu voi cac dia con lai cho den het. Do cao giam di 1 luong Contants.SpaceDisk = 31 don vi
        ///       3.Them vao stackA => chu tap cac dia Coc A</work>
        public void Init(int numDisk, Canvas CavasRod)
        {
            int topDisk = Contants.TopDisk;

            //Khoi tao so luong n dia
            for (int i = 1; i <= numDisk; i++)
            {
                var disc = new DiskControl
                {
                    Text = (numDisk - i - 1).ToString(),
                    FontSize = 30,
                    Background = new SolidColorBrush(Colors.Blue),
                    Width = 140 - 10 * i,
                    Height = 30
                };

                //Them vao giao dien dia  o vi tri thu i
                CavasRod.Children.Add(disc);
                disc.Tag = i.ToString();
                Canvas.SetTop(disc, topDisk);
                Canvas.SetLeft(disc, Contants.LeftCanvas + 5 * i);
                topDisk -= Contants.SpaceDisk;

                //Them vao stack dia o vi tri thu i
                stack.Push(disc);
            }
        }


        /// <summary>
        /// HAM THEM DIA VAO POLE
        /// </summary>
        /// <param name="numDiskContinue">Them dia "temp" vao "Canvas" voi gia tri SetTop la "getTop"</param>
        /// <purpose></purpose>
        /// <work>1.Kiem tra stack = null thi them vao voi gia tri Top = defaul
        ///       2. Push dia vao stack va Canvas
        ///       3. Lay phan tu tren cung cua stack lay Top va gan cho gia tri tiep theo la Top - Constans.SpaceDisk
        /// </work>
        public void AddDiskIntoPole(Canvas CavasRod, DiskControl temp)
        {
            DiskControl getTop;
            //Truong hop stack = null
            if (stack.Count == 0)
            {
                stack.Push(temp);
                CavasRod.Children.Add(temp);
                Canvas.SetLeft(temp, Canvas.GetLeft(temp));
                Canvas.SetTop(temp, Contants.TopDisk);
                return;
            }

            getTop = stack.Peek();
            stack.Push(temp);
            CavasRod.Children.Add(temp);
            Canvas.SetLeft(temp, Canvas.GetLeft(temp));
            Canvas.SetTop(temp, Canvas.GetTop(getTop) - Contants.SpaceDisk);
        }


        /// <summary>
        /// HAM XOA DIA TU POLE
        /// </summary>
        /// <param name="numDiskContinue">Them dia "temp" vao "Canvas" voi gia tri SetTop la "getTop"</param>
        /// <purpose></purpose>
        /// <work>1.Kiem tra stack = null thi them vao voi gia tri Top = defaul
        ///       2. Push dia vao stack va Canvas
        ///       3. Lay phan tu tren cung cua stack lay Top va gan cho gia tri tiep theo la Top - Constans.SpaceDisk
        /// </work>
        public DiskControl RemoveDiskFromPole(Canvas CavasRod)
        {
            if (stack.Count == 0) return null;
            DiskControl temp = stack.Pop();
            func.Remove(CavasRod, temp.Tag.ToString());
            return temp;
        }

        public DiskControl SetTopDiskFromPole()
        {
            if (stack.Count == 0) return null;
            DiskControl diskTab = stack.Peek();
            Canvas.SetTop(diskTab, 0);
            return diskTab;
        }

    }
}
