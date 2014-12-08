using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.Generic;

using SuperHornet422.PowerUps;
using SuperHornet422.Weapon;
using SuperHornet422.UI;

namespace SuperHornet422.Ship
{
    public class PlayerShip : IShip
    {

        public event FiredEventHandler Fired = delegate { };

        private TimeSpan lastFired = new TimeSpan(0);

        private Rectangle shipUI;

        public Rectangle ShipUI
        {
            get { return shipUI; }
            set { shipUI = value; }
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
            get { return null; } // get { return shipUI.Source; }
            set { }// set { shipUI.Source = value; }
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

        public PlayerShip(Point location, Point size, Uri locationOfShipPicture, int hitPoints, IPowerUp currentPowerUp, IWeapon weaponType)
        {
            shipUI = new Rectangle();
            ImageBrush ibrush = new ImageBrush();
            ibrush.ImageSource = new BitmapImage(new Uri("/UI/Icons/f-a-18.png", UriKind.Relative));
            shipUI.Fill = ibrush;
            this.Location = location;
            this.Size = size;
           // this.LocationOfShipPicture = locationOfShipPicture;
            //shipUI.Source = locationOfShipPicture;
            this.hitPoints = hitPoints;
            this.currentPowerUp = currentPowerUp;
            this.weaponType = weaponType;
        }

        public void updateShip(TimeSpan timeElapsed)
        {
            lastFired += timeElapsed;

            if (lastFired >= new TimeSpan(0, 0, 0, 0, 500))
            {
                lastFired = new TimeSpan(0);
                fire();
            }
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
