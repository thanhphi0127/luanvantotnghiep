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

        Image[] disks;
        Stack<Image> rodA, rodB, rodC;
        Sounds sounds = new Sounds();
        Stack<Picture> stack_pic = new Stack<Picture>();

        private DispatcherTimer _timer;
        private DateTime _startTime;

        List<Disk> liskDisk = new List<Disk>();

        Disk disk = new Disk();

        private TranslateTransform move = new TranslateTransform();
        private TransformGroup rectangleTransforms = new TransformGroup();



        public ThapHaNoi()
        {
            InitializeComponent();

            sounds.Stop("main");
            
            time = time.Add(new TimeSpan(0, 0, 1));
            txtThoigian.Text = string.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);

            //disk3, disk4, disk5, disk6, disk7, disk8, disk9, disk10 

            //Khoi tao bo dem thoi gian DispatcherTimer
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(TimerTick);




            /////
            Image img = disk.CreateDisk(1);
            Image img2 = disk.CreateDisk(2);

            StackRodA.Children.Add(img);
            StackRodB.Children.Add(img2);

            rectangleTransforms.Children.Add(move);

            img.RenderTransform = rectangleTransforms;

            img.ManipulationStarted +=
                new EventHandler<ManipulationStartedEventArgs>(Rectangle_ManipulationStarted);
            img.ManipulationDelta +=
                new EventHandler<ManipulationDeltaEventArgs>(Rectangle_ManipulationDelta);
            img.ManipulationCompleted +=
                new EventHandler<ManipulationCompletedEventArgs>(Rectangle_ManipulationCompleted);
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
            var time = DateTime.Now - _startTime;
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
            //int numDisk = Convert.ToInt32(txtSodia.Text);

            //ShowDisk(numDisk);

        }

        /*********************************************************************************
         * 
         * 
         * 
         *********************************************************************************/
        private void btnHelp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
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

        private void ShowDisk(int numDisk)
        {


            switch (numDisk)
            {
                case 3:
                    //Disk3.Opacity = 100;
                    break;

                case 4:
                   // Disk3.Opacity = 100;
                    //Disk4.Opacity = 100;
                    break;

                default:
                    break;
            }
        }

        private void HideDisk(int numDisk)
        {


            switch (numDisk)
            {
                case 3:
                    //Disk3.Opacity = 0;
                    break;

                case 4:

                    break;

                default:
                    break;
            }
        }

    }
}