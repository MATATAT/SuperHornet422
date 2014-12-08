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

        public event EventHandler RemoveShip = delegate { };

        private IList<LocationAndTime> pathToFollow;

        public IList<LocationAndTime> PathToFollow
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

        private bool isDead = false;

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
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

        public Rectangle ShipRectangle
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

        private ShipFunctions shipFunctionsReference = new ShipFunctions();

        public ShipFunctions ShipFunctionsReference
        {
            get { return shipFunctionsReference; }
            set { shipFunctionsReference = value; }
        }

        private ImageBrush shipBrush = new ImageBrush();

        public ImageSource LocationOfShipPicture
        {
            get {return shipBrush.ImageSource; }
            set { shipBrush.ImageSource = value; }
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


        private int deathAnimationNumber = 0;

        public EnemyShip(Point location, Point size, ImageSource locationOfShipPicture, int hitPoints, IPowerUp currentPowerUp, IWeapon weaponType, Path pathToFollow, double velocity, double acceleration, ShipFunctions sf)
        {
            shipUI = new Rectangle();
            this.LocationOfShipPicture = locationOfShipPicture;
            shipUI.Fill = shipBrush;
            this.Location = location;
            this.Size = size;
            this.hitPoints = hitPoints;
            this.currentPowerUp = currentPowerUp;
            this.weaponType = weaponType;
            this.velocity = velocity;
            this.acceleration = acceleration;
            this.shipFunctionsReference = new ShipFunctions();
        }


        private TimeSpan lastFired = new TimeSpan(0);

        /// <summary>
        /// Updates current ships location and fires if needed
        /// </summary>
        /// <param name="amountOfTimeElapsed">The amount of game time that has elapsed since last called</param>
        /// <param name="random">allows the firing to be random if random == 0 and enough time has passed the ship fires</param>
        public int updateShip(TimeSpan amountOfTimeElapsed, int random)
        {
            if (isDead)
            {
                this.Location = new Point(this.Location.X, this.Location.Y + amountOfTimeElapsed.TotalSeconds * velocity);
                LocationOfShipPicture = shipFunctionsReference.getDeathImage(deathAnimationNumber*5);
                deathAnimationNumber++;
                if (deathAnimationNumber*5 > 59)
                {
                    RemoveShip(this, EventArgs.Empty);
                    return 1;
                }
            }
            else
            {
                if (Location.Y > 0)
                {
                    lastFired -= amountOfTimeElapsed;

                    if (lastFired <= new TimeSpan(0))
                    {
                        if (random == 0)
                        {
                            fire();
                            lastFired += new TimeSpan(0, 0, 0, 1, 500);
                        }
                    }
                }
                this.Location = new Point(this.Location.X, this.Location.Y + amountOfTimeElapsed.TotalSeconds * velocity);
            }
            return 0;
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
