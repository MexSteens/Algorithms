using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Wetenschappers
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"../../../../../Wetenschappers";

            List<string> lines = new List<string>();
            List<Wetenschapper> wetenschappers = new List<Wetenschapper>();
            List<levendeWetenschapper> levendeWetenschappers = new List<levendeWetenschapper>();

            lines = File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                string[] items = line.Split(";");
                Wetenschapper w = new Wetenschapper(items[0], Convert.ToInt32(items[1]), Convert.ToInt32(items[2]));
                wetenschappers.Add(w);
            }

            void LevendeWetenschappers()
            {
                int count = 0;

                for (int i = wetenschappers[0].geboorteJaar; i < wetenschappers[45].sterfJaar; i++)
                {
                    for (int j = 0; j < wetenschappers.Count; j++)
                    {
                        if (i >= wetenschappers[j].geboorteJaar && i < wetenschappers[j].sterfJaar)
                        {
                            count++;
                        }
                    }

                    levendeWetenschapper lw = new levendeWetenschapper(i, count);
                    levendeWetenschappers.Add(lw);
                    count = 0;
                }
                
                int max = Int32.MinValue;
                levendeWetenschapper maxLevende = new levendeWetenschapper();
                foreach (var levend in levendeWetenschappers)
                {
                    if (levend.count > max)
                    {
                        max = levend.count;
                        maxLevende = levend;
                    }
                }
                
                Console.WriteLine(maxLevende);
                
            }
            
            LevendeWetenschappers();
        }
    }
}