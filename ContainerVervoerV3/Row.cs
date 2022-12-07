using System.Collections.Generic;

namespace ContainerVervoerV3
{
    public class Row
    {
        private int length;
        public List<Stack> stacks;
        private bool gekoeldeRow;
        private bool waardevolleRow;

        public Row(int length, bool gekoeldeRow, bool waardevolleRow)
        {
            this.stacks = new List<Stack>();
            this.length = length;
            this.gekoeldeRow = gekoeldeRow;
            this.waardevolleRow = waardevolleRow;
            MaakStacks();
        }

        public void MaakStacks()
        {
            for(int i = 0; i < length; i++)
            {
                if (gekoeldeRow == true && waardevolleRow == true)
                {
                    stacks.Add(new Stack(true, true));
                }
                else if (waardevolleRow == true)
                {
                    stacks.Add(new Stack(false, true));
                }
                else
                {
                    stacks.Add(new Stack(false, false));
                }
            }
        }
        
        public int KrijgTotaalRowGewicht()
        {
            int weight = 0;
            foreach(Stack stack in stacks)
            {
                weight += stack.KrijgTotaalStackGewicht();
            }
            return weight;
        }

        public bool IsTePlaatsen(Container container)
        {
            bool isTePlaatsen = false;
            if (container.Soort == ContainerSoort.Gekoeld && gekoeldeRow == true)
            {
                isTePlaatsen = true;
            }

            if (container.Soort == ContainerSoort.Waardevol && waardevolleRow == true)
            {
                isTePlaatsen = true;
            }

            if (container.Soort == ContainerSoort.Normaal)
            {
                isTePlaatsen = true;
            }
            return isTePlaatsen;
        }
        

        public bool PlaatsContainer(Container container)
        {
            bool geplaatst = false;
            if (IsTePlaatsen(container))
            {
                foreach (var stack in stacks)
                {
                    if (stack.PlaatsContainer(container))
                    {
                        geplaatst = true;
                        break;
                    }
                }
            }


            return geplaatst;
        }

        public bool PlaatsWaardevolleOverigeContainer(Container container)
        {
            bool geplaatst = false;

            if (IsTePlaatsen(container))
            {
                foreach (var stack in stacks)
                {
                    if (stack.PlaatsWaardevolleOverigeContainer(container))
                    {
                        geplaatst = true;
                        break;
                    }
                }
            }

            return geplaatst;
        }

        public string OutputTekst()
        {
            int i = 0;
            string returnstring = "";
            foreach (var stack in stacks)
            {
                i++;
                returnstring += " in kolom " + i + "\n" + stack.OutputTekst();
            }

            return returnstring;
        }
    }
}