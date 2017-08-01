﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShortcutCarousel.UI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			MainWindow mainWindow = new MainWindow();
			mainWindow.DataContext = new MainWindowVM(new ShortcutCarouselUIConfig());
			mainWindow.Show();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			//ShortcutCarouselServiceHelper.ServiceClient.Close();
			base.OnExit(e);
		}
	}
}