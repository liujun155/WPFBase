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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF模板
{
    /// <summary>
    /// DataTemplateExample.xaml 的交互逻辑
    /// </summary>
    public partial class DataTemplateExample : UserControl
    {
        private List<Person> _persons;

        public List<Person> PersonList
        {
            get { return _persons; }
            set { _persons = value; }
        }

        private List<TreeData> _treeList;

        public List<TreeData> TreeList
        {
            get { return _treeList; }
            set { _treeList = value; }
        }



        public DataTemplateExample()
        {
            InitializeComponent();

            PersonList = new List<Person>()
            {
                new Person{Name="张三",Age=18},
                new Person{Name="李四",Age=19},
                new Person{Name="王五",Age=20},
                new Person{Name="赵六",Age=21},
                new Person{Name="小七",Age=22},
                new Person{Name="小八",Age=23},
            };

            TreeList = new List<TreeData>()
            {
                new TreeData
                {
                    Name="节点1", Children = new List<TreeData>()
                    {
                        new TreeData{ Name="子节点1", Children = null}
                    }
                },
                new TreeData
                {
                    Name="节点2", Children = new List<TreeData>()
                    {
                        new TreeData{ Name="子节点1", Children = null}
                    }
                },
                new TreeData
                {
                    Name="节点3", Children = new List<TreeData>()
                    {
                        new TreeData{ Name="子节点1", Children = null}
                    }
                }
            };

            this.DataContext = this;
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class TreeData
    {
        public string Name { get; set; }

        public List<TreeData> Children { get; set; }
    }
}
