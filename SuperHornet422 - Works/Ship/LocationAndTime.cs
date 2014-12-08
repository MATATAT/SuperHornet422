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

namespace SuperHornet422.Ship
{
    public class LocationAndTime
    {
        private TimeSpan time;

        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }
        private Point point;

        public Point Point
        {
            get { return point; }
            set { point = value; }
        }

        public LocationAndTime(TimeSpan time, Point point)
        {
            this.time = time;
            this.point = point;
        }

        public LocationAndTime(int seconds, Point point)
        {
            this.time = new TimeSpan(0,0,seconds);
            this.point = point;
        }
    }
}
