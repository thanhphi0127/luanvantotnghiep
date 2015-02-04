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

namespace ThapHaNoi_NguyenThanhPhi
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        Sounds sounds = new Sounds();
        bool stateSound = false;
        public MainPage()
        {
            InitializeComponent();
            sounds.Play("main");
        }

        /*********************************************************************************
         * 
         * 
         * 
         * 
         * 
         *********************************************************************************/
        private void btn_Start_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/ThapHaNoi.xaml", UriKind.Relative));
        }

        private void Tap_Online(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Thachdau/DangNhap.xaml", UriKind.Relative));
        }

        /*********************************************************************************
         * 
         * 
         * 
         * 
         * 
         *********************************************************************************/
        private void btn_MoreGame_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/MoreGame.xaml", UriKind.Relative));
        }

        /*********************************************************************************
         * 
         * 
         * 
         * 
         * 
         *********************************************************************************/
        private void btnSound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            if (stateSound)
            {
                sounds.Play("main");
                stateSound = false;
            }
            else
            {
                sounds.Stop("main");
                stateSound = true;
            }
        }

        private void imgGioithieu(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Huongdan.xaml", UriKind.Relative));
        }

        private void btnThanhtich(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Choidon/Thanhtichcanhan.xaml", UriKind.Relative));
        }









         /*********************************************************************************
         * 
         * 
         * 
         * 
         * 
         *********************************************************************************/


        /*********************************************************************************
        * 
        * 
        * 
        * 
        * 
        *********************************************************************************/


        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}