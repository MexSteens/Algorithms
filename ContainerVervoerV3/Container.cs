
namespace ContainerVervoerV3
{
    public class Container
    {
        private int gewicht = 4000;

        public int row { get; set; }

        public int column { get; set; }

        public int height { get; set; }
        
        public ContainerSoort Soort { get; set; }

        public int Gewicht
        {
            get { return gewicht; }
            set { gewicht = value; }
        }

        public Container(ContainerSoort soort, int gewicht)
        {
            this.gewicht = gewicht;
            Soort = soort;
        }

        public Container(ContainerSoort soort, int gewicht, int row, int column, int height)
        {
            this.gewicht = gewicht;
            Soort = soort;
            this.row = row;
            this.column = column;
            this.height = height;
        }
        
        
    }
    public enum ContainerSoort
    {
        Waardevol = 1,
        Gekoeld = 2,
        Normaal = 3,
    }
}