using Microsoft.Win32;
using NotesApp.Commands;
using NotesApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NotesApp.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string? _title;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string? Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string? Description { get; set; }
        public ICommand SaveCommand { get;}
        public ICommand OpenCommand { get;}
        public ICommand NewCommand { get;}
        public ICommand FindCommand { get;}
        public MainViewModel()
        {
            SaveCommand = new RelayCommands(Save);
            OpenCommand = new RelayCommands(Open);
            NewCommand = new RelayCommands(New);
            FindCommand = new RelayCommands(Find);
        }

        public void Save()
        {
            Note note = new Note();
            note.Title = Title;
            note.Description = Description;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
        }
        public void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "Document";
            openFileDialog.DefaultExt = ".bc";
            openFileDialog.Filter = "Bc documents (.bc)|*.bc";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            { string fileName = openFileDialog.FileName; }
        }
        public void New()
        {

        }
        public void Find()
        {
            MessageBox.Show("Find");
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
