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
    public partial class IntroPage : PhoneApplicationPage
    {
        public IntroPage()
        {
            InitializeComponent();
            overdrive.Play();
            Intro.Completed += new EventHandler(Intro_Completed);
            Intro.Begin();
        }

        void Intro_Completed(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
