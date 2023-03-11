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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF动画
{
    /// <summary>
    /// ColorAnimationExample.xaml 的交互逻辑
    /// </summary>
    public partial class ColorAnimationExample : Window
    {
        public ColorAnimationExample()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            //ColorAnimation animation = new ColorAnimation();
            //animation.From = Colors.Red;
            //animation.To = Colors.Blue;
            //animation.Duration = new Duration(TimeSpan.FromSeconds(1));

            //Storyboard storyboard = new Storyboard();
            //storyboard.Children.Add(animation);

            //Storyboard.SetTarget(animation, myButton);
            //Storyboard.SetTargetProperty(animation, new PropertyPath("Background.Color"));

            //storyboard.Begin();
        }
    }
}
