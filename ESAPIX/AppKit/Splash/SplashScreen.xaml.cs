﻿#region

using System;
using System.Windows;
using System.Windows.Media.Animation;

#endregion

namespace ESAPIX.AppKit.Splash
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        private readonly Storyboard Showboard;

        public SplashScreen(string softLabel = "")
        {
            InitializeComponent();
            SoftLabel.Text = softLabel;
            Showboard = Resources["Storyboard1"] as Storyboard;
        }

        public void Animate()
        {
            BeginStoryboard(Showboard);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Showboard.Completed += Showboard_Completed;
            BeginStoryboard(Showboard);
        }

        private void Showboard_Completed(object sender, EventArgs e)
        {
            Close();
        }

        private delegate void ShowDelegate();
    }
}