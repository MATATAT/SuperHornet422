﻿#pragma checksum "C:\Users\Nomis\Documents\My Dropbox\SuperHornet422\SuperHornet422\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "89551FEBBF9DF07ED14F1197369CA79A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
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


namespace SuperHornet422 {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard OnOpen;
        
        internal System.Windows.Controls.Grid grid;
        
        internal System.Windows.Controls.Button NewGame;
        
        internal System.Windows.Controls.Button Leaderboards;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/SuperHornet422;component/MainPage.xaml", System.UriKind.Relative));
            this.OnOpen = ((System.Windows.Media.Animation.Storyboard)(this.FindName("OnOpen")));
            this.grid = ((System.Windows.Controls.Grid)(this.FindName("grid")));
            this.NewGame = ((System.Windows.Controls.Button)(this.FindName("NewGame")));
            this.Leaderboards = ((System.Windows.Controls.Button)(this.FindName("Leaderboards")));
        }
    }
}

