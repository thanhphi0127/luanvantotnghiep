﻿#pragma checksum "E:\ViCopper\NĂM 2014-2015\HKII\Luan Van TN\source\ThapHaNoi_NguyenThanhPhi\ThapHaNoi_NguyenThanhPhi\Source\Choidon\Help.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2D4352FC117A7781477868748F56183B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ThapHaNoi_NguyenThanhPhi.Source.Choidon {
    
    
    public partial class Help : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.DataTemplate lpkItemTemplate;
        
        internal System.Windows.DataTemplate lpkFullItemTemplate;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Canvas CavasRodA;
        
        internal System.Windows.Controls.Canvas CavasRodB;
        
        internal System.Windows.Controls.Canvas CavasRodC;
        
        internal System.Windows.Controls.Canvas CavasRodD;
        
        internal System.Windows.Controls.Button btnBegin;
        
        internal System.Windows.Controls.TextBlock txtSolan;
        
        internal System.Windows.Controls.TextBlock txtSolve;
        
        internal System.Windows.Controls.ScrollViewer listHelp;
        
        internal System.Windows.Controls.StackPanel stackList;
        
        internal System.Windows.Controls.Slider sliderSpeed;
        
        internal System.Windows.Controls.TextBlock txtSpeed;
        
        internal Microsoft.Phone.Controls.ListPicker listNumDisk;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/ThapHaNoi_NguyenThanhPhi;component/Source/Choidon/Help.xaml", System.UriKind.Relative));
            this.lpkItemTemplate = ((System.Windows.DataTemplate)(this.FindName("lpkItemTemplate")));
            this.lpkFullItemTemplate = ((System.Windows.DataTemplate)(this.FindName("lpkFullItemTemplate")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.CavasRodA = ((System.Windows.Controls.Canvas)(this.FindName("CavasRodA")));
            this.CavasRodB = ((System.Windows.Controls.Canvas)(this.FindName("CavasRodB")));
            this.CavasRodC = ((System.Windows.Controls.Canvas)(this.FindName("CavasRodC")));
            this.CavasRodD = ((System.Windows.Controls.Canvas)(this.FindName("CavasRodD")));
            this.btnBegin = ((System.Windows.Controls.Button)(this.FindName("btnBegin")));
            this.txtSolan = ((System.Windows.Controls.TextBlock)(this.FindName("txtSolan")));
            this.txtSolve = ((System.Windows.Controls.TextBlock)(this.FindName("txtSolve")));
            this.listHelp = ((System.Windows.Controls.ScrollViewer)(this.FindName("listHelp")));
            this.stackList = ((System.Windows.Controls.StackPanel)(this.FindName("stackList")));
            this.sliderSpeed = ((System.Windows.Controls.Slider)(this.FindName("sliderSpeed")));
            this.txtSpeed = ((System.Windows.Controls.TextBlock)(this.FindName("txtSpeed")));
            this.listNumDisk = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listNumDisk")));
        }
    }
}

