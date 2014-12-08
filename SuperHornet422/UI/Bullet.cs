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

namespace SuperHornet422.UI
{
    public class Bullet
    {
        private Rectangle bulletImage;

        public Rectangle BulletImage
        {
            get { return bulletImage; }
            set { bulletImage = value; }
        }

        private double velocity;
        private Point direction;

        public Point Location
        {
            get
            {
                Point p = new Point();
                p.X = (double)bulletImage.GetValue(Canvas.LeftProperty);
                p.Y = (double)bulletImage.GetValue(Canvas.TopProperty);
                return p;
            }
            set
            {

            }
        }


        public Point Size
        {
            get
            {
                Point p = new Point();
                p.X = (double)bulletImage.ActualWidth;
                p.Y = (double)bulletImage.ActualHeight;
                return p;
            }
        }

        public Bullet(Rectangle bulletPic, Point Location, Point Size, double velocity, Point direction)
        {
            this.bulletImage = bulletPic;
            bulletPic.SetValue(Canvas.LeftProperty, Location.X);
            bulletPic.SetValue(Canvas.TopProperty, Location.Y);
            bulletPic.Width =  Size.X;
            bulletPic.Height = Size.Y;
            this.velocity = velocity;
            this.direction = direction;
        }

        public void UpdateBullet(TimeSpan timeElapsed)
        {
            Point deltaP = new Point();
            Point location = new Point();
            deltaP.X = (velocity * timeElapsed.TotalSeconds) * direction.X;
            deltaP.Y = (velocity * timeElapsed.TotalSeconds) * direction.Y;

            location.X = (double) bulletImage.GetValue(Canvas.LeftProperty);
            location.Y = (double)bulletImage.GetValue(Canvas.TopProperty);

            location.X = deltaP.X + location.X;
            location.Y = deltaP.Y + location.Y;

            bulletImage.SetValue(Canvas.LeftProperty, location.X);
            bulletImage.SetValue(Canvas.TopProperty, location.Y);

        }
    }
}
