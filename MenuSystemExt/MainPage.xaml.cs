using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MenuSystem2
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            OnOpen.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Uri("/LevelSelect.xaml", UriKind.Relative));
        }

        private void Leaderboards_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/LevelSelect.xaml", UriKind.Relative));
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/OptionSelect.xaml", UriKind.Relative));
        }

        private void Intro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/IntroPage.xaml", UriKind.Relative));
        }
    }
}