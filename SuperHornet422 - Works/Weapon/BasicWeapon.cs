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

using SuperHornet422.UI;

namespace SuperHornet422.Weapon
{
    public class BasicWeapon : IWeapon
    {
        public BasicWeapon(bool isHumanShip)
        {
            this.isHumanShip = isHumanShip;
        }

        public IList<Bullet> fire(Point Location)
        {
            List<Bullet> bullets = new List<Bullet>();
            Rectangle rec = new Rectangle();
            Rectangle rec1 = new Rectangle();
            Point direction;
            ImageBrush ibrush = new ImageBrush();
            ibrush.ImageSource = new BitmapImage(new Uri("/UI/Icons/bullet.png", UriKind.Relative));
            rec.Fill = ibrush;
            rec1.Fill = ibrush;
            if (isHumanShip)
            {
                direction = new Point(0, -1);
            }
            else
            {
                direction = new Point(0, 1);
            }



            Bullet bullet = new Bullet(rec, new Point(Location.X - 10, Location.Y), new Point(10,15), 350, direction);

            bullets.Add(bullet);

            bullet = new Bullet(rec1, new Point(Location.X + 10, Location.Y), new Point(10, 15), 350, direction);

            bullets.Add(bullet);

            return bullets;
        }

        private bool isHumanShip;

        public bool IsHumanShip
        {
            get
            {
                return isHumanShip;
            }
            set
            {
                isHumanShip = value;
            }
        }
    }
}
