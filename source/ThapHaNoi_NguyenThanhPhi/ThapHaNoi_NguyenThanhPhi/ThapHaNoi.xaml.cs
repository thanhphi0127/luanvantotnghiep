using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Animation;

using ThapHaNoi_NguyenThanhPhi.Resources;

using System.Data;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using System.Windows.Threading;
using System.Windows.Media.Imaging;



namespace ThapHaNoi_NguyenThanhPhi
{
    public partial class ThapHaNoi : PhoneApplicationPage
    {
        TimeSpan time;

        Sounds sounds = new Sounds();
        Function func = new Function();

        private DispatcherTimer _timer;


        private TranslateTransform move = new TranslateTransform();
        private TransformGroup rectangleTransforms = new TransformGroup();


        Stack<DiskControl> stackA;
        Stack<DiskControl> stackB;
        Stack<DiskControl> stackC;

        Stack<DiskControl> firstClickedDisks, secondClickedDisks;

        Canvas from, to;

        DiskControl diskTab, temp, getTop;

        int moveCount = 0;
        int numDisk = 5;

        public ThapHaNoi()
        {
            InitializeComponent();
            sounds.Stop("main");

            CavasRodA.Tag = stackA = new Stack<DiskControl>();
            CavasRodB.Tag = stackB = new Stack<DiskControl>();
            CavasRodC.Tag = stackC = new Stack<DiskControl>();
            from = new Canvas();
            to = new Canvas();
            from.Name = to.Name = null;

            Init();

            //Khoi tao bo dem thoi gian DispatcherTimer
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(TimerTick);
            _timer.Interval = new TimeSpan(0, 0, 0, 1);

        }

        void Init()
        {
            numDisk = 5;
            int topDisk = Contants.TopDisk;


            for (int i = 1; i <= numDisk; i++)
            {
                var disc = new DiskControl
                {
                    FontSize = 30,
                    Width = 140 - 10 * i,
                    Height = 30
                };
                CavasRodA.Children.Add(disc);
                disc.Tag = i.ToString();
                Canvas.SetTop(disc, topDisk);
                Canvas.SetLeft(disc, Contants.LeftCanvas + 5 * i);
                topDisk -= Contants.SpaceDisk;

                stackA.Push(disc);
            }


        }


        private void MoveTopDisk(DiskControl diskTab, Stack<DiskControl> stack)
        {
            if (stack.Count == 0) return;
            diskTab = stack.Peek();
            txtThoigian.Text = diskTab.Tag.ToString();
            Canvas.SetTop(diskTab, 0);
        }


        private void Tap_Canvas(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Canvas diskRod = (Canvas)sender;
            Stack<DiskControl> diskOfClickedRod = (Stack<DiskControl>)diskRod.Tag;
            if (firstClickedDisks == null)
            {
                sounds.Play("click");
                if (diskOfClickedRod.Count == 0) return;
                //firstClickedDisks = diskOfClickedRod;
                from.Name = diskRod.Name;

                switch (diskRod.Name)
                {
                    case "CavasRodA":
                        if (stackA.Count == 0) break;
                        diskTab = stackA.Peek();
                        Canvas.SetTop(diskTab, 0);

                        firstClickedDisks = stackA;
                        break;
                    case "CavasRodB":
                        if (stackB.Count == 0) break;
                        diskTab = stackB.Peek();
                        Canvas.SetTop(diskTab, 0);

                        firstClickedDisks = stackB;
                        break;
                    case "CavasRodC":
                        if (stackC.Count == 0) break;
                        diskTab = stackC.Peek();
                        Canvas.SetTop(diskTab, 0);

                        firstClickedDisks = stackC;
                        break;

                    default:
                        break;
                }
            }
            else if (secondClickedDisks == null)
            {

                if (diskOfClickedRod == firstClickedDisks)
                {
                    //Bo chon disk
                    switch (diskRod.Name)
                    {
                        case "CavasRodA":
                            Canvas.SetTop(diskTab, (Contants.TopDisk - (stackA.Count - 1) * Contants.SpaceDisk));
                            break;
                        case "CavasRodB":
                            Canvas.SetTop(diskTab, (Contants.TopDisk - (stackB.Count - 1) * Contants.SpaceDisk));
                            break;

                        case "CavasRodC":
                            Canvas.SetTop(diskTab, (Contants.TopDisk - (stackC.Count - 1) * Contants.SpaceDisk));
                            break;

                        default:
                            break;
                    }
                    firstClickedDisks = null;
                    return;
                }

                to.Name = diskRod.Name;
                secondClickedDisks = diskOfClickedRod;
                ProcessMovingDisk(diskRod);
            }
        }


        private void ProcessMovingDisk(Canvas diskRod)
        {
            if (secondClickedDisks.Count == 0)
            {
                sounds.Play("click");
                MoveDisk(from, to);
                moveCount++;
                txtSolan.Text = "Số lần chuyển: " + moveCount;
            }
            else
            {
                DiskControl firstTopDisk = firstClickedDisks.Peek();
                DiskControl secondTopDisk = secondClickedDisks.Peek();
                if (int.Parse(firstTopDisk.Tag.ToString()) > int.Parse(secondTopDisk.Tag.ToString()))
                {
                    sounds.Play("click");
                    MoveDisk(from, to);
                    moveCount++;
                    txtSolan.Text = "Số lần chuyển: " + moveCount;
                }
                else
                {
                    
                    secondClickedDisks = null;
                }
            }
        }

        private void MoveDisk(Canvas from, Canvas to)
        {
            switch (from.Name)
            {
                case "CavasRodA":
                    temp = stackA.Pop();
                    func.Remove(CavasRodA, temp.Tag.ToString());

                    break;
                case "CavasRodB":
                    temp = stackB.Pop();
                    func.Remove(CavasRodB, temp.Tag.ToString());
                    break;

                case "CavasRodC":
                    temp = stackC.Pop();
                    func.Remove(CavasRodC, temp.Tag.ToString());
                    break;

                default:
                    break;
            }

            switch (to.Name)
            {
                case "CavasRodA":
                    /*
                     * Get top disk first
                     * Set top disk push = first - 31
                     * */
                    if (stackA.Count == 0)
                    {
                        stackA.Push(temp);
                        CavasRodA.Children.Add(temp);
                        Canvas.SetLeft(temp, Canvas.GetLeft(temp));
                        Canvas.SetTop(temp, Contants.TopDisk);
                        break;
                    }

                    getTop = stackA.Peek();

                    stackA.Push(temp);
                    CavasRodA.Children.Add(temp);
                    Canvas.SetLeft(temp, Canvas.GetLeft(temp));
                    Canvas.SetTop(temp, Canvas.GetTop(getTop) - Contants.SpaceDisk);

                    break;
                case "CavasRodB":
                    if (stackB.Count == 0)
                    {
                        stackB.Push(temp);
                        CavasRodB.Children.Add(temp);
                        Canvas.SetLeft(temp, Canvas.GetLeft(temp));
                        Canvas.SetTop(temp, Contants.TopDisk);
                        break;
                    }

                    getTop = stackB.Peek();
                    stackB.Push(temp);
                    CavasRodB.Children.Add(temp);
                    Canvas.SetLeft(temp, Canvas.GetLeft(temp));
                    Canvas.SetTop(temp, Canvas.GetTop(getTop) - Contants.SpaceDisk);
                    break;

                case "CavasRodC":
                    if (stackC.Count == 0)
                    {
                        stackC.Push(temp);
                        CavasRodC.Children.Add(temp);
                        Canvas.SetLeft(temp, Canvas.GetLeft(temp));
                        Canvas.SetTop(temp, Contants.TopDisk);
                        break;
                    }

                    getTop = stackC.Peek();
                    stackC.Push(temp);
                    CavasRodC.Children.Add(temp);
                    Canvas.SetLeft(temp, Canvas.GetLeft(temp));
                    Canvas.SetTop(temp, Canvas.GetTop(getTop) - Contants.SpaceDisk);
                    break;

                default:
                    break;
            }


            if (stackC.Count == numDisk)
            {
                MessageBox.Show("Chuc mung! Ban da chien thang", "Chuc mung", MessageBoxButton.OK);
            }

            //Xoa du lieu di chuyen va du lieu canvas
            from.Name = to.Name = null;
            firstClickedDisks = secondClickedDisks = null;
        }



        void Rectangle_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            //your code
        }
        void Rectangle_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // Move the 
            move.X += e.DeltaManipulation.Translation.X;
            move.Y += e.DeltaManipulation.Translation.Y;


        }
        void Rectangle_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            //your code
        }


        /*********************************************************************************
         * 
         * 
         * 
         *********************************************************************************/
        void TimerTick(object sender, EventArgs e)
        {
            time = time.Add(new TimeSpan(0, 0, 1));
            txtThoigian.Text = string.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);
        }

        /*********************************************************************************
         * 
         * 
         * 
         *********************************************************************************/
        private void btnPlay_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            _timer.Start();
        }

        /*********************************************************************************
         * 
         * 
         * 
         *********************************************************************************/
        private void btnHelp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            _timer.Stop();
        }

        /*********************************************************************************
         * 
         * 
         * 
         *********************************************************************************/
        private void btnRule_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
        }


        private void CavasRodA_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // Move the 
            move.X += e.DeltaManipulation.Translation.X;
            move.Y += e.DeltaManipulation.Translation.Y;
        }

        private void imgBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }







    }
}