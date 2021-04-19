using System;
using System.Collections.Generic;
using System.IO;

namespace ArthurShostak3Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nam = new List<int>();
            List<int> man = new List<int>();
            List<List<int>> zge = new List<List<int>>();
            List<String> ame = new List<string>();
            List<String> sur = new List<string>();
            List<String> sta = new List<string>();
            List<Double> avg = new List<double>();
            List<Double> med = new List<double>();
            Double a, m;
            int i = 1, p, c = 0, k, l;
            String line;
            try
            {
                StreamReader sr = new StreamReader("students.txt");
                while ((line = sr.ReadLine()) != null)
                {
                    String[] rea = line.Split(' ');
                    ame.Add(rea[0]);
                    sur.Add(rea[1]);
                    for (l = 2; l < rea.Length - 1; l++)
                    {
                        man.Add(Convert.ToInt32(rea[l]));
                    }
                    zge.Add(man);
                    man.Sort();
                    nam.Add(Convert.ToInt32(rea[rea.Length - 1]));
                    foreach (int num in zge[zge.Count - 1])
                    {
                        c += num;
                    }
                    a = c / zge[zge.Count - 1].Count;
                    c = 0;
                    avg.Add(a * 0.3 + nam[nam.Count - 1] * 0.7);
                    if (man.Count % 2 == 0) m = (man[man.Count / 2] + man[man.Count / 2 + 1]) / 2;
                    else m = man[man.Count / 2 + 1];
                    med.Add(m * 0.3 + nam[nam.Count - 1] * 0.7);
                    if (avg[avg.Count - 1] < 5 || med[med.Count - 1] < 5) sta.Add("Failed");
                    else sta.Add("Passed");
                    man.Clear();
                }
            }
            catch(FileNotFoundException e)
            {

            }
            while (i != 0)
            {
                c = 0;
                Console.WriteLine("Kad prideti nauja elementa iveskite 1.");
                Console.WriteLine("Kad perziureti egzistojancius elementus iveskite 2.");
                Console.WriteLine("Kad iseiti is programos iveskite 0.");
                Console.WriteLine();
                i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (i)
                {
                    case 1:
                        p = 1;
                        Console.WriteLine("Iveskite varda");
                        ame.Add(Console.ReadLine());
                        Console.WriteLine("Iveskite pavarde");
                        sur.Add(Console.ReadLine());
                        Console.WriteLine("Iveskite pazymius uz ND (Kad baigti ivesti iveskite 0).");
                        while(p != 0)
                        {
                            p = Convert.ToInt32(Console.ReadLine());
                            if (p <= 10 && p > 0) man.Add(p);
                        }
                        zge.Add(man);
                        man.Sort();
                        Console.WriteLine("Iveskite pazymi uz egzamina.");
                        nam.Add(Convert.ToInt32(Console.ReadLine()));
                        foreach(int num in zge[zge.Count-1])
                        {
                            c += num;
                        }
                        a = c/zge[zge.Count-1].Count;
                        avg.Add(a * 0.3 + nam[nam.Count - 1] * 0.7);
                        if (man.Count % 2 == 0) m = (man[man.Count / 2] + man[man.Count / 2 + 1]) / 2;
                        else m = man[man.Count/2 + 1];
                        med.Add(m * 0.3 + nam[nam.Count - 1] * 0.7);
                        if (avg[avg.Count - 1] < 5 || med[med.Count - 1] < 5) sta.Add("Failed");
                        else sta.Add("Passed");
                        man.Clear();
                        break;
                    case 2:
                        for(k=0;k<ame.Count;k++)
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4}", ame[k], sur[k], String.Format("{0:.00}", avg[k]), String.Format("{0:.00}", med[k]), sta[k]);
                            Console.WriteLine();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
