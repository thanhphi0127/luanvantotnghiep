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
            btn_Start.Background = new SolidColorBrush(Colors.White);
            btn_Start.Background.Opacity = 0.5;
            NavigationService.Navigate(new Uri("/ThapHaNoi.xaml", UriKind.Relative));
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
            btn_MoreGame.Background = new SolidColorBrush(Colors.White);
            btn_MoreGame.Background.Opacity = 0.5;
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
            sounds.Stop("main");
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