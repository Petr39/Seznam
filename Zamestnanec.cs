namespace Seznam
{
    internal sealed class Zamestnanec : Clovek
    {

        List<Predmety> predmet = new List<Predmety>();
        private string Telefon { get; set; }
        private string Adresa { get; set; }
        private string Zarazeni { get; set; }
        private string Mzda { get; set; }

        private int pocetHodin;

        public Zamestnanec(string jmeno, string mzda, DateTime datumNarozeni) : base(jmeno, datumNarozeni)
        {
            Mzda = mzda;
        }




        public void PridejData()
        {
            Console.WriteLine("Zadej telefon:");
            string telefon = Console.ReadLine();
            Console.WriteLine("Zadej adresu:");
            string adresa = Console.ReadLine();
            Console.WriteLine("Zadej pozici:");
            string pozice = Console.ReadLine();
            Telefon = telefon;
            Adresa = adresa;
            Zarazeni = pozice;
        }


        //Tohle smažu brzo - je to jen pomocné
        //public void VypisOsobniData()
        //{
        //    Console.WriteLine("Jméno:               " + Jmeno);
        //    Console.WriteLine("Věk:                 " + ZjistiVek() + " let");
        //    Console.WriteLine("Telefonní číslo:     " + Telefon);
        //    Console.WriteLine("Adresa bydliště:     " + Adresa);
        //    Console.WriteLine("Pracovní zařazení:   " + Zarazeni);
        //    Console.WriteLine("Datum narození:      " + DatumNarozeni.ToString("dd.MM.yyyy"));
        //    Console.Write("Vyučující předměty:      ");
        //    VypisPredmety();
        //    Console.WriteLine("\nMěsíční mzda :  {0} za měsíc", Mzda);
        //    Console.WriteLine("\nOdpracováno hodin celkem: {0}", pocetHodin);
        //}

        public string[] Data()
        {
            string[] s = {"Jméno:                         "+Jmeno,
                          "Věk:                           "+ZjistiVek(),
                          "Telefon:                       "+Telefon,
                          "Adresa:                        "+Adresa,
                          "Pozice:                        "+Zarazeni,
                          "Datum narození:                "+DatumNarozeni.ToString("d.M.yyyy"),
                          "Měsíční mzda:                  "+Mzda,
                          "Vyučující předměty:            "+VypisPredmety(),
                          "Počet odpracovaných hodin:     "+pocetHodin,
                          "------------------------------------------------------------------------"};
            return s;
        }
        //Vypsání předmětu vyučujícího
        private string VypisPredmety()
        {
            string predmety = "";
            for (int i = 0; i < predmet.Count; i++)
            {
                predmety = predmety + predmet[i] + "  ";
            }
            if (predmety == "")
                predmety = "Nevyučuje žádný předmět";
            return predmety;
        }

        //Přidání předmětu vyučujícího
        public void PridejPredmet()
        {
            string predmet = "";
            do
            {
                Console.WriteLine("Zadej předmět ve zkratce => (CJ,AJ,TV) nebo zadej exit: ");
                predmet = Console.ReadLine().ToUpper();
                if (predmet.StartsWith("CJ"))
                    this.predmet.Add(Predmety.Čeština);
                else if (predmet.StartsWith("AJ"))
                    this.predmet.Add(Predmety.Angličtina);
                else if (predmet.StartsWith("TV"))
                    this.predmet.Add(Predmety.Tělocvik);
                else
                {
                    if (predmet == "EXIT")
                    {
                        break;
                    }
                    Console.WriteLine("Neexistuje takový předmět");
                }
            } while (predmet != "EXIT");

        }
        //Zaměstnanec pracuje 8 hodin
        public int Makej()
        {
            int a = 8;
            pocetHodin += a;
            return a;
        }

        public override string ToString()
        {
            return Jmeno + "  "+ Zarazeni;
        }

    }

}
