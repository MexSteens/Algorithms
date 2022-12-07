using System;
using System.Collections.Generic;

namespace PoolseNationaleVlag
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> stenen = new List<string>();
            stenen.Add("Rood");
            stenen.Add("Rood");
            stenen.Add("Zwart");
            stenen.Add("Rood");
            stenen.Add("Zwart");
            stenen.Add("Zwart");
            stenen.Add("Zwart");
            stenen.Add("Rood");
            stenen.Add("Zwart");
            stenen.Add("Rood");

            //van internet
            void SortStenenList()
            {
                int stenenLength = stenen.Count;
                for (int j = 0; j < stenenLength - 1; j++)
                {
                    for (int i = j + 1; i < stenenLength; i++)
                    {
                        if (stenen[j].CompareTo(stenen[i]) > 0)
                        {
                            var temp = stenen[j];
                            stenen[j] = stenen[i];
                            stenen[i] = temp;
                        }
                    }
                }
            }
            
            // zelf bedacht en geprogrammeerd
            void SortStenenList2()
            {
                int stenenLength = stenen.Count;
                for (int j = 0; j < stenenLength - 1; j++)
                {
                    for (int i = 1; i < stenenLength - 1; i++)
                    {
                        if (stenen[i] != stenen[0])
                        {
                            var temp = stenen[i];
                            stenen[i] = stenen[i + 1];
                            stenen[i + 1] = temp;
                        }
                    }
                }
            }
            
            SortStenenList2();

            foreach (var steen in stenen)
            {
                Console.WriteLine(steen);
            }
        }
    }
}