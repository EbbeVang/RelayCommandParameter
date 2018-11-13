using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using RelayCommandParameter.Annotations;

namespace RelayCommandParameter
{
    class ViewModel : INotifyPropertyChanged
    {
        private RelayCommand<String> writeCommand;

        public ViewModel()
        {
            writeCommand = new RelayCommand<string>(s => writeDebugMessage(s) );
        }

        private void writeDebugMessage(string s)
        {
            Debug.WriteLine(s);
        }

        public RelayCommand<string> WriteCommand
        {
            get { return writeCommand; }
            set { writeCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
