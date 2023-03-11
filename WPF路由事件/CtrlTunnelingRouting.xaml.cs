using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// 隧道路由事件：从起点到目标元素的传递路径是从上到下（父元素到子元素）的，事件会先由起点沿着这个路径向下传递，直到到达目标元素为止。
    /// 通常情况下，隧道事件的名称以 "Preview" 开头，例如 PreviewMouseLeftButtonDown，PreviewKeyDown 等。
    /// </summary>
    public partial class CtrlTunnelingRouting : UserControl
    {
        public CtrlTunnelingRouting()
        {
            InitializeComponent();
        }

        private void StackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("当前控件：StackPanel PreviewMouseLeftButtonDown");
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("当前控件：Button PreviewMouseLeftButtonDown");
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("当前控件：Grid PreviewMouseLeftButtonDown");
        }

        private void Rectangle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("当前控件：Rectangle PreviewMouseLeftButtonDown");
        }

    }
}
