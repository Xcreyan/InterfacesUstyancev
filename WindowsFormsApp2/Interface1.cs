using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    interface IItems
    {
        void message();
        int numberDoctors { get; set; }
        int numberPriems { get; set; }
    }
}
