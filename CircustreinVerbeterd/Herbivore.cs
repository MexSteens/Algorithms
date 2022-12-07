namespace CircustreinVerbeterd
{
    public class Herbivore: Animal
    {
        public Herbivore(int size):base(size)
        {
    
        }
        
        public override bool Food(Animal a)
        {
            if (a is Carnivore)
            {
                return  a.Size >= Size;
            }
            return false;
        }

        public override string AnimalString()
        {
            return "herbivore met een grootte van " + Size;
        }
    }
}