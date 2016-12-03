using System;
using System.Windows;
using Demo.ViewModel;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.ViewModel = new MainViewModel();
            this.InitializeComponent();
        }

        public MainViewModel ViewModel { get; }
    }
}
