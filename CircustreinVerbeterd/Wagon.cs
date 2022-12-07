using System;
using System.Collections.Generic;

namespace CircustreinVerbeterd
{
    public class Wagon
    {
        private int points = 0;
        private List<Animal> animals = new List<Animal>();
        
        public int Id { get; set; }
        
        public List<Animal> Animals
        {
            get { return animals; }
            
        }

        public int Points { get;}
        public bool TryToPlaceAnimal(Animal a)
        {
            bool canBePlaced = true;
            foreach (var animal in Animals)
            {
                if (animal.Food(a))
                {
                    canBePlaced = false;
                }
            }

            if (a.Points > 10 - points)
            {
                canBePlaced = false;
            }

            if (points == 10)
            {
                canBePlaced = false;
            }
            
            if (canBePlaced)
            {
                animals.Add(a);
                points = points + a.Points;
            }

            return canBePlaced;
        }

        public string AnimalsInWagon(Animal a)
        {
            string test = a.AnimalString();
            return test;
        }
    }
}