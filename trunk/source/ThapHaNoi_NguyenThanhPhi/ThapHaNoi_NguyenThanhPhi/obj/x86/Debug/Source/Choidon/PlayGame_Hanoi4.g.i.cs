﻿#pragma checksum "E:\ViCopper\NĂM 2014-2015\HKII\Luan Van TN\source\ThapHaNoi_NguyenThanhPhi\ThapHaNoi_NguyenThanhPhi\Source\Choidon\PlayGame_Hanoi4.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7FDA8D6ED81AF68D9940ED37DC5955A9"
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
    
    
    public partial class PlayGame_Hanoi4 : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.DataTemplate lpkItemTemplate;
        
        internal System.Windows.DataTemplate lpkFullItemTemplate;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Grid Rod;
        
        internal System.Windows.Controls.Canvas CavasRodD;
        
        internal System.Windows.Controls.Canvas CavasRodC;
        
        internal System.Windows.Controls.Canvas CavasRodB;
        
        internal System.Windows.Controls.Canvas CavasRodA;
        
        internal System.Windows.Controls.Grid Manulation;
        
        internal System.Windows.Controls.TextBlock txtThoigian;
        
        internal System.Windows.Controls.TextBlock txtSolan;
        
        internal System.Windows.Controls.Canvas canvasStart;
        
        internal System.Windows.Controls.Grid ContentPanel1;
        
        internal Microsoft.Phone.Controls.ListPicker listNumDisk;
        
        internal System.Windows.Controls.Button btnPlay;
        
        internal System.Windows.Controls.Canvas canvasWin;
        
        internal System.Windows.Controls.Button btnChoilai;
        
        internal System.Windows.Controls.Button btnTieptuc;
        
        internal System.Windows.Controls.TextBox txtNguoichoi;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ThapHaNoi_NguyenThanhPhi;component/Source/Choidon/PlayGame_Hanoi4.xaml", System.UriKind.Relative));
            this.lpkItemTemplate = ((System.Windows.DataTemplate)(this.FindName("lpkItemTemplate")));
            this.lpkFullItemTemplate = ((System.Windows.DataTemplate)(this.FindName("lpkFullItemTemplate")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.Rod = ((System.Windows.Controls.Grid)(this.FindName("Rod")));
            this.CavasRodD = ((System.Windows.Controls.Canvas)(this.FindName("CavasRodD")));
            this.CavasRodC = ((System.Windows.Controls.Canvas)(this.FindName("CavasRodC")));
            this.CavasRodB = ((System.Windows.Controls.Canvas)(this.FindName("CavasRodB")));
            this.CavasRodA = ((System.Windows.Controls.Canvas)(this.FindName("CavasRodA")));
            this.Manulation = ((System.Windows.Controls.Grid)(this.FindName("Manulation")));
            this.txtThoigian = ((System.Windows.Controls.TextBlock)(this.FindName("txtThoigian")));
            this.txtSolan = ((System.Windows.Controls.TextBlock)(this.FindName("txtSolan")));
            this.canvasStart = ((System.Windows.Controls.Canvas)(this.FindName("canvasStart")));
            this.ContentPanel1 = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel1")));
            this.listNumDisk = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listNumDisk")));
            this.btnPlay = ((System.Windows.Controls.Button)(this.FindName("btnPlay")));
            this.canvasWin = ((System.Windows.Controls.Canvas)(this.FindName("canvasWin")));
            this.btnChoilai = ((System.Windows.Controls.Button)(this.FindName("btnChoilai")));
            this.btnTieptuc = ((System.Windows.Controls.Button)(this.FindName("btnTieptuc")));
            this.txtNguoichoi = ((System.Windows.Controls.TextBox)(this.FindName("txtNguoichoi")));
        }
    }
}

