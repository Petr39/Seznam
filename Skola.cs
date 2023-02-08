using System.ComponentModel.Design.Serialization;

namespace Seznam
{
    internal class Skola
    {
        List<Zamestnanec> zamestnanci;
        List<Student> studenti;
        const int PriponaId = 10001;

        //Soubor k uložení dat
        const string path = "C:\\Users\\hanak\\Desktop\\VS2022\\Seznam\\Zapisy.txt";




        public Skola()
        {
            zamestnanci = new List<Zamestnanec>();
            studenti = new List<Student>();
        }

        private void PridejZamestnance(Zamestnanec z)
        {
            zamestnanci.Add(z);
        }

        private void PridejStudenta(Student s)
        {
            studenti.Add(s);
        }
        //Přidá zaměstnance do školy
        public void PridejZamestnanceDoSkoly()
        {
            Console.WriteLine("Zadej jméno zaměstnance: ");
            string jmeno = Console.ReadLine();
            Console.WriteLine("Zadej měsíční mzdu");
            string mzda = Console.ReadLine();
            Console.WriteLine("Zadej datum narození ve formátu 19.11.1998");
            DateTime datum;
            string dat = Console.ReadLine();

            while (!DateTime.TryParse(dat, out datum))
            {
                Console.WriteLine("Zadej ve správném formátu");
                dat = Console.ReadLine();
            }
            Zamestnanec zam = new Zamestnanec(jmeno, mzda + " Kč", datum);
            PridejZamestnance(zam);
            zam.PridejData();
            zam.PridejPredmet();
            Console.WriteLine("Zaměstnanec přidán do školy");
            PridejDoSouboru(zam);
        }
        //Vypsání osob
        public void VypisOsobu()
        {
            //Tohle tu  být nemusí, jen tak vytvořená proměnná
             int a =   NajdiId();

            //Vypíše zaměstnance
          for (int i = 0; i < zamestnanci.Count; i++)
          {
                if (a == zamestnanci[i].IdOsoby())
                {
                    // Console.WriteLine(zamestnanci[a-PriponaId]);
                    string[] seznam = zamestnanci[a - PriponaId].Data();
                    for (int j = 0; j < seznam.Length; j++)
                    {
                        Console.WriteLine(seznam[j]);
                    }
                }                
          }
        }
        //Udělá pomlčky před v řádku
        private static string UdelejPomlcky()
        {
            string a = "-";
            for (int i = 0; i < 50; i++)
            {

                Console.Write(a);
            }
            return a;
        }
        //Zaměstnanec - pokyn k práci
        public void Pracuj(List<Zamestnanec> z)
        {

            z = zamestnanci;
            for (int i = 0; i < z.Count; i++)
            {
                Console.WriteLine("ID: {0}", i + 1 + " " + z[i]);
            }
            Console.WriteLine("Zadej číslo zaměstnance:");


            int cislo = int.Parse(Console.ReadLine());
            cislo -= 1;

            for (int i = 0; i < z.Count; i++)
            {
                if (cislo == i)
                {
                    Console.WriteLine(z[cislo]);
                    Console.WriteLine("Dnes odpracováno hodin: {0}", z[cislo].Makej());
                }
            }
        }
        //Přidání studenta do školy
        public void PridejStudentaDoSkoly()
        {
            Console.WriteLine("Zadej jméno studenta: ");
            string jmeno = Console.ReadLine();
            Console.WriteLine("Zadej věk studenta: ");
            string vek = Console.ReadLine();



            Console.WriteLine("Zadej datum narození ve formátu 14.10.1998");
            DateTime datum;
            string dat = Console.ReadLine();

            while (!DateTime.TryParse(dat, out datum))
            {
                Console.WriteLine("Zadej ve správném formátu");
                dat = Console.ReadLine();
            }


            Student st = new Student(jmeno, datum);
            Console.WriteLine("Zadej předměty nebo zadej  'konec' :");
            string predmet = "";
            while (!((predmet) == "konec"))
            {
                predmet = Console.ReadLine();
                st._predmety.Add(predmet);
            }

            PridejStudenta(st);
            st._predmety.Remove("konec");

            Console.WriteLine("Student přidán do školy");
        }
        //Vypsání studentů
        public void VypisStudenty()
        {
            for (int i = 0; i < studenti.Count; i++)
            {
                Console.WriteLine("ID: {0}", i + 1 + " " + studenti[i].ToString());
            }
            Console.WriteLine("Zadej číslo studenta:");
            string a = Console.ReadLine();
            int cislo;
            while (!int.TryParse(a, out cislo))
            {
                Console.WriteLine("Zadej prosím číslo");
                a = Console.ReadLine();
            }

            cislo -= 1;

            for (int i = 0; i < studenti.Count; i++)
            {
                if (cislo == i)
                {
                    Console.WriteLine(studenti[cislo]);
                }
            }
        }
        //Přidánní zadaných dat do souboru - zatím jen zaměstnanec
        public void PridejDoSouboru(Zamestnanec z)
        {
            File.ReadAllText(path);
            if (!File.Exists(path))
                File.Create(path);
            using (StreamWriter sw = File.AppendText(path))
            {
                for (int i = 0; i < z.Data().Length; i++)
                {
                    sw.WriteLine(z.Data()[i]);
                }
            }
        }
        //Zatím nepoužito, taky test kurváááááá
        private void NactiDataZTextovehoSouboru()
        {
            //Pomocí using se sám soubor uzavře
            using (StreamReader sr = File.OpenText(path))
            {
                //Musí se definovat prázdný string  
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    //Načte do konzole
                    Console.WriteLine(s);
                }
            }
        }
        //Smazání zaměstnance podle ID
        public void SmazZamestnance()
        {
            int a = NajdiId();
            List<Zamestnanec> nalezeno = NajdiZamestnance(a);
            zamestnanci.Remove(nalezeno[a-PriponaId]);
            Console.WriteLine("Zaměstnanec smazán");

            Console.ReadLine();
        }
        //Přidání zaměstnanců podle ID do nového Listu, určeného ke smazání
        private List<Zamestnanec> NajdiZamestnance(int cislo)
        {
            List<Zamestnanec> zam = new List<Zamestnanec>();
            for (int i = 0; i < zamestnanci.Count; i++)
            {
                if (cislo == zamestnanci[i].IdOsoby())
                {
                    foreach (var item in zamestnanci)
                    {
                        zam.Add(item);
                    }
                }               
            }
            return zam;
        }
        //Nalezení Id osoby - zaměstnance
       private int NajdiId()
        {
            for (int i = 0; i < zamestnanci.Count; i++)
            {
                Console.WriteLine("ID: {0}  -  {1}", zamestnanci[i].IdOsoby(), zamestnanci[i]);
            }
            Console.WriteLine("Zadej prosím ID zaměstnance");
            string a = Console.ReadLine();
            int cislo;
            while (!int.TryParse(a, out cislo))
            {
                Console.WriteLine("Zadej prosím číslo");
                a = Console.ReadLine();
            }
            return cislo;
        }

    }
}
