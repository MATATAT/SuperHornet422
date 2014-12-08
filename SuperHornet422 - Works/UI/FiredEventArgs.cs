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
using SuperHornet422.Weapon;

namespace SuperHornet422.UI
{
    public class FiredEventArgs : EventArgs
    {
        public readonly IList<Bullet> Bullets;

        public FiredEventArgs(IList<Bullet> bullets)
        {
            this.Bullets = bullets;
        }
    }
}
