using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;



namespace OOP_lab
{
    internal class Task
    {
        public DateTime dateOfReg;
        public DateTime dateOfEnd;
        public string title;
        public string description;
        public int priority;
        public string category;
        public Task(DateTime dateOfR, DateTime dateOfE, string tit, string dsc, int pri, string cat)
        {
            dateOfReg = dateOfR;
            dateOfEnd = dateOfE;
            title = tit;
            description = dsc;
            priority = pri;
            category = cat;
        }
    }
}
