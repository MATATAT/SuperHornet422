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

        private ShipFunctions shipFunctions = new ShipFunctions();

        private Random randomNumber = new Random((int)DateTime.Now.Ticks);

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

            for(int i = 0; i < enemyShip.Count; i++)
            {
                IEnemyShip eShip = enemyShip[i];
                i -= eShip.updateShip(timerTickTime, randomNumber.Next() % 25);
                if (!eShip.IsDead)
                {
                    foreach (Bullet bullet in eShip.isHit(playerBullets))
                    {

                        playerBullets.Remove(bullet);
                        gameCanvas.Children.Remove(bullet.BulletImage);
                    }
                    if (eShip.HitPoints <= 0)
                    {
                        eShip.IsDead = true;
                        eShip.RemoveShip += new EventHandler(eShip_RemoveShip);
                        score += 10;
                    }
                }
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

        void eShip_RemoveShip(object sender, EventArgs e)
        {
            IEnemyShip eShip = (sender as IEnemyShip);
            gameCanvas.Children.Remove(eShip.ShipRectangle);
            enemyShip.Remove(eShip);
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

                    eWave = EnemyShipWaveFactory.CreateEnemyWave(new Point((100 * waveNumber) % 400, 0), new Path(), 5, ShipType.basicLevel1, shipFunctions);
                }
            }

            else if (waveNumber < 10)
            {
                if (elapsedTime.TotalSeconds > 3 * (waveNumber + 1))
                {
                    waveNumber++;
                    Path path = new Path();

                    eWave = EnemyShipWaveFactory.CreateEnemyWave(new Point((100 * waveNumber) % 400, 0), new Path(), 3, ShipType.strongLevel2, shipFunctions);
                }
            }

            else if (waveNumber < 15)
            {
                if (elapsedTime.TotalSeconds > 3 * (waveNumber + 1))
                {
                    waveNumber++;
                    Path path = new Path();

                    eWave = EnemyShipWaveFactory.CreateEnemyWave(new Point((100 * waveNumber) % 400, 0), new Path(), 5, ShipType.fastLevel3, shipFunctions);
                }
            }

                foreach (EnemyShip eShip in eWave)
                {
                    gameCanvas.Children.Add(eShip.ShipRectangle);
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
