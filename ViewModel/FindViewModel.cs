using NotesApp.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NotesApp.ViewModel
{
    internal class FindViewModel : INotifyPropertyChanged
    {
        public ICommand SearchCommand { get; set; }
        
        public ICommand CancelCommand { get; set; }
        
        private string _FraseToFind;
       
        Window _window;

        public string FraseToFind { 
            get { 
                return _FraseToFind; 
            } 
            set { 
                _FraseToFind = value; 
                OnPropertyChanged(nameof(FraseToFind));
            } 
        }
        public FindViewModel(Window window)
        {
            _window = window;
            //SearchCommand = new RelayCommands(Find);
            CancelCommand = new RelayCommands(Cancel);
        }

        public void Find()
        {

        }

        public void Cancel()
        {
            _window.Close();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
