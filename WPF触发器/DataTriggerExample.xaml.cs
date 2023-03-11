using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPF触发器
{
    /// <summary>
    /// DataTriggerExample.xaml 的交互逻辑
    /// </summary>
    public partial class DataTriggerExample : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private bool _isSel;

        public bool IsSelected
        {
            get { return _isSel; }
            set { _isSel = value; OnPropertyChanged(nameof(IsSelected)); }
        }


        public DataTriggerExample()
        {
            InitializeComponent();

            this.DataContext = this;
        }
    }
}
