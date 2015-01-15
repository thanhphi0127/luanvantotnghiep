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




namespace ThapHaNoi_NguyenThanhPhi
{
    public partial class ThapHaNoi : PhoneApplicationPage
    {
        TimeSpan time;
        Sounds sounds = new Sounds();
        Picture[] pics;
        Picture pic1;


        Stack<Picture> stack_pic = new Stack<Picture>();

        private DispatcherTimer _timer;
        private DateTime _startTime;

        public ThapHaNoi()
        {
            InitializeComponent();

            sounds.Stop("main");

            time = time.Add(new TimeSpan(0, 0, 1));
            txtThoigian.Text = string.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);
            Disk1.Opacity = 0;
            Disk2.Opacity = 0;

            //Khoi tao bo dem thoi gian DispatcherTimer
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(TimerTick);


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
            int numDisk = Convert.ToInt32(txtSodia.Text);

            ShowDisk(numDisk);

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
            Disk1.Opacity = 100;
            Disk2.Opacity = 100;

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
            Disk1.Opacity = 0;
            Disk2.Opacity = 0;

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