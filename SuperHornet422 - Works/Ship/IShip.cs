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

using SuperHornet422.PowerUps;
using SuperHornet422.Weapon;
using SuperHornet422.UI;


namespace SuperHornet422.Ship
{
    public delegate void FiredEventHandler(object sender, FiredEventArgs e);

    public interface IShip
    {
        event FiredEventHandler Fired;

        Rectangle ShipRectangle
        {
            get;
            set;
        }

        Point Location
        {
            get;
            set;
        }

        /// <summary>
        /// x is for width and y is for height
        /// </summary>
        Point Size
        {
            get;
            set;
        }

        ImageSource LocationOfShipPicture
        {
            get;
            set;
        }

        int HitPoints
        {
            get;
            set;
        }

        IPowerUp CurrentPowerUp
        {
            get;
            set;
        }

        IWeapon WeaponType
        {
            get;
            set;
        }

        List<Bullet> isHit(IList<Bullet> bullets);

        void fire();

    }
}