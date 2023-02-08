using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seznam
{
    abstract class Clovek
    {
        protected string Jmeno { get; set; }
        protected double Vek;
        protected DateTime DatumNarozeni { get; set; }
        private static int Id=10000;
        private int _Id;


        protected Clovek(string jmeno, DateTime datumNarozeni)
        {
            Jmeno = jmeno;
            Vek = ZjistiVek();
            DatumNarozeni = datumNarozeni;
            Id++;
            _Id = Id;

        }

       public int IdOsoby()
        {
            return _Id;
        }
        
        //Přepočet věku podle data narození
        protected double ZjistiVek()
        {
            TimeSpan pocetLet = DateTime.Today - DatumNarozeni;
            Vek = Math.Floor(pocetLet.Days/365.255);
            return Vek;
        }

        public enum Predmety { Čeština , Angličtina , Matematika , Tělocvik }
    }
}
