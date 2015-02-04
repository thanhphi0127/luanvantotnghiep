using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using System.Windows.Media;

namespace ThapHaNoi_NguyenThanhPhi
{
    public partial class DiskControl : UserControl
    {

        private TranslateTransform move = new TranslateTransform();
        private TransformGroup rectangleTransforms = new TransformGroup();

        public DiskControl()
        {
            InitializeComponent();

        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
             DependencyProperty.Register("Text", typeof(string), typeof(DiskControl), null);

        public delegate void _Tap(DiskControl disk);
        public _Tap OnTap;

        private void user_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {

        }

    }
}
