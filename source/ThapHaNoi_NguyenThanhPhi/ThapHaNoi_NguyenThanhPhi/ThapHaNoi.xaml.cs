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
        /// <summary>
        /// VUNG CODE THAM SO, BIEN CUC BO
        /// </summary>
        /// <param name="numDiskContinue"></param>
        /// <purpose></purpose>
        #region KHOI TAO CAC BIEN, THAM SO
            Sounds sounds = new Sounds();
            Function func = new Function();
            GameState game = new GameState();

            TimeSpan time, time_auto;
            private DispatcherTimer _timer, _timer_auto;
            private TranslateTransform move = new TranslateTransform();
            private TransformGroup rectangleTransforms = new TransformGroup();
            Stack<DiskControl> firstClickedDisks, secondClickedDisks;

            Pole[] _pole = new Pole[3];
            //Cac bien cuc bo cho viec luu tru du lieu 
            int moveCount = 0;
            int numDisk = 3;
            int[] comboNumDisk = { 3, 4, 5, 6, 7, 8, 9, 10 };

            //Cac bien kieu giao dien de luu tru trang thai chuyen du lieu
            Canvas from, to;
            DiskControl diskTab, temp;
        #endregion

        /// <summary>
        /// HAM XAY DUNG
        /// </summary>
        /// <param name="numDiskContinue"></param>
        /// <purpose></purpose>
        public ThapHaNoi()
        {
            InitializeComponent();
            sounds.Stop("main");
            this.listNumDisk.ItemsSource = comboNumDisk;

            _pole[0] = new Pole(CavasRodA);
            _pole[1] = new Pole(CavasRodB);
            _pole[2] = new Pole(CavasRodC);
            
            from = new Canvas();
            to = new Canvas();
            from.Name = to.Name = null;

            //Khoi tao bo dem thoi gian DispatcherTimer
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(TimerTick);
            _timer.Interval = new TimeSpan(0, 0, 0, 1);

        }


        /// <summary>
        /// HAM KHOI TAO LAI TRANG THAI GAME VOI SO LUONG DIA = SO LUONG DIA + 1
        /// </summary>
        /// <param name="numDiskContinue">Cho phep nguoi choi khoi dong lai game voi so luong dia la tham so dau vao</param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao lai bo dem thoi gian
        ///       2.Xoa cac dia hien tai
        ///       3.Dat lai thoi gian</work>
        private void RestartGame(int numDiskContinue)
        {
            //Khoi tao bo dem thoi gian DispatcherTimer
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(TimerTick);
            _timer.Interval = new TimeSpan(0, 0, 0, 1);
            _timer.Start();

            //Xoa cac dia dang hien thi tren Canvas va luu tru trong stack
            _pole[0].stack.Clear(); _pole[1].stack.Clear(); _pole[2].stack.Clear();
            CavasRodA.Children.Clear();
            CavasRodB.Children.Clear();
            CavasRodC.Children.Clear();
            firstClickedDisks = secondClickedDisks = null;

            //Dat lai thoi gian va so lan di chuyen la 0
            txtSolan.Text = Contants.DefaultCountValue;
            txtThoigian.Text = Contants.DefaultTimeValue;

            //Them dia vao coc A 
            _pole[0].Init(numDiskContinue, CavasRodA);
            moveCount = 0;

            //Visibility cac canvas bat dau choi va chien thang
            canvasStart.Visibility = Visibility.Collapsed;
            canvasWin.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// HAM DI CHUYEN DIA LEN TREN CUNG CUA MOI COC
        /// </summary>
        /// <param name="numDiskContinue"></param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao lai bo dem thoi gian
        ///       2.Xoa cac dia hien tai
        ///       3.Dat lai thoi gian</work>
        private void MoveTopDisk(DiskControl diskTab, Stack<DiskControl> stack)
        {
            if (stack.Count == 0) return;
            diskTab = stack.Peek();
            txtThoigian.Text = diskTab.Tag.ToString();
            Canvas.SetTop(diskTab, 0);
        }

        /// <summary>
        /// HAM SU LY SU KIEN CHAM VAO 3 COC TREN GIAO DIEN
        /// </summary>
        /// <param name="numDiskContinue">/param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao lai bo dem thoi gian
        ///       2.Xoa cac dia hien tai
        ///       3.Dat lai thoi gian</work>
        private void Tap_Canvas(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Canvas diskRod = (Canvas)sender;
            Stack<DiskControl> diskOfClickedRod = (Stack<DiskControl>)diskRod.Tag;
            if (firstClickedDisks == null)
            {
                if (diskOfClickedRod.Count == 0) return;
                //firstClickedDisks = diskOfClickedRod;
                from.Name = diskRod.Name;

                switch (diskRod.Name)
                {
                    case "CavasRodA":
                        /*
                        if (_pole[0].stack.Count == 0) break;
                        diskTab = _pole[0].stack.Peek();
                        Canvas.SetTop(diskTab, 0);
                         * */
                        diskTab = _pole[0].SetTopDiskFromPole();

                        firstClickedDisks = _pole[0].stack;
                        break;
                    case "CavasRodB":
                        if (_pole[1].stack.Count == 0) break;
                        diskTab = _pole[1].stack.Peek();
                        Canvas.SetTop(diskTab, 0);

                        firstClickedDisks = _pole[1].stack;
                        break;
                    case "CavasRodC":
                        if (_pole[2].stack.Count == 0) break;
                        diskTab = _pole[2].stack.Peek();
                        Canvas.SetTop(diskTab, 0);

                        firstClickedDisks = _pole[2].stack;
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
                            Canvas.SetTop(diskTab, (Contants.TopDisk - (_pole[0].stack.Count - 1) * Contants.SpaceDisk));
                            break;
                        case "CavasRodB":
                            Canvas.SetTop(diskTab, (Contants.TopDisk - (_pole[1].stack.Count - 1) * Contants.SpaceDisk));
                            break;

                        case "CavasRodC":
                            Canvas.SetTop(diskTab, (Contants.TopDisk - (_pole[2].stack.Count - 1) * Contants.SpaceDisk));
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

        /// <summary>
        /// HAM TIEN TRINH DI CHUYEN DIA
        /// </summary>
        /// <param name="numDiskContinue">Cho phep nguoi choi khoi dong lai game voi so luong dia la tham so dau vao</param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao lai bo dem thoi gian
        ///       2.Xoa cac dia hien tai
        ///       3.Dat lai thoi gian</work>
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
                    //sounds.Play("wrong");
                    secondClickedDisks = null;
                }
            }
        }

        /// <summary>
        ///  HAM DI CHUYEN DIA TU COC NGUON => COC DICH
        /// </summary>
        /// <param name="numDiskContinue">Cho phep nguoi choi khoi dong lai game voi so luong dia la tham so dau vao</param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao lai bo dem thoi gian
        ///       2.Xoa cac dia hien tai
        ///       3.Dat lai thoi gian</work>
        private void MoveDisk(Canvas from, Canvas to)
        {
            switch (from.Name)
            {
                case "CavasRodA":
                    temp = _pole[0].RemoveDiskFromPole(CavasRodA);
                    break;
                case "CavasRodB":
                    temp = _pole[1].RemoveDiskFromPole(CavasRodB);
                    break;
                case "CavasRodC":
                    temp = _pole[2].RemoveDiskFromPole(CavasRodC);
                    break;
                default:
                    break;
            }

            switch (to.Name)
            {
                case "CavasRodA":
                    _pole[0].AddDiskIntoPole(CavasRodA, temp);
                    break;
                case "CavasRodB":
                    _pole[1].AddDiskIntoPole(CavasRodB, temp);
                    break;
                case "CavasRodC":
                    _pole[2].AddDiskIntoPole(CavasRodC, temp);
                    break;
                default:
                    break;
            }


            if (_pole[2].stack.Count == numDisk)
            {
                //MessageBox.Show("Chuc mung! Ban da chien thang", "Chuc mung", MessageBoxButton.OK);
                _timer.Stop();
                //sounds.Play("win");
                canvasWin.Visibility = Visibility.Visible;
                //Luu lai bang xep hang
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


        /// <summary>
        /// TIME STICK
        /// </summary>
        /// <param name="numDiskContinue">Su dung de dem thoi gian, don vi 1 giay cap nhat 1 lan</param>
        void TimerTick(object sender, EventArgs e)
        {
            time = time.Add(new TimeSpan(0, 0, 1));
            txtThoigian.Text = string.Format(Contants.TimeFormat, time.Hours, time.Minutes, time.Seconds);
        }

        /// <summary>
        /// SU KIEN NHAN VAO "PLAY"
        /// </summary>
        /// <param name="numDiskContinue"></param>
        /// <purpose></purpose>
        private void btnPlay_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            _timer.Start();
            numDisk = int.Parse(listNumDisk.SelectedItem.ToString());

            //Them dia vao COC A
            _pole[0].Init(numDisk, CavasRodA);

            canvasStart.Visibility = Visibility.Collapsed;
            canvasWin.Visibility = Visibility.Collapsed;
            
        }


        /// <summary>
        /// SU KIEN NHAN VAO "LUAT CHOI"
        /// </summary>
        /// <param name="numDiskContinue"></param>
        /// <purpose></purpose>
        private void btnRule_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numDiskContinue"></param>
        /// <purpose></purpose>
        private void CavasRodA_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // Move the 
            move.X += e.DeltaManipulation.Translation.X;
            move.Y += e.DeltaManipulation.Translation.Y;
        }

        /// <summary>
        /// SU KIEN NHAN VAO "BACK"
        /// </summary>
        /// <param name="numDiskContinue">Dieu huong den trang chu cua ung dung</param>
        /// <purpose></purpose>
        private void imgBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        /// <summary>
        /// SU KIEN NHAP VAO "TIEP TUC" KHI DA CHIEN THANG O CAP DO i VA TIEP TUC CHOI TIEP CAP DO i+1
        /// </summary>
        /// <purpose>Cho phep nguoi choi chon tiep tuc de choi mot muc do khac</purpose>
        /// 
        private void Tap_Tieptuc(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            //Tang so luong dia hien tai len 1 don vi
            numDisk = numDisk + 1;
            RestartGame(numDisk);

        }

        /// <summary>
        /// SU KIEN NHAN "LUAT CHOI"
        /// </summary>
        /// <purpose>Dieu thuong den trang luat choi</purpose>
        private void Tap_LuatChoi(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Huongdan.xaml", UriKind.Relative));
        }

        private void Tap_Trogiup(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            //Dat lai thoi gian va so lan di chuyen la 0
            txtSolan.Text = Contants.DefaultCountValue;
            txtThoigian.Text = Contants.DefaultTimeValue;

            RestartGame(numDisk);
            _timer_auto.Start();

            if (_pole[2].stack.Count == numDisk)
            {
                _timer_auto.Stop();
                MessageBox.Show("Hoan thanh", "OK", MessageBoxButton.OK);
            }
        }


    }
}

/*
        /// <summary>
        /// HAM SU LY SU KIEN CHAM VAO 3 COC TREN GIAO DIEN
        /// </summary>
        /// <param name="numDiskContinue">/param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao lai bo dem thoi gian
        ///       2.Xoa cac dia hien tai
        ///       3.Dat lai thoi gian</work>
        private void Tap_Canvas(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Canvas diskRod = (Canvas)sender;
            Stack<DiskControl> diskOfClickedRod = (Stack<DiskControl>)diskRod.Tag;
            if (firstClickedDisks == null)
            {
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

        /// <summary>
        /// HAM TIEN TRINH DI CHUYEN DIA
        /// </summary>
        /// <param name="numDiskContinue">Cho phep nguoi choi khoi dong lai game voi so luong dia la tham so dau vao</param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao lai bo dem thoi gian
        ///       2.Xoa cac dia hien tai
        ///       3.Dat lai thoi gian</work>
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
                    //sounds.Play("wrong");
                    secondClickedDisks = null;
                }
            }
        }

        /// <summary>
        ///  HAM DI CHUYEN DIA TU COC NGUON => COC DICH
        /// </summary>
        /// <param name="numDiskContinue">Cho phep nguoi choi khoi dong lai game voi so luong dia la tham so dau vao</param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao lai bo dem thoi gian
        ///       2.Xoa cac dia hien tai
        ///       3.Dat lai thoi gian</work>
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
                //MessageBox.Show("Chuc mung! Ban da chien thang", "Chuc mung", MessageBoxButton.OK);
                _timer.Stop();
                //sounds.Play("win");
                canvasWin.Visibility = Visibility.Visible;
                //Luu lai bang xep hang
            }

            //Xoa du lieu di chuyen va du lieu canvas
            from.Name = to.Name = null;
            firstClickedDisks = secondClickedDisks = null;
        }

*/