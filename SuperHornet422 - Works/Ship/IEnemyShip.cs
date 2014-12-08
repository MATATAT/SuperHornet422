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

namespace SuperHornet422.Ship
{
    public enum ShipType
    {
        basicLevel1,
        strongLevel2,
        fastLevel3,
        strongLevel4,
        basicLevel5
    }

    public interface IEnemyShip : IShip
    {
        event EventHandler RemoveShip;

        IList<LocationAndTime> PathToFollow
        {
            get;
            set;
        }


        double Velocity
        {
            get;
            set;
        }

        double Acceleration
        {
            get;
            set;
        }

        double FireRate
        {
            set;
            get;
        }

        bool IsDead
        {
            get;
            set;
        }

        ShipFunctions ShipFunctionsReference
        {
            get;
            set;
        }

        int updateShip(TimeSpan amountOfTimeElapsed, int random);
    

    }
}
