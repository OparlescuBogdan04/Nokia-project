﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Nokia
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow((DependencyObject)sender).SwitchTo(new MainWindow());
        }
    }
}
