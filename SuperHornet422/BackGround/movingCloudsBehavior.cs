using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Interactivity;
//using Microsoft.Expression.Interactivity.Core;

namespace SuperHornet422
{
	public class movingClouds : Behavior<Canvas>
	{
		
		private static Random randomNumber;
		
		public movingClouds()
		{
			// Insert code required on object creation below this point.

			//
			// The line of code below sets up the relationship between the command and the function
			// to call. Uncomment the below line and add a reference to Microsoft.Expression.Interactions
			// if you choose to use the commented out version of MyFunction and MyCommand instead of
			// creating your own implementation.
			//
			// The documentation will provide you with an example of a simple command implementation
			// you can use instead of using ActionCommand and referencing the Interactions assembly.
			//
			//this.MyCommand = new ActionCommand(this.MyFunction);
		}

		protected override void OnAttached()
		{
			base.OnAttached();
			
			randomNumber = new Random();
			
			this.AssociatedObject.Loaded += new RoutedEventHandler(ApplicationLoaded);

			// Insert code that you would want run when the Behavior is attached to an object.
		}
		
		void ApplicationLoaded(object sender, RoutedEventArgs e)
		{
			foreach (FrameworkElement element in this.AssociatedObject.Children)
			{
				FrameworkElement localCopy = element;
				
				double yPosition = Canvas.GetTop(localCopy);
				double xPosition = Canvas.GetLeft(localCopy);
                double opacity;
				
				double speed = 10 + randomNumber.Next(-2, 2);
				double counter = 0;
				//double radius = 30 * speed * randomNumber.NextDouble();
				
				CompositionTarget.Rendering += delegate(object o, EventArgs args)
				{
					counter += Math.PI / (180 * speed);
					
					if (yPosition < Application.Current.RootVisual.DesiredSize.Height + 700)
					{
						yPosition += .2 + speed;
					}
					else
					{
                        RotateTransform myR = new RotateTransform();
                        myR.Angle = randomNumber.Next(0, 359);
                        localCopy.RenderTransform = myR;
                        localCopy.Opacity = randomNumber.NextDouble();

						yPosition = -localCopy.Height - 50;
						xPosition = randomNumber.Next(0, Convert.ToInt32(localCopy.Width));
					}
					
					Canvas.SetTop(localCopy, yPosition);
					//Canvas.SetLeft(localCopy, xPosition + radius * Math.Cos(counter));
				};
			}
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();

			// Insert code that you would want run when the Behavior is removed from an object.
		}

		/*
		public ICommand MyCommand
		{
			get;
			private set;
		}
		 
		private void MyFunction()
		{
			// Insert code that defines what the behavior will do when invoked.
		}
		*/
	}
}