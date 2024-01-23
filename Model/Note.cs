using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotesApp.Model
{
    internal class Note : ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("title", _title);
            info.AddValue("description", _description);
        }
    }
}
