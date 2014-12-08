using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace SuperHornet422
{
	public partial class background : UserControl
	{
		private static Random randomMain = new Random();
		private static double speed = 2.0;
		private static double bossSpeed = 1.0;
		private double xPos;
		private double yPos;
 
		public background()
		{
			// Required to initialize variables
			InitializeComponent();
 
			this.Loaded += new RoutedEventHandler(bgLoaded);
		}
 
		void bgLoaded(object sender, RoutedEventArgs e)
		{
			xPos = Canvas.GetLeft(this);
			yPos = Canvas.GetTop(this);
 
			if (DesignerProperties.GetIsInDesignMode(this) == false)
			{
				CompositionTarget.Rendering += new EventHandler(moveBG);
			}
		}
 
		void moveBG(object sender, EventArgs e)
		{
			
			if (Canvas.GetTop(this) <= -5000) // Do not push the map off the screen.
			{
				Canvas.SetTop(this, yPos + speed);
				yPos = Canvas.GetTop(this);
			}
			else if (Canvas.GetTop(this) <= 0)
			{
				Canvas.SetTop(this, yPos+bossSpeed);
				yPos = Canvas.GetTop(this);
			}
		}
	}
}