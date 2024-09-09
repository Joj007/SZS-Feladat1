using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(elso());

            int elso()
            {
                int hossz = args.Length;
                if (hossz%2==0) throw new Exception();

                int kozep = Convert.ToInt32(Math.Ceiling(hossz/2.0));

                int szam0 = Convert.ToInt32(args[kozep-1]);
                int szam1 = Convert.ToInt32(args[kozep]);
                int szam2 = Convert.ToInt32(args[kozep - 2]);


                if (szam1 > szam2) return Convert.ToInt32(Math.Pow(szam0, szam1 / szam2));
                else return Convert.ToInt32(Math.Pow(szam0, szam2 / szam1));
            }


            List<string> words=File.ReadAllLines("szavak.txt").ToList();
            char[] maganhangzok = ['A', 'E', 'I', 'O', 'U'];

            int db = 0;
            int maganhangzoSzamlalo;
            foreach (string word in words)
            {
                maganhangzoSzamlalo = 0;
                foreach (char letter in word) if (maganhangzok.Contains(letter)) maganhangzoSzamlalo++;
                if (maganhangzoSzamlalo>4) db++;

            }
            Console.WriteLine(db);


            List<List<int>> matrix = new();
            Random rand = new Random();
            int meret = 6;

            for (int i = 0; i < meret; i++)
            {
                List<int> sor = new();

                for (int j = 0; j < meret; j++) sor.Add(rand.Next(55,156));
                matrix.Add(sor);

            }
            Console.WriteLine("");
            foreach (var cor in matrix) {
                foreach (var item in cor) Console.Write(item+"\t");  
                Console.WriteLine("");
            }

            int sum = 0;
            int db2 = 0;
            for (int i = 0; i < meret; i++)
            {
                sum+=matrix[0][i];
                sum += matrix[meret-1][i];
                db2 += 2;
            }

            for (int i = 1; i < meret-1; i++)
            {
                sum += matrix[i][0];
                sum += matrix[i][meret-2];
                db2 += 2;
            }

            Console.WriteLine(sum/db2);

            List<int> szinek = new List<int>();
            string szoveg = "";
            foreach (string sor in File.ReadLines("kep.txt"))
            {
                string[] szamok = sor.Split(";");
                if (Convert.ToInt32(szamok[2]) < 100)
                {
                    szamok[2] = $"{Convert.ToInt32(szamok[2]) + 20}";
                }
                szoveg+= $"{szamok[0]};{szamok[1]};{szamok[2]}\n";
            }

            File.WriteAllText("kerekitett.txt", szoveg);
            Console.WriteLine("#Kész!");

        }
    }
}
