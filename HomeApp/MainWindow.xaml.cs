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
using MouseClick;
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

        private SettingForm settingForm;

        private bool bSettingOpen = false;

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        /// <summary>
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSettingForm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.settingForm != null && !this.settingForm.IsDisposed)
            {
                this.settingForm.Activate();
            }
            else
            {
                SettingForm setting = new SettingForm();
                setting.Show();
                this.settingForm = setting;
                this.bSettingOpen = true;
            }
        }

        //演示项目

        /// <summary>
        /// 隔空标注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileMarker_Click(object sender, RoutedEventArgs e)
        {
            PaintWindow window = new PaintWindow();
            window.Show();
        }

        /// <summary>
        /// 体感游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileSomatosensoryGames_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 3D查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileViwer3D_Click(object sender, RoutedEventArgs e)
        {
            Viewer3DWindow window = new Viewer3DWindow();
            window.Show();
        }

        /// <summary>
        /// 医学课堂
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileMedicalLesson_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 言之成字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileSpeakToWord_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 实施护眼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileEyesProtection_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
