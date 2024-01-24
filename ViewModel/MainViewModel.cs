using Microsoft.Win32;
using NotesApp.Commands;
using NotesApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace NotesApp.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private Note Note { get; set; } = new Note();
        public event PropertyChangedEventHandler? PropertyChanged;
        public string? Title
        {
            get { return Note.Title; }
            set
            {
                if (Note.Title == value) { return; }
                if (!string.IsNullOrEmpty(value) && value.Length <= 255) {
                    errors[nameof(Title)] = "Title should be shorter than 255";
                    OnPropertyChanged(nameof(Title));
                }
                Note.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string? Description {
            get { return Note.Description; }
            set
            {
                if (Note.Description == value) { return; }
                Note.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public ICommand SaveCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand FindCommand { get; }

        public string Error => string.Empty;

        Dictionary<string, string> errors = new Dictionary<string, string>();
        public string this[string columnName]{
        get { return errors.TryGetValue(columnName,out string e) ? e : null; }
        }

        public MainViewModel()
        {
            SaveCommand = new RelayCommands(Save);
            OpenCommand = new RelayCommands(Open);
            FindCommand = new RelayCommands(Find);
        }

        public void Save()
        {
            Note note = new Note();
            note.Title = Title;
            note.Description = Description;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = note.Title;
            saveFileDialog.DefaultExt = ".bc";
            saveFileDialog.Filter = "Bc documents (.bc)|*.bc";
            XmlSerializer oSerializer = new XmlSerializer(typeof(Note));
            if (saveFileDialog.ShowDialog() == true)
            {
                Stream oStream = new FileStream(Path.GetFullPath(saveFileDialog.FileName), FileMode.Create);
                oSerializer.Serialize(oStream, note);
                oStream.Close();
            }

        }
        public void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "Document";
            openFileDialog.DefaultExt = ".bc";
            openFileDialog.Filter = "Bc documents (.bc)|*.bc";
            XmlSerializer oSerializer = new XmlSerializer(typeof(Note));
            if (openFileDialog.ShowDialog() == true)
            {
                //Stream oStream = openFileDialog.OpenFile();
                Stream oStream = new FileStream(Path.GetFullPath(openFileDialog.FileName), FileMode.Open);
                Note deserializedNote = (Note)oSerializer.Deserialize(oStream);
                Description = deserializedNote.Description;
                Title = deserializedNote.Title;
                oStream.Close();
            }
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
