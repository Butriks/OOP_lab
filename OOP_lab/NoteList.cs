using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab
{
    internal class NoteList
    {
        public List<Note> notelist= new List<Note>();
        public void addNote(Note note)
        {
            notelist.Add(note);
        }

        public void removeNote(Note note)
        {
            if (notelist.Contains(note))
            {
                notelist.Remove(note);

            }
            else
            {

            }
        }

        
    }
}
