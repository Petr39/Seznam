namespace Seznam
{

    //Pomocná třída k rozběhu aplikace
    internal class Aplikace
    {
        Skola skola = new Skola();
        //Start aplikace
        public void Run()
        {
            bool konec = true;
            do
            {
            VypsatMenu();
                int volba;
                string a = Console.ReadLine();
                while (!int.TryParse(a, out volba))
                {
                    Console.WriteLine("Zadej prosím číslo");
                    a = Console.ReadLine();
                }
                switch (volba) 
                   {
                       case 1:
                               PridejOsobu();
                           break;
                       case 2:
                               VypsatOsoby();
                           break; 
                       case 3:
                               SmazatOsobu();
                               break;
                           case 4:
                           konec= false;
                               break;
                       default:
                           Console.WriteLine("Neplatná volba");
                           break;
                   }
            } while (konec);
            Console.WriteLine("Děkujeme za použití aplikace");

        }
        //Hlavní nabídka menu
        private void VypsatMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("          HLAVNÍ NABÍDKA");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t1 - Přidat osobu");
            Console.WriteLine("\t2 - Vypsat osoby");
            Console.WriteLine("\t3 - Smazat osobu");
            Console.WriteLine("\t4 - Ukončit apliakci");
            Console.WriteLine();
            Console.ResetColor();
        }
        //Přidání osoby 
        private void PridejOsobu()
        {
            Console.Clear();
            int volba;           
            Console.WriteLine("1 - Přidat zaměstnance");
            Console.WriteLine("2 - Přidat studenta");
            volba = int.Parse(Console.ReadLine());
                if (volba == 1)
                {
                    Console.Clear();
                    skola.PridejZamestnanceDoSkoly();
                }
                else if (volba == 2)
                {
                    Console.Clear();
                    skola.PridejStudentaDoSkoly();
                }
                else
                    Console.WriteLine("Taková volba neexistuje");
            Console.ReadLine();
        }
        //Vypsání osoby
        private void VypsatOsoby()
        {
            Console.Clear();
            int volba;
            Console.WriteLine("1 - Vypsat zaměstnance");
            Console.WriteLine("2 - Vypsat studenta");
            volba = int.Parse(Console.ReadLine());
              if (volba == 1)
                  skola.VypisOsobu();
              else if (volba == 2)
                  skola.VypisStudenty();
              else
                Console.WriteLine("Taková volba neexistuje");
            Console.ReadLine();
            Console.ReadLine();
        }   
        //Smazání osob z databaze funkce - zatím předpis, nic to nedělá
        private void SmazatOsobu()
        {
            Console.WriteLine("Vyberte osobu ke smazání");
            Console.WriteLine("1 - Smazat zaměstnance");
            Console.WriteLine("2 - Smazat studenta");
            Console.ReadLine();
            skola.SmazZamestnance();
        }
    }
}
