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
    internal class MainViewModel
    { 
        public ICommand SaveCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand FindCommand { get; set; }
        public MainViewModel()
        {
            SaveCommand = new RelayCommands(Save);
            OpenCommand = new RelayCommands(Open);
            LoadCommand = new RelayCommands(Load);
            NewCommand = new RelayCommands(New);
            FindCommand = new RelayCommands(Find);
        }

        public void Save() 
        {
            MessageBox.Show("Save");
        }
        public void Open()
        {
            MessageBox.Show("Open");
        }
        public void Load()
        {
            MessageBox.Show("Load");
        }
        public void New()
        {
            MessageBox.Show("New");
        }
        public void Find()
        {
            MessageBox.Show("Find");
        }



    }
}
