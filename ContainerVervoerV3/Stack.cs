using System.Collections.Generic;

namespace ContainerVervoerV3
{
    public class Stack
    {
        const int maxWeight = 150000;
        private List<Container> containersInStack;
        int positionInRow;
        private bool gekoeldeStack;
        private bool waardevolleStack;
        public Stack(bool gekoeldeStack, bool waardevolleStack)
        {
            this.containersInStack = new List<Container>();
            this.gekoeldeStack = gekoeldeStack;
            this.waardevolleStack = waardevolleStack;
        }

        public bool PlaatsContainer(Container container)
        {
            bool geplaatst = false;

            if (container.Soort == ContainerSoort.Gekoeld || container.Soort == ContainerSoort.Normaal)
            {
                geplaatst = PlaatsNormaleOfGekoeldeContainer(container);
            }
            else
            {
                geplaatst = PlaatsWaardevolleContainer(container);
            }

            return geplaatst;
        }

        public bool PlaatsWaardevolleOverigeContainer(Container container)
        {
            bool geplaatst = false;
            
            if (GeenWaardevolleInStack() && !MaxGewichtBehaald(container.Gewicht))
            {
                containersInStack.Add(container);
                geplaatst = true;
            }

            return geplaatst;
        }
        

        public bool PlaatsNormaleOfGekoeldeContainer(Container container)
        {
            bool geplaatst = false;
            
            if (GeenWaardevolleInStack() && !MaxGewichtBehaald(container.Gewicht) && !MagWaardevolToevoegen(container.Gewicht))
            {
                containersInStack.Add(container);
                geplaatst = true;
            }

            return geplaatst;
        }

        public bool PlaatsWaardevolleContainer(Container container)
        {
            bool geplaatst = false;
            
            if (GeenWaardevolleInStack() && !MaxGewichtBehaald(container.Gewicht) && MagWaardevolToevoegen(container.Gewicht))
            {
                containersInStack.Add(container);
                geplaatst = true;
            }

            return geplaatst;
        }

            public bool MagWaardevolToevoegen(int nieuweContainerGewicht)
        {
            bool magWaardevolToevoegen = false;

            if (waardevolleStack == true && KrijgStackGewichtOpContainer() + nieuweContainerGewicht >= 120000)
            {
                magWaardevolToevoegen = true;
            }

            return magWaardevolToevoegen;
        }

        public bool MaxGewichtBehaald(int nieuweContainerGewicht)
        {
            bool maxGewichtBehaald = false;

            if (KrijgStackGewichtOpContainer() + nieuweContainerGewicht >= maxWeight)
            {
                maxGewichtBehaald = true;
            }

            return maxGewichtBehaald;
        }

        public bool GeenWaardevolleInStack()
        {
            bool kanPlaatsen = true;
            
            foreach (var containers in containersInStack)
            {
                if (containers.Soort == ContainerSoort.Waardevol)
                {
                    kanPlaatsen = false;
                }
            }

            return kanPlaatsen;
        }

        public int KrijgStackGewichtOpContainer()
        {
            int weight = 0;
            for (int i = 1; i < containersInStack.Count; i++)
            {
                weight += containersInStack[i].Gewicht;
            }
            return weight;
        }
        
        public int KrijgTotaalStackGewicht()
        {
            int weight = 0;
            foreach(Container container in containersInStack)
            {
                weight += container.Gewicht;
            }
            return weight;
        }

        public string OutputTekst()
        {
            string containerString = "";
            int i = 0;
            foreach (var container in containersInStack)
            {
                i++;
                containerString += "height " + i + ", soort " + container.Soort + ". \n";
            }

            return containerString;
        }

    }
}