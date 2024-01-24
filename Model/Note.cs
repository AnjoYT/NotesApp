using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace NotesApp.Model
{
    [XmlRoot("Note")]
    public class Note 
    {
       private string? _title;
        private string? _description;

        public string? Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string? Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public Note()
        {

        }
        public Note(string? title,string? description)
        {
            _title = title;
            _description = description;
        }

    }
}
