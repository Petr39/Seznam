using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Seznam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Zde je celá aplikace
            Aplikace a = new Aplikace();
            a.Run();
        }
    }
}