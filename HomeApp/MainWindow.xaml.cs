using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Tile1_Click(object sender, RoutedEventArgs e)
        {
            PaintWindow window = new PaintWindow();
            window.Show();
        }

        private void App_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

    }
}
