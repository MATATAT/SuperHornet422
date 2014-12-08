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
using System.Collections.Generic;

using SuperHornet422.Weapon;

namespace SuperHornet422.Ship
{
    public class EnemyShipWaveFactory
    {
        public static List<EnemyShip> CreateEnemyWave(Point Location, Path PathToFollow, int NumberOfShips, ShipType shipType)
        {
            int i = 0;
            List<EnemyShip> ships = new List<EnemyShip>();
            int flyingIn = 0;

            
            if (Location.Y == 0)
            {
                //flying in from Top
               flyingIn = 0; 
            }
            else if(Location.Y == 768)
            {
                //flying in from Bottem
                flyingIn = 1;
            }
            else if(Location.X == 0)
            {
                //flying in from Left
                flyingIn = 2;
            }
            else if(Location.X == 480)
            {
                //flying in from Right
                flyingIn = 0;  
            }
            //function pointer would be super awesome right here
            if (shipType == ShipType.basicLevel1)
            {
                while (i <= NumberOfShips)
                {
                    if(flyingIn == 0)
                    {
                    Location.Y = Location.Y - 60;
                    }
                    else if(flyingIn == 1)
                    {
                        Location.Y = Location.Y + 60;
                    }
                    else if(flyingIn == 2)
                    {
                        Location.X = Location.X - 60;
                    }
                    else if(flyingIn == 3)
                    {
                        Location.X = Location.X + 60;
                    }

                    Location.X = Location.X + (i * 20) % 50;

                    ships.Add(EnemyShipFactory.CreateEnemyShipBasicLevel1(Location, PathToFollow));
                    i++;
                }
            }
            else if (shipType == ShipType.strongLevel2)
            {
                while (i <= NumberOfShips)
                {
                    if(flyingIn == 0)
                    {
                    Location.Y = Location.Y - 120;
                    }
                    else if(flyingIn == 1)
                    {
                        Location.Y = Location.Y + 120;
                    }
                    else if(flyingIn == 2)
                    {
                        Location.X = Location.X - 120;
                    }
                    else if(flyingIn == 3)
                    {
                        Location.X = Location.X + 120;
                    }

                    ships.Add(EnemyShipFactory.CreateEnemyShipStrongLevel2(Location, PathToFollow));
                    i++;
                }

            }
            else if (shipType == ShipType.fastLevel3)
            {
                while (i <= NumberOfShips)
                {
                    if(flyingIn == 0)
                    {
                    Location.Y = Location.Y - 60;
                    }
                    else if(flyingIn == 1)
                    {
                        Location.Y = Location.Y + 60;
                    }
                    else if(flyingIn == 2)
                    {
                        Location.X = Location.X - 60;
                    }
                    else if(flyingIn == 3)
                    {
                        Location.X = Location.X + 60;
                    }

                    ships.Add(EnemyShipFactory.CreateEnemyShipFastLevel3(Location, PathToFollow));
                    i++;
                }

            }
            else if (shipType == ShipType.strongLevel4)
            {
                while (i <= NumberOfShips)
                {
                    if(flyingIn == 0)
                    {
                    Location.Y = Location.Y - 30;
                    }
                    else if(flyingIn == 1)
                    {
                        Location.Y = Location.Y + 30;
                    }
                    else if(flyingIn == 2)
                    {
                        Location.X = Location.X - 30;
                    }
                    else if(flyingIn == 3)
                    {
                        Location.X = Location.X + 30;
                    }

                    ships.Add(EnemyShipFactory.CreateEnemyShipStrongLevel4(Location, PathToFollow));
                    i++;
                }

            }
            else if (shipType == ShipType.basicLevel5)
            {
                while (i <= NumberOfShips)
                {
                    if(flyingIn == 0)
                    {
                    Location.Y = Location.Y - 30;
                    }
                    else if(flyingIn == 1)
                    {
                        Location.Y = Location.Y + 30;
                    }
                    else if(flyingIn == 2)
                    {
                        Location.X = Location.X - 30;
                    }
                    else if(flyingIn == 3)
                    {
                        Location.X = Location.X + 30;
                    }

                    ships.Add(EnemyShipFactory.CreateEnemyShipBasicLevel5(Location, PathToFollow));
                    i++;
                }

            }
            return ships;
        }
    }
}