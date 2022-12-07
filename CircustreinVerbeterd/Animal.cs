namespace CircustreinVerbeterd
{
    public abstract class Animal
    {
        protected internal int Size;
        protected internal int Points;

        public int size
        {
            get { return Size; }
        }

        public Animal(int size)
        {
            Size = size;
            if (size == 1)
            {
                Points = 1;
            }

            if (size == 2)
            {
                Points = 3;
            }

            if (size == 3)
            {
                Points = 5;
            }
        }
        
        public abstract bool Food(Animal a);

        public abstract string AnimalString();
    }
}