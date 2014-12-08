using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using SuperHornet422.Weapon;

namespace SuperHornet422.Ship
{
    public class EnemyShipFactory
    {
        public static EnemyShip CreateEnemyShipBasicLevel1(Point Location, Path PathToFollow)
        {
            return new EnemyShip(Location, new Point(40, 40), new BitmapImage(new Uri("/UI/Icons/mig-17.png", UriKind.Relative)), 1, null, new BasicWeapon(false), PathToFollow, 100, 0);
        }

        public static EnemyShip CreateEnemyShipStrongLevel2(Point Location, Path PathToFollow)
        {
            return new EnemyShip(Location, new Point(60, 60), new BitmapImage(new Uri("/UI/Icons/mig-19.png", UriKind.RelativeOrAbsolute)), 3, null, new BasicWeapon(false), PathToFollow, 75, 0);
        }

        public static EnemyShip CreateEnemyShipFastLevel3(Point Location, Path PathToFollow)
        {
            return new EnemyShip(Location, new Point(30, 30), new BitmapImage(new Uri("/UI/Icons/mig-21.png", UriKind.RelativeOrAbsolute)), 1, null, new BasicWeapon(false), PathToFollow, 250, 0);
        }

        public static EnemyShip CreateEnemyShipStrongLevel4(Point Location, Path PathToFollow)
        {
            return new EnemyShip(Location, new Point(25, 25), new BitmapImage(new Uri("/UI/ShipImages/Eship.bmp", UriKind.RelativeOrAbsolute)), 6, null, new BasicWeapon(false), PathToFollow, 200, 0);
        }

        public static EnemyShip CreateEnemyShipBasicLevel5(Point Location, Path PathToFollow)
        {
            return new EnemyShip(Location, new Point(15, 15), new BitmapImage(new Uri("/UI/ShipImages/Eship.bmp", UriKind.RelativeOrAbsolute)), 3, null, new BasicWeapon(false), PathToFollow, 400, 0);
        }
    }
}
