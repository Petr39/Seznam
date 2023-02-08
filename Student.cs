using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seznam
{
    internal class Student : Clovek
    {

        public  List<string> _predmety;
      

        public Student(string jmeno, DateTime datumNarozeni):base(jmeno,datumNarozeni)  
        {
            _predmety= new List<string>();
            
        }


    }
}
