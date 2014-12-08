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

        private Rectangle shipRectangle;

        public Rectangle ShipRectangle
        {
            get { return shipRectangle; }
            set { shipRectangle = value; }
        }

        private ImageBrush shipImage = new ImageBrush();

        public Point Size
        {
            get
            {
                Point p = new Point();
                p.X = (double)shipRectangle.ActualWidth;
                p.Y = (double)shipRectangle.ActualHeight;
                return p;
            }
            set
            {
                shipRectangle.Width = value.X;
                shipRectangle.Height = value.Y;
            }
        }

        public ImageSource LocationOfShipPicture
        {
            get { return shipImage.ImageSource; }
            set { shipImage.ImageSource = value; }
        }

        public Point Location
        {
            get 
            { 
                Point p = new Point();
                p.X = (double)shipRectangle.GetValue(Canvas.LeftProperty);
                p.Y = (double)shipRectangle.GetValue(Canvas.TopProperty); 
                return p;
            }
            set 
            {
                shipRectangle.SetValue(Canvas.LeftProperty, value.X);
                shipRectangle.SetValue(Canvas.TopProperty, value.Y);  
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

        public PlayerShip(Point location, Point size, ImageSource locationOfShipPicture, int hitPoints, IPowerUp currentPowerUp, IWeapon weaponType)
        {
            shipRectangle = new Rectangle();
            LocationOfShipPicture = locationOfShipPicture;
            shipRectangle.Fill = shipImage;
            this.Location = location;
            this.Size = size;
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
            return (ShipFunctions.isHit(bullets, this));
        }

        public void fire()
        {
            Fired(this, new FiredEventArgs(weaponType.fire(new Point(Location.X + Size.X / 2, Location.Y - 5))));
        }
    }
}
