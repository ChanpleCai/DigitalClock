﻿using System.Windows;
using System.Windows.Interop;

namespace DigitalClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Left = (SystemParameters.PrimaryScreenWidth - Width) * 3 / 4;
            Top = 0;
            DataContext = new TimeModel();
        }
    }
}
