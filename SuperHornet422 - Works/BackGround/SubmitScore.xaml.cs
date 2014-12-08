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

namespace SuperHornet422.BackGround
{
    public partial class SubmitScore : PhoneApplicationPage
    {
        public event EventHandler ScoreSubmitted = delegate { };

        private int score = 0;

        public SubmitScore(int score)
        {
            InitializeComponent();
            this.score = score;
            ScoreTextBlock.Text = score.ToString();
        }

        private void UserNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DatabaseLogic dl = new DatabaseLogic();
                if (!dl.AddToDatabase(UserNameTextBox.Text, score))
                {
                    dl.UpdateScore(UserNameTextBox.Text, score);
                }
                ScoreSubmitted(sender, EventArgs.Empty);
            }
        }
    }
}