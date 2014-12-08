using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

using SuperHornet422.Ship;
using SuperHornet422.PowerUps;
using SuperHornet422.UI;
using SuperHornet422.Weapon;

namespace SuperHornet422
{
    public class Level
    {
        public event EventHandler GameOver = delegate { };

        private int score = 0;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        private TextBlock scoreTextBlock;

        private Canvas gameCanvas;
        
        private TimeSpan elapsedTime = new TimeSpan(0);

        private PlayerShip playerShip;

        private List<IEnemyShip> enemyShip = new List<IEnemyShip>();

        private TimeSpan timerTickTime = new TimeSpan(0, 0, 0, 0, 1000/30); // 100 Milliseconds

        private List<Bullet> playerBullets = new List<Bullet>();

        private List<Bullet> enemyBullets = new List<Bullet>();

        private int waveNumber = 0;

        private System.Windows.Threading.DispatcherTimer GameTimer;
        
        public Level(Canvas gameCanvas, PlayerShip playerShip, TextBlock scoreTextBlock)
        {
            this.scoreTextBlock = scoreTextBlock;
            this.gameCanvas = gameCanvas;
            this.playerShip = playerShip;
            this.playerShip.Fired += new FiredEventHandler(playerShip_Fired);
        }

        public void PauseGame()
        {
            GameTimer.Stop();
        }

        public void ResumeGame()
        {
            GameTimer.Start();
        }

        public void SaveState()
        {
        }

        private void playerShip_Fired(object sender, FiredEventArgs e)
        {
            foreach (Bullet bullet in e.Bullets)
            {
                gameCanvas.Children.Add(bullet.BulletImage);
                playerBullets.Add(bullet);            
            }
        }

        void me_MediaEnded(object sender, RoutedEventArgs e)
        {
            gameCanvas.Children.Remove(sender as UIElement);
        }

        private void enemyShip_Fired(object sender, FiredEventArgs e)
        {
            foreach (Bullet bullet in e.Bullets)
            {
                gameCanvas.Children.Add(bullet.BulletImage);
                enemyBullets.Add(bullet);
            }
        }

        public void startLevel()
        {
            GameTimer = new System.Windows.Threading.DispatcherTimer();
            GameTimer.Interval = timerTickTime;  
            GameTimer.Tick += new EventHandler(Timer_Tick);
            GameTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime += timerTickTime;

            foreach (Bullet bullet in enemyBullets)
            {
                //need to check if bullet goes of the side of the screen not sure how
                bullet.UpdateBullet(timerTickTime);
            }

            //cannot edit the container that the forloop is so make a new list of all the dead ships and remove them later
            List<IEnemyShip> deadShips = new List<IEnemyShip>();
            foreach (IEnemyShip eShip in enemyShip)
            {
                eShip.updateShip(timerTickTime);
                foreach(Bullet bullet in eShip.isHit(playerBullets))
                {
                    playerBullets.Remove(bullet);
                    gameCanvas.Children.Remove(bullet.BulletImage);
                }
                if (eShip.HitPoints <= 0)
                {
                    deadShips.Add(eShip);
                    score += 10;
                }

            }

            foreach (IEnemyShip eShip in deadShips)
            {
                /*MediaElement me = new MediaElement();
                me.Source = new Uri("/UI/Icons/boom-1.avi", UriKind.Relative);
                me.MediaEnded += new RoutedEventHandler(me_MediaEnded);
                me.SetValue(Canvas.LeftProperty, eShip.Location.X);
                me.SetValue(Canvas.TopProperty, eShip.Location.Y);
                me.Width = eShip.Size.X;
                me.Height = eShip.Size.Y;
                
                gameCanvas.Children.Add(me);
                me.Play();*/
                /*ImageBrush ibrush = new ImageBrush();
                ibrush.ImageSource = new BitmapImage(new Uri("/UI/Icons/boom-1.gif", UriKind.Relative));*/
                gameCanvas.Children.Remove(eShip.ShipUI);
                enemyShip.Remove(eShip);
            }
            foreach (Bullet bullet in playerShip.isHit(enemyBullets))
            {
                enemyBullets.Remove(bullet);
                gameCanvas.Children.Remove(bullet.BulletImage);
            }
            if (playerShip.HitPoints <= 0)
            {
                //GAME OVER or LIVES
                GameTimer.Stop();
                GameOver(this, EventArgs.Empty);
            }

            playerShip.updateShip(timerTickTime);

            List<Bullet> deadBullets = new List<Bullet>();
            foreach (Bullet bullet in playerBullets)
            {
                bullet.UpdateBullet(timerTickTime);
                if (bullet.Location.Y < 0)
                {
                    gameCanvas.Children.Remove(bullet.BulletImage);
                    deadBullets.Add(bullet);
                }
            }

            foreach (Bullet bullet in deadBullets)
            {
                playerBullets.Remove(bullet);
            }

            nextWave(elapsedTime);

            //update score textBlock
            scoreTextBlock.Text = "Score = " + score.ToString();

        }

        private void nextWave(TimeSpan elapsedTime)
        {
            List<EnemyShip> eWave = new List<EnemyShip>();

            if (waveNumber < 5)
            {
                if (elapsedTime.TotalSeconds > 3 * (waveNumber + 1))
                {
                    waveNumber++;
                    Path path = new Path();

                    eWave = EnemyShipWaveFactory.CreateEnemyWave(new Point((100 * waveNumber) % 400, 0), new Path(), 5, ShipType.basicLevel1);
                }
            }

            else if (waveNumber < 10)
            {
                if (elapsedTime.TotalSeconds > 3 * (waveNumber + 1))
                {
                    waveNumber++;
                    Path path = new Path();

                    eWave = EnemyShipWaveFactory.CreateEnemyWave(new Point((100 * waveNumber) % 400, 0), new Path(), 3, ShipType.strongLevel2);
                }
            }

            else if (waveNumber < 15)
            {
                if (elapsedTime.TotalSeconds > 3 * (waveNumber + 1))
                {
                    waveNumber++;
                    Path path = new Path();

                    eWave = EnemyShipWaveFactory.CreateEnemyWave(new Point((100 * waveNumber) % 400, 0), new Path(), 5, ShipType.fastLevel3);
                }
            }

                foreach (EnemyShip eShip in eWave)
                {
                    gameCanvas.Children.Add(eShip.ShipUI);
                    eShip.Fired += new FiredEventHandler(eShip_Fired);
                    enemyShip.Add(eShip);
                }
        }

        void eShip_Fired(object sender, FiredEventArgs e)
        {
            foreach (Bullet bullet in e.Bullets)
            {
                gameCanvas.Children.Add(bullet.BulletImage);
                enemyBullets.Add(bullet);
            }
        }

    }
}
