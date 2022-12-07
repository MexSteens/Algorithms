namespace CircustreinVerbeterd
{

    public class Carnivore: Animal
    {
        public Carnivore(int size):base(size)
        {
    
        }
        
        public override bool Food(Animal a)
        {
            if (a is Carnivore)
            {
                return true;
            }
            return a.Size <= Size;
        }
        
        public override string AnimalString()
        {
            return "carnivore met een grootte van " + Size;
        }
    }
}