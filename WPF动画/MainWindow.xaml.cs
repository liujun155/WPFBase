using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF动画
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();
            ShowWindow($"{content}Example");
        }

        /// <summary>
        /// 反射查找窗体并弹出
        /// </summary>
        /// <param name="name">窗体的类名</param>
        private void ShowWindow(string name)
        {
            if (string.IsNullOrEmpty(name)) return;
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type t = assembly.GetType($"{assembly.GetName().Name}.{name}", true);
            if (t == null || !typeof(Window).IsAssignableFrom(t)) return;
            Window w = Activator.CreateInstance(t) as Window;
            w.Owner = this;
            w.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            w.ShowDialog();
        }
    }
}
