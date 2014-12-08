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

using SuperHornet422.Ship;

namespace SuperHornet422
{
    public class GameCode
    {
        public event EventHandler GameComplete = delegate { };

        private PlayerShip playerShip;
        private Canvas gameCanvas;
        private Level currentLevel;
        private TextBlock scoreTextBox;

        public int Score
        {
            get { return currentLevel.Score; }
        }


        public GameCode(PlayerShip playerShip, Canvas gameCanvas, TextBlock scoreTextBox)
        {
            this.scoreTextBox = scoreTextBox;
            this.gameCanvas = gameCanvas;
            this.playerShip = playerShip;
        }

        public void startGame()
        {
            Level firstLevel = new Level(gameCanvas, playerShip, scoreTextBox);
            currentLevel = firstLevel;
            firstLevel.GameOver += new EventHandler(GameOver);
            firstLevel.startLevel();

        }

        void GameOver(object sender, EventArgs e)
        {
            GameComplete(this, EventArgs.Empty);
        }

        public void PauseGame()
        {
            currentLevel.PauseGame();
        }

        public void ResumeGame()
        {
            currentLevel.PauseGame();
        }

        public void SaveState()
        {

        }

    }
}
