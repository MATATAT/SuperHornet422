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

using SuperHornet422.UI;

namespace SuperHornet422.Ship
{
    public class ShipFunctions
    {
        static public List<Bullet> isHit(IList<Bullet> bullets, IShip ship)
        {
            List<Bullet> bulletsHit = new List<Bullet>();
            foreach (Bullet bullet in bullets)
            {
                Point shipLocationTopLeft = ship.Location;
                Point shipLocationBottemRight = new Point();

                shipLocationBottemRight.X = shipLocationTopLeft.X + ship.Size.X;
                shipLocationBottemRight.Y = shipLocationTopLeft.Y + ship.Size.Y;

                Point bulletLocationLocationTopLeft = bullet.Location;
                Point bulletLocationBottemRight = new Point();

                bulletLocationBottemRight.X = bulletLocationLocationTopLeft.X + bullet.Size.X;
                bulletLocationBottemRight.Y = bulletLocationLocationTopLeft.Y + bullet.Size.Y;

                //Checks the top left conner of the tpu to see if it is in the PU
                if (shipLocationTopLeft.X < bulletLocationLocationTopLeft.X && shipLocationBottemRight.X > bulletLocationLocationTopLeft.X && shipLocationTopLeft.Y < bulletLocationLocationTopLeft.Y && shipLocationBottemRight.Y > bulletLocationLocationTopLeft.Y)
                {
                    ship.HitPoints--;
                    bulletsHit.Add(bullet);
                }
                //Checks the top right conner of the tpu to see if it is in the PU
                else if (shipLocationBottemRight.X > bulletLocationLocationTopLeft.X && shipLocationTopLeft.X < bulletLocationBottemRight.X && shipLocationTopLeft.Y < bulletLocationLocationTopLeft.Y && shipLocationBottemRight.Y > bulletLocationLocationTopLeft.Y)
                {
                    ship.HitPoints--;
                    bulletsHit.Add(bullet);
                }
                //Checks the bottem right conner of the tpu to see if it is in the PU
                else if (shipLocationTopLeft.X < bulletLocationBottemRight.X && shipLocationBottemRight.X > bulletLocationBottemRight.X && shipLocationTopLeft.Y < bulletLocationBottemRight.Y && shipLocationBottemRight.Y > bulletLocationBottemRight.Y)
                {
                    ship.HitPoints--;
                    bulletsHit.Add(bullet);
                }
                //Checks the top right conner of the tpu to see if it is in the PU
                else if (shipLocationBottemRight.X > bulletLocationLocationTopLeft.X && shipLocationTopLeft.X < bulletLocationLocationTopLeft.X && shipLocationTopLeft.Y < bulletLocationBottemRight.Y && shipLocationBottemRight.Y > bulletLocationBottemRight.Y)
                {
                    ship.HitPoints--;
                    bulletsHit.Add(bullet);
                }
            }

            return bulletsHit;
        }
    }
}
