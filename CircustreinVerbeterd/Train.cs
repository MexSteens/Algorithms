using System;
using System.Collections.Generic;
using System.Linq;

namespace CircustreinVerbeterd
{
    public class Train
    {
        private List<Wagon> wagons = new List<Wagon>();
        private int wagonid = 1;
        public List<Wagon> Wagons
        {
            get { return wagons; }
        }
        public Train(List<Animal> animals)
        {
            while (animals.Count > 0)
            {
                Wagon wagon = new Wagon();

                List<Animal> animalsPlaced = new List<Animal>();
                foreach (var animal in animals)
                {
                    if (wagon.TryToPlaceAnimal(animal))
                    {
                        animalsPlaced.Add(animal);
                        Result(animal, wagon);
                    }
                }
                wagons.Add(wagon);
                wagonid++;
                animals = animals.Except(animalsPlaced).ToList();
            }

        }

        public void Result(Animal a, Wagon w)
        {
            
            Console.WriteLine("In wagon " + wagonid + " zit een " + w.AnimalsInWagon(a));
        }
    }
}