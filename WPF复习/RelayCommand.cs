using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF复习
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute; // 命令执行方法
        private readonly Predicate<object> _canExecute; // 命令是否可以执行的方法
        private Action btnClick;  // 按钮点击的方法

        /// <summary>
        /// 构造函数，传入命令执行方法和是否可以执行命令的方法
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public RelayCommand(Action btnClick)
        {
            this.btnClick = btnClick;
        }

        /// <summary>
        /// ICommand 接口的方法，用于判断命令是否可以执行
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// ICommand 接口的方法，用于执行命令
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (btnClick != null)
            {
                btnClick(); // 如果设置了按钮点击的方法，则先执行按钮点击的方法
            }

            _execute(parameter); // 调用命令执行的方法
        }

        /// <summary>
        /// ICommand 接口的事件，当命令是否可以执行的状态发生变化时触发
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value; // 添加事件处理方法
            remove => CommandManager.RequerySuggested -= value; // 移除事件处理方法
        }
    }

}
