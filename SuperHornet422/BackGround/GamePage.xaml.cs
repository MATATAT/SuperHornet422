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
using System.Windows.Media.Imaging;


using SuperHornet422.Ship;

namespace SuperHornet422.BackGround
{
    public partial class GamePage : PhoneApplicationPage
    {
        PlayerShip pShip = new PlayerShip(new Point(50, 50), new Point(70, 70), new Uri("/UI/Icons/t-72.png", UriKind.Relative), 1, null, new Weapon.BasicWeapon(true));

        public GamePage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            LayoutRoot.MouseMove += new MouseEventHandler(LayoutRoot_MouseMove);
            LayoutRoot.Children.Add(pShip.ShipUI);
            GameCode game = new GameCode(pShip, this.LayoutRoot, this.Score);
            game.GameComplete += new EventHandler(game_GameComplete);
            game.startGame();
        }

        void game_GameComplete(object sender, EventArgs e)
        {
            SubmitScore newpage = new SubmitScore((sender as GameCode).Score);
            newpage.ScoreSubmitted += new EventHandler(newpage_ScoreSubmitted);
            this.Content = newpage;
        }

        void newpage_ScoreSubmitted(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        void LayoutRoot_MouseMove(object sender, MouseEventArgs e)
        {
            Point mouseLocation = e.GetPosition(LayoutRoot);
            pShip.Location = new Point(mouseLocation.X - pShip.Size.X / 2, mouseLocation.Y - pShip.Size.Y / 2);
        }
    }
}
