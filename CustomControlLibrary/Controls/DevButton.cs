using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            MessageBox.Show(DevName, "提示");
        }

        #region 依赖属性
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


        // 给button添加命令依赖属性
        public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(DevButton), new PropertyMetadata(null, OnCommandChanged));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DevButton control = d as DevButton;
            ICommand oldCommand = e.OldValue as ICommand;
            ICommand newCommand = e.NewValue as ICommand;

            if (oldCommand != null)
            {
                oldCommand.CanExecuteChanged -= control.OnCanExecuteChanged;
            }

            if (newCommand != null)
            {
                newCommand.CanExecuteChanged += control.OnCanExecuteChanged;
            }
        }

        private void OnCanExecuteChanged(object sender, EventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }
        #endregion
    }
}
