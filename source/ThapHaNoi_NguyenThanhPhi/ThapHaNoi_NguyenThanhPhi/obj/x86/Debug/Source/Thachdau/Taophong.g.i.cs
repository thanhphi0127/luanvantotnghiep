﻿#pragma checksum "E:\ViCopper\NĂM 2014-2015\HKII\Luan Van TN\source\ThapHaNoi_NguyenThanhPhi\ThapHaNoi_NguyenThanhPhi\Source\Thachdau\Taophong.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B51C6B1CA6E2AF991BA8C1F912A0FA24"
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


namespace ThapHaNoi_NguyenThanhPhi.Source.Thachdau {
    
    
    public partial class Taophong : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.DataTemplate lpkItemTemplate;
        
        internal System.Windows.DataTemplate lpkFullItemTemplate;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.ListPicker lpkCountry;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ThapHaNoi_NguyenThanhPhi;component/Source/Thachdau/Taophong.xaml", System.UriKind.Relative));
            this.lpkItemTemplate = ((System.Windows.DataTemplate)(this.FindName("lpkItemTemplate")));
            this.lpkFullItemTemplate = ((System.Windows.DataTemplate)(this.FindName("lpkFullItemTemplate")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.lpkCountry = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpkCountry")));
        }
    }
}
