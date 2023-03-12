using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF复习
{
    public class BigDataGridViewModel : INotifyPropertyChanged
    {
        //取消异步操作
        private CancellationTokenSource _cancellationTokenSource;

        #region 属性通知事件
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        private ObservableCollection<DataEnt> _dataList;
        /// <summary>
        /// DataGrid数据源
        /// </summary>
        public ObservableCollection<DataEnt> DataList
        {
            get { return _dataList; }
            set { _dataList = value; OnPropertyChanged(nameof(DataList)); }
        }

        private ICommand _btnClickCommand;
        /// <summary>
        /// 加载数据按钮命令
        /// </summary>
        public ICommand BtnClickCommand
        {
            get
            {
                if (_btnClickCommand == null)
                    _btnClickCommand = new RelayCommand(BtnClick);
                return _btnClickCommand;
            }
        }

        private ICommand _cancelClickCommand;
        /// <summary>
        /// 取消加载数据按钮命令
        /// </summary>
        public ICommand CancelClickCommand
        {
            get
            {
                if (_cancelClickCommand == null)
                    _cancelClickCommand = new RelayCommand(CancelClick);
                return _cancelClickCommand;
            }
        }

        private ICommand _closeCommand;
        /// <summary>
        /// 关闭窗体命令
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(CloseWindow);
                return _closeCommand;
            }
        }

        private List<DataEnt> _exampleData = new List<DataEnt>();

        public BigDataGridViewModel()
        {
            DataList = new ObservableCollection<DataEnt>();
            Random sexRandom = new Random(0);
            Random ageRandom = new Random(18);
            for (int i = 0; i < 100000; i++)
            {
                _exampleData.Add(new DataEnt
                {
                    Name = $"名称{i}",
                    Sex = sexRandom.Next(1),
                    Age = ageRandom.Next(50),
                    Phone = $"{i}"
                });
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="obj"></param>
        private async void BtnClick(object obj)
        {
            // 创建 CancellationTokenSource，并保存到字段中
            _cancellationTokenSource = new CancellationTokenSource();
            DataList = new ObservableCollection<DataEnt>();
            await GetDataListAsync(_cancellationTokenSource.Token);
        }

        /// <summary>
        /// 异步获取数据列表（可取消）
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task GetDataListAsync(CancellationToken token)
        {
            await Task.Run(async () =>
            {
                foreach (var item in _exampleData)
                {
                    // 检查取消标记
                    if (token.IsCancellationRequested) break;
                    // 模拟耗时操作
                    await Task.Delay(1000);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        DataList.Add(item);
                    });
                }
            }, token);
        }

        /// <summary>
        /// 取消加载数据
        /// </summary>
        /// <param name="obj"></param>
        private void CancelClick(object obj)
        {
            if (_cancellationTokenSource != null)
                _cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="obj"></param>
        private void CloseWindow(object obj)
        {
            if (_cancellationTokenSource != null)
                _cancellationTokenSource.Cancel();
        }

    }

    public class DataEnt
    {
        public string Name { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }
}
