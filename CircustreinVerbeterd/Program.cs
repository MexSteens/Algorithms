using System;
using System.Collections.Generic;

namespace CircustreinVerbeterd
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>()
            {
                new Carnivore(3),
                new Herbivore(2),
                new Carnivore(2),
                new Carnivore(3),
                new Herbivore(3),
                new Herbivore(1)
            };

            Train t = new Train(animals);
            // t.Results();
            

        }
    }

}