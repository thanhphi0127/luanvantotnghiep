using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ThapHaNoi_NguyenThanhPhi.Source.Thachdau
{
    public partial class DangNhap : PhoneApplicationPage
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void imgDangki(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Source/Thachdau/Dangki.xaml", UriKind.Relative)); 
        }

        private void btn_Dangnhap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Source/Thachdau/Danhsachphongchoi.xaml", UriKind.Relative));
        }

        private void btnBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Source/Thachdau/Danhsachphongchoi.xaml", UriKind.Relative));
        }
    }
}