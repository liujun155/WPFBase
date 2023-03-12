using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF复习;

namespace WPF复习
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private int _clickCount = 0;

		public int ClickCount
		{
			get { return _clickCount; }
			set { _clickCount = value; OnPropertyChanged(nameof(ClickCount)); }
		}

		private ICommand _myCommand;

		public ICommand MyCommand
		{
			get
			{
				if (_myCommand == null)
				{
					_myCommand = new RelayCommand(BtnClick);
				}
				return _myCommand;
			}
		}

		private ICommand _ctrlCommand;

		public ICommand CtrlCommand
        {
			get
            {
                if (_ctrlCommand == null)
                {
                    _ctrlCommand = new RelayCommand(CusCtrlClick);
                }
                return _ctrlCommand;
            }
		}

		private ICommand _showBigDataGridCommand;

		public ICommand ShowBigDataGridCommand
        {
			get 
			{
				if (_showBigDataGridCommand == null)
                    _showBigDataGridCommand = new RelayCommand(ShowBigDataGrid);
				return _showBigDataGridCommand;
			}
		}

        private void ShowBigDataGrid(object obj)
        {
			BigDataGridView bigDataGridView = new BigDataGridView();
			bigDataGridView.ShowDialog();
        }

        private void CusCtrlClick(object obj)
        {
			MessageBox.Show("我通过命令执行", "提示");
        }

        public MainViewModel()
		{

        }

        private void BtnClick(object obj)
        {
			this.ClickCount++;
        }

    }
}
