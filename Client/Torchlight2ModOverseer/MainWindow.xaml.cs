using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZeroBugBounce.Torchlight2.ModOverseer.Client
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void OnSkull_MouseEnter(object sender, MouseEventArgs e)
		{
			var fadein = new DoubleAnimation()
			{
				From = 0,
				To = 1,
				Duration = TimeSpan.FromMilliseconds(250)
			};

			Storyboard.SetTarget(fadein, OnSkull);
			Storyboard.SetTargetProperty(fadein, new PropertyPath(Image.OpacityProperty));

			var storyboard = new Storyboard();
			storyboard.Children.Add(fadein);

			storyboard.Begin();
		}

		private void OnSkull_MouseLeave(object sender, MouseEventArgs e)
		{
			var fadeout = new DoubleAnimation()
			{
				From = 1,
				To = 0,
				Duration = TimeSpan.FromMilliseconds(250)
			};

			Storyboard.SetTarget(fadeout, OnSkull);
			Storyboard.SetTargetProperty(fadeout, new PropertyPath(Image.OpacityProperty));

			var storyboard = new Storyboard();
			storyboard.Children.Add(fadeout);

			storyboard.Begin();
		}

		private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			e.Handled = false;
		}

		private void OnSkull_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			MainPanel.Content = new ModsView();
		}
	}
}
