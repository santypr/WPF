using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFSamples.DataGridContextMenu.Models;

namespace WPFSamples.DataGridContextMenu.ViewModels
{
    public class FakeViewModel : INotifyPropertyChanged
    {
        public List<MyGridModel> MyGridModelCollection
        {
            get; set;
        }


        private DelegateCommand<object> myCommand;
        public ICommand MyCommand => myCommand;


        public FakeViewModel()
        {
            MyGridModelCollection = InitializeCollection();

            this.myCommand = new DelegateCommand<object>(MyCommandMethod);
        }

        private void MyCommandMethod(object parameter)
        {
            var myModel = parameter as MyGridModel;
            MessageBox.Show("You selected a command");
        }

        private List<MyGridModel> InitializeCollection()
        {
            var collection = new List<MyGridModel> {
                new MyGridModel { Title="Item #1", Desc="Desc for item #1 ", Created=System.DateTime.Now },
                new MyGridModel { Title="Item #2", Desc="Desc for item #2 ", Created=System.DateTime.Now },
                new MyGridModel { Title="Item #3", Desc="Desc for item #3 ", Created=System.DateTime.Now },
                new MyGridModel { Title="Item #4", Desc="Desc for item #4 ", Created=System.DateTime.Now },
                new MyGridModel { Title="Item #5", Desc="Desc for item #5 ", Created=System.DateTime.Now },
            };
            return collection;
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var Handler = PropertyChanged;
            Handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
