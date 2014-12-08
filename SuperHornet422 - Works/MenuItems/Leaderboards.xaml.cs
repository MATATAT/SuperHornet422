using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using SuperHornet422.Database;

namespace SuperHornet422.MenuItems
{
    public partial class Leaderboards : PhoneApplicationPage
    {
        public Leaderboards()
        {
            InitializeComponent();

            Dictionary<string, int> db = (new DatabaseLogic()).ReadDatabase();

            var sortedDict = (from entry in db orderby entry.Value ascending select entry);

            foreach (KeyValuePair<string, int> pair in sortedDict)
            {
                TextBlock name = new TextBlock();
                TextBlock score = new TextBlock();
                StackPanel sp = new StackPanel();
                Rectangle rec = new Rectangle();
                Border br = new Border();

                //invisable rectangle to help with spacing
                rec.Width = 10;
                rec.Fill = new SolidColorBrush(Colors.Transparent);
                name.MaxWidth = 228;
                name.MinWidth = 228;
                name.TextWrapping = TextWrapping.Wrap;
                name.Text = pair.Key;

                score.MaxWidth = 228;
                score.MinWidth = 228;
                name.Margin = new Thickness(0, 0, 0, 10);
                score.TextWrapping = TextWrapping.Wrap;
                score.TextAlignment = TextAlignment.Right;
                sp.Orientation = System.Windows.Controls.Orientation.Horizontal;
                
                score.Text = pair.Value.ToString();

                sp.Children.Add(rec);
                sp.Children.Add(name);
                sp.Children.Add(score);

                br.Child = sp;
                br.BorderThickness = new Thickness(1);
                br.BorderBrush = new SolidColorBrush(Colors.White);

                Leaders.Children.Insert(0, br);
            }


        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}