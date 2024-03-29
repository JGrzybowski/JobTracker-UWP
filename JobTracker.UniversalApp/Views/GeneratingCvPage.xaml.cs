﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using JobTracker.UniversalApp.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JobTracker.UniversalApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GeneratingCvPage : Page
    {
        public GeneratingCvPage()
        {
            this.InitializeComponent();
        }

        // strongly-typed view models enable x:bind
        public GeneratingCvPageViewModel ViewModel => DataContext as GeneratingCvPageViewModel;

        private async void GenerateDocXButton_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GenerateDocx();
        }
    }
}
