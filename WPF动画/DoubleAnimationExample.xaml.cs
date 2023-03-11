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
using System.Windows.Shapes;

namespace WPF动画
{
    /// <summary>
    /// DoubleAnimationExample.xaml 的交互逻辑
    /// </summary>
    public partial class DoubleAnimationExample : Window
    {
        public DoubleAnimationExample()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //DoubleAnimation anmX = new DoubleAnimation();
            //DoubleAnimation anmY = new DoubleAnimation();
            //anmX.From = 30;
            //anmY.From = 30;
            //Random r = new Random();
            //anmX.To = r.NextDouble() * 300;
            //anmY.To = r.NextDouble() * 300;
            //anmX.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            //anmY.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            //tt.BeginAnimation(TranslateTransform.XProperty, anmX);
            //tt.BeginAnimation(TranslateTransform.YProperty, anmY);

            //DoubleAnimation anmW = new DoubleAnimation();
            //anmW.From = 60;
            //anmW.To = 200;
            //anmW.Duration = new Duration(TimeSpan.FromSeconds(2));
            //anmW.RepeatBehavior = RepeatBehavior.Forever;
            //(sender as FrameworkElement).BeginAnimation(Button.WidthProperty, anmW);
        }
    }
}
