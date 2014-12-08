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

using SuperHornet422.PowerUps;
using SuperHornet422.UI;
using SuperHornet422.Weapon;

namespace SuperHornet422.Ship
{
    public class EnemyShip : IEnemyShip
    {
        public event FiredEventHandler Fired = delegate { };

        private Path pathToFollow;

        public Path PathToFollow
        {
            get { return pathToFollow; }
            set { pathToFollow = value; }
        }

        public Point Location
        {
            get
            {
                Point p = new Point();
                p.X = (double)shipUI.GetValue(Canvas.LeftProperty);
                p.Y = (double)shipUI.GetValue(Canvas.TopProperty);
                return p;
            }
            set
            {
                shipUI.SetValue(Canvas.LeftProperty, value.X);
                shipUI.SetValue(Canvas.TopProperty, value.Y);
            }
        }

        private double velocity;

        public double Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        private double acceleration;

        public double Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }

        private double fireRate;

        public double FireRate
        {
            get { return fireRate; }
            set { fireRate = value; }
        }

        private Rectangle shipUI;

        public Rectangle ShipUI
        {
            get
            {
                return shipUI;
            }
            set
            {
                shipUI = value;
            }
        }

        public Point Size
        {
            get
            {
                Point p = new Point();
                p.X = (double)shipUI.ActualWidth;
                p.Y = (double)shipUI.ActualHeight;
                return p;
            }
            set
            {
                shipUI.Width = value.X;
                shipUI.Height = value.Y;
            }
        }

        public ImageSource LocationOfShipPicture
        {
            get { return null; }//shipUI.Source; }
            set { }//shipUI.Source = value; }
        }

        private int hitPoints;

        public int HitPoints
        {
            get { return hitPoints; }
            set { hitPoints = value; }
        }

        private IPowerUp currentPowerUp;

        public IPowerUp CurrentPowerUp
        {
            get { return currentPowerUp; }
            set { currentPowerUp = value; }
        }

        private IWeapon weaponType;

        public IWeapon WeaponType
        {
            get { return weaponType; }
            set { weaponType = value; }
        }

        private TimeSpan lastFired = new TimeSpan(0);

        public void updateShip(TimeSpan amountOfTimeElapsed)
        {
            if (Location.Y > 0)
            {
                lastFired += amountOfTimeElapsed;
            }
            if(lastFired >= new TimeSpan(0,0,0,2,500))
            {
                fire();
                lastFired = new TimeSpan(0);
            }

            this.Location = new Point(this.Location.X, this.Location.Y + amountOfTimeElapsed.TotalSeconds * velocity);
        }

        public EnemyShip(Point location, Point size, ImageSource locationOfShipPicture, int hitPoints, IPowerUp currentPowerUp, IWeapon weaponType, Path pathToFollow, double velocity, double acceleration)
        {
            shipUI = new Rectangle();
            ImageBrush ibrush = new ImageBrush();
            ibrush.ImageSource = locationOfShipPicture;
            shipUI.Fill = ibrush;
            this.Location = location;
            this.Size = size;
            this.LocationOfShipPicture = locationOfShipPicture;
            this.hitPoints = hitPoints;
            this.currentPowerUp = currentPowerUp;
            this.weaponType = weaponType;
            this.velocity = velocity;
            this.acceleration = acceleration;
        }

        public List<Bullet> isHit(IList<Bullet> bullets)
        {
            return ShipFunctions.isHit(bullets, this);
        }

        public void fire()
        {
            Fired(this, new FiredEventArgs(weaponType.fire(new Point(Location.X + Size.X / 2, Location.Y - 5))));
        }
    }
}
