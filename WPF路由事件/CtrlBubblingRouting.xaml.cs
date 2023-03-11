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
    /// 冒泡路由事件：从起点到目标元素的传递路径是从下到上（子元素到父元素）的，事件会先由起点沿着这个路径向上传递，直到到达目标元素为止。
    /// </summary>
    public partial class CtrlBubblingRouting : UserControl
    {
        public CtrlBubblingRouting()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 获取事件的起点和当前位置
            var originalSource = e.OriginalSource as FrameworkElement;
            var source = e.Source as FrameworkElement;

            MessageBox.Show(Application.Current.MainWindow, $"当前触发控件：'{(sender as FrameworkElement).GetType()}'", "提示");
        }
    }
}
