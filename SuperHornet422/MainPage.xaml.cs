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

namespace SuperHornet422
{
    public partial class MainPage : PhoneApplicationPage
    {
        static private bool introPlayed = false;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            OnOpen.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/MenuItems/LevelSelect.xaml", UriKind.Relative));
        }

        private void Leaderboards_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MenuItems/Leaderboards.xaml", UriKind.Relative));
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MenuItems/OptionSelect.xaml", UriKind.Relative));
        }

        private void Intro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MenuItems/IntroPage.xaml", UriKind.Relative));
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BackGround/GamePage.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (introPlayed == false)
            {
                introPlayed = true;
               NavigationService.Navigate(new Uri("/MenuItems/IntroPage.xaml", UriKind.Relative));
            }
        }
    }
}