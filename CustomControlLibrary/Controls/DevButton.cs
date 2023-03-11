using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CustomControlLibrary
{
    public class DevButton : Control
    {
        public DevButton()
        {
            SetCurrentValue(WidthProperty, 100d);
            SetCurrentValue(HeightProperty, 25d);
            SetCurrentValue(BackgroundProperty, Brushes.Yellow);
        }
        static DevButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DevButton), new FrameworkPropertyMetadata(typeof(DevButton)));
        }
        private Rectangle statusLed;
        private Button devBtn;
        public override void OnApplyTemplate()
        {
            statusLed = GetTemplateChild("statusLed") as Rectangle;
            devBtn = GetTemplateChild("devBtn") as Button;
            devBtn.Click += DevBtn_Click;
            base.OnApplyTemplate();
        }

        private void DevBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DevName);
        }

        public string DevName
        {
            get { return (string)GetValue(DevNameProperty); }
            set { SetValue(DevNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DevName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DevNameProperty =
            DependencyProperty.Register("DevName", typeof(string), typeof(DevButton), new PropertyMetadata("", new PropertyChangedCallback(OnDevNameChanged)));

        private static void OnDevNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DevButton btn = d as DevButton;
            btn.DevName = e.NewValue.ToString();
        }


        public int DevStatus
        {
            get { return (int)GetValue(DevStatusProperty); }
            set { SetValue(DevStatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DevStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DevStatusProperty =
            DependencyProperty.Register("DevStatus", typeof(int), typeof(DevButton), new PropertyMetadata(-1, new PropertyChangedCallback(OnDevStatusChanged)));

        private static void OnDevStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DevButton btn = d as DevButton;
            btn.DevStatus = (int)e.NewValue;
            btn.StatusBrush = (btn.DevStatus > 0) ? Brushes.Green : Brushes.LightGray;
        }


        public Brush StatusBrush
        {
            get { return (Brush)GetValue(StatusBrushProperty); }
            set { SetValue(StatusBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StatusBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusBrushProperty =
            DependencyProperty.Register("StatusBrush", typeof(Brush), typeof(DevButton), new FrameworkPropertyMetadata(Brushes.LightGray));
    }
}
