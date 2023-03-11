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

namespace WPF路由事件
{
    /// <summary>
    /// 直接路由事件：直接从起点（通常是窗口或页面）传递到目标元素，不经过任何父元素或子元素。
    /// </summary>
    public partial class CtrlDirectRouting : UserControl
    {
        public CtrlDirectRouting()
        {
            InitializeComponent();
        }

        // Button的Click事件本身是冒泡路由事件，但由于父控件没有设置对应的事件处理，那么它就会成为一个直接路由事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Application.Current.MainWindow, $"控件：'{(sender as FrameworkElement).GetType()}'", "提示");
        }
    }
}
