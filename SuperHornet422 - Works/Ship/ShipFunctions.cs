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
using System.Windows.Media.Imaging;

using System.Collections.Generic;

using SuperHornet422.UI;

namespace SuperHornet422.Ship
{
    public class ShipFunctions
    {

        //private BitmapImage deathImage0 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0000.png", UriKind.Relative));
        private BitmapImage deathImage1 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0001.png", UriKind.Relative));
        private BitmapImage deathImage2 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0002.png", UriKind.Relative));
        private BitmapImage deathImage3 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0003.png", UriKind.Relative));
        private BitmapImage deathImage4 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0004.png", UriKind.Relative));
        private BitmapImage deathImage5 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0005.png", UriKind.Relative));
        private BitmapImage deathImage6 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0006.png", UriKind.Relative));
        private BitmapImage deathImage7 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0007.png", UriKind.Relative));
        private BitmapImage deathImage8 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0008.png", UriKind.Relative));
        private BitmapImage deathImage9 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0009.png", UriKind.Relative));
        private BitmapImage deathImage10 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0010.png", UriKind.Relative));
        private BitmapImage deathImage11 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0011.png", UriKind.Relative));
        private BitmapImage deathImage12 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0012.png", UriKind.Relative));
        private BitmapImage deathImage13 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0013.png", UriKind.Relative));
        private BitmapImage deathImage14 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0014.png", UriKind.Relative));
        private BitmapImage deathImage15 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0015.png", UriKind.Relative));
        private BitmapImage deathImage16 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0016.png", UriKind.Relative));
        private BitmapImage deathImage17 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0017.png", UriKind.Relative));
        private BitmapImage deathImage18 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0018.png", UriKind.Relative));
        private BitmapImage deathImage19 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0019.png", UriKind.Relative));
        private BitmapImage deathImage20 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0020.png", UriKind.Relative));
        private BitmapImage deathImage21 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0021.png", UriKind.Relative));
        private BitmapImage deathImage22 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0022.png", UriKind.Relative));
        private BitmapImage deathImage23 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0023.png", UriKind.Relative));
        private BitmapImage deathImage24 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0024.png", UriKind.Relative));
        private BitmapImage deathImage25 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0025.png", UriKind.Relative));
        private BitmapImage deathImage26 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0026.png", UriKind.Relative));
        private BitmapImage deathImage27 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0027.png", UriKind.Relative));
        private BitmapImage deathImage28 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0028.png", UriKind.Relative));
        private BitmapImage deathImage29 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0029.png", UriKind.Relative));
        private BitmapImage deathImage30 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0030.png", UriKind.Relative));
        private BitmapImage deathImage31 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0031.png", UriKind.Relative));
        private BitmapImage deathImage32 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0032.png", UriKind.Relative));
        private BitmapImage deathImage33 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0033.png", UriKind.Relative));
        private BitmapImage deathImage34 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0034.png", UriKind.Relative));
        private BitmapImage deathImage35 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0035.png", UriKind.Relative));
        private BitmapImage deathImage36 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0036.png", UriKind.Relative));
        private BitmapImage deathImage37 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0037.png", UriKind.Relative));
        private BitmapImage deathImage38 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0038.png", UriKind.Relative));
        private BitmapImage deathImage39 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0039.png", UriKind.Relative));
        private BitmapImage deathImage40 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0040.png", UriKind.Relative));
        private BitmapImage deathImage41 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0041.png", UriKind.Relative));
        private BitmapImage deathImage42 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0042.png", UriKind.Relative));
        private BitmapImage deathImage43 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0043.png", UriKind.Relative));
        private BitmapImage deathImage44 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0044.png", UriKind.Relative));
        private BitmapImage deathImage45 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0045.png", UriKind.Relative));
        private BitmapImage deathImage46 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0046.png", UriKind.Relative));
        private BitmapImage deathImage47 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0047.png", UriKind.Relative));
        private BitmapImage deathImage48 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0048.png", UriKind.Relative));
        private BitmapImage deathImage49 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0049.png", UriKind.Relative));
        private BitmapImage deathImage50 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0050.png", UriKind.Relative));
        private BitmapImage deathImage51 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0051.png", UriKind.Relative));
        private BitmapImage deathImage52 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0052.png", UriKind.Relative));
        private BitmapImage deathImage53 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0053.png", UriKind.Relative));
        private BitmapImage deathImage54 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0054.png", UriKind.Relative));
        private BitmapImage deathImage55 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0055.png", UriKind.Relative));
        private BitmapImage deathImage56 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0056.png", UriKind.Relative));
        private BitmapImage deathImage57 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0057.png", UriKind.Relative));
        private BitmapImage deathImage58 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0058.png", UriKind.Relative));
        private BitmapImage deathImage59 = new BitmapImage(new Uri("/UI/Icons/DeathAnimation/boom-1-0059.png", UriKind.Relative));



        public ImageSource getDeathImage(int number)
        {
            switch (number)
            {
                case 1: return (deathImage1);
                case 2: return (deathImage2);
                case 3: return (deathImage3);
                case 4: return (deathImage4);
                case 5: return (deathImage5);
                case 6: return (deathImage6);
                case 7: return (deathImage7);
                case 8: return (deathImage8);
                case 9: return (deathImage9);
                case 10: return (deathImage10);
                case 11: return (deathImage11);
                case 12: return (deathImage12);
                case 13: return (deathImage13);
                case 14: return (deathImage14);
                case 15: return (deathImage15);
                case 16: return (deathImage16);
                case 17: return (deathImage17);
                case 18: return (deathImage18);
                case 19: return (deathImage19);
                case 20: return (deathImage20);
                case 21: return (deathImage21);
                case 22: return (deathImage22);
                case 23: return (deathImage23);
                case 24: return (deathImage24);
                case 25: return (deathImage25);
                case 26: return (deathImage26);
                case 27: return (deathImage27);
                case 28: return (deathImage28);
                case 29: return (deathImage29);
                case 30: return (deathImage30);
                case 31: return (deathImage31);
                case 32: return (deathImage32);
                case 33: return (deathImage33);
                case 34: return (deathImage34);
                case 35: return (deathImage35);
                case 36: return (deathImage36);
                case 37: return (deathImage37);
                case 38: return (deathImage38);
                case 39: return (deathImage39);
                case 40: return (deathImage40);
                case 41: return (deathImage41);
                case 42: return (deathImage42);
                case 43: return (deathImage43);
                case 44: return (deathImage44);
                case 45: return (deathImage45);
                case 46: return (deathImage46);
                case 47: return (deathImage47);
                case 48: return (deathImage48);
                case 49: return (deathImage49);
                case 50: return (deathImage50);
                case 51: return (deathImage51);
                case 52: return (deathImage52);
                case 53: return (deathImage53);
                case 54: return (deathImage54);
                case 55: return (deathImage55);
                case 56: return (deathImage56);
                case 57: return (deathImage57);
                case 58: return (deathImage58);
                case 59: return (deathImage59);
            }
            return deathImage10;
        }

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
