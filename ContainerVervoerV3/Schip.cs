using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoerV3
{
    public class Schip
    {
        private int lengte = 0;
        private int breedte = 0;
        private int maxGewicht = 0;
        private int containerLengte = 0;
        private int containerHoogte = 250;
        private int containerBreedte = 0;
        public List<Row> rows;
        public List<Container> containersList;

        public int Lengte { get; set; }
        
        public int Breedte { get; set; }

        public int MaxGewicht { get; set; }

        public int ContainerLengte { get; set; }
        
        public int ContainerBreedte { get; set; }

        public Schip(List<Container> containers, int lengte, int breedte, int maxGewicht, int containerLengte, int containerBreedte)
        {
            this.rows = new List<Row>();
            this.containersList = containers;
            this.lengte = lengte;
            this.breedte = breedte;
            this.maxGewicht = maxGewicht;
            this.containerLengte = containerLengte;
            this.containerBreedte = containerBreedte;

            Console.WriteLine(LoopDoorFuncties());
        }

        public string LoopDoorFuncties()
        {
            if (SchipTotaalGewicht() > maxGewicht)
            {
                return "Totale gewicht van de containers is groter dan het maximum gewicht van het schip";
            }
            MaakRows();
            PlaatsAlleContainers();
            if (Gekapseisd())
            {
                return "Het schip is gekapseisd!!!!"; 
            }
            OutputTekst();
            return Balans();
       }

        public void MaakRows()
        {
            for (int i = 0; i < lengte / containerLengte; i++)
            {
                if (i == 0)
                {
                    rows.Add(new Row(breedte / containerBreedte, true, true) );
                }
                else if (i == lengte / containerLengte - 1)
                {
                    rows.Add(new Row(breedte / containerBreedte, false, true));
                }
                else
                {
                    rows.Add(new Row(breedte / containerBreedte, false, false));
                }

            }
        }

        public void PlaatsAlleContainers()
        {
            do
            {
                PlaatsContainers();

                if (CheckOverigeContainersWaardevol(containersList))
                {
                    PlaatsWaardevolleOverigeContainers();
                }
            } while (containersList.Count > 0);
        }

        public void PlaatsContainers()
        {
            for (int i = 0; i < containersList.Count; i++)
            {
                if (PlaatsContainer(containersList[i]))
                {
                    containersList.Remove(containersList[i]);
                    i--;
                }
            }
        }

        public bool PlaatsContainer(Container container)
        {
            bool isPlaced = false;
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].PlaatsContainer(container))
                {
                    isPlaced = true;
                    CounterWeight(container.Gewicht, i);
                    break;
                }
            }

            return isPlaced;
        }
        
        public void PlaatsWaardevolleOverigeContainers()
        {
            for (int i = 0; i < containersList.Count; i++)
            {
                if (PlaatsWaardevolleOverigeContainer(containersList[i]))
                {
                    containersList.Remove(containersList[i]);
                    i--;
                }
            }
        }

        public bool PlaatsWaardevolleOverigeContainer(Container container)
        {
            bool isPlaced = false;
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].PlaatsWaardevolleOverigeContainer(container))
                {
                    isPlaced = true;
                    break;
                }
            }

            return isPlaced;
        }

        public bool CheckOverigeContainersWaardevol(List<Container> containersList)
        {
            bool allesWaardevol = false;

            if (containersList.All(s => s.Soort == ContainerSoort.Waardevol))
            {
                allesWaardevol = true;
            }

            return allesWaardevol;
        }

        public void CounterWeight(int containergewicht, int geplaatstRow)
        {
            if (NormaleContainerList().Count > 1)
            {
                int tegenoverRow = rows.Count - geplaatstRow;

                Container tegenGewichtContainer = NormaleContainerList().Aggregate((x, y) =>
                    Math.Abs(x.Gewicht - containergewicht) < Math.Abs(y.Gewicht - containergewicht) ? x : y);

                PlaatsTegenGewichtContainer(tegenGewichtContainer, tegenoverRow);
            }
        }

        public bool PlaatsTegenGewichtContainer(Container tegenGewichtContainer, int tegenoverRow)
        {
            bool geplaatst = false;
            for (int i = tegenoverRow - 1; i > 0; i--)
            {
                if (rows[i].PlaatsContainer(tegenGewichtContainer))
                {
                    containersList.Remove(tegenGewichtContainer);
                    geplaatst = true;
                    break;
                }
            }

            return geplaatst;
        }
        
        public List<Container> NormaleContainerList()
        {
            List<Container> normaleContainers = new List<Container>();
            foreach (var containers in containersList)
            {
                if (containers.Soort == ContainerSoort.Normaal)
                {
                    normaleContainers.Add(containers);
                }
            }

            return normaleContainers;
        }

        public string Balans()
        {
            int schipMiddenLinks = lengte / containerLengte / 2;
            int schipMiddenRechts = lengte / containerLengte / 2;
            
            if (lengte / containerLengte % 2 > 0)
            {
                schipMiddenRechts++;
            }

            return BalansBerekening(GewichtLinks(schipMiddenLinks), GewichtRechts(schipMiddenRechts));
        }

        public string BalansBerekening(int gewichtLinks, int gewichtRechts)
        {
            string returnstring = "Schip is in evenwicht!";
            if (Math.Abs(gewichtLinks - gewichtRechts) > (gewichtLinks + gewichtRechts) * 0.2)
            {
                returnstring = "Het schip is uit evenwicht \nGewicht rechterkant = " + gewichtRechts +
                               " gewicht linkerkant = " + gewichtLinks;
            }

            return returnstring;
        }
        
        public int GewichtLinks(int schipMidden)
        {
            int weightLeft = 0;
            for (int i = 0; i < schipMidden; i++)
            {
                weightLeft += rows[i].KrijgTotaalRowGewicht();
            }

            return weightLeft;
        }
        
        public int GewichtRechts(int schipMidden)
        {
            int weightRight = 0;
            for (int i = schipMidden; i < rows.Count; i++)
            {
                weightRight += rows[i].KrijgTotaalRowGewicht();
            }

            return weightRight;
        }

        public bool Gekapseisd()
        {
            bool gekapseisd = false;
            
            if (SchipTotaalGewicht() < maxGewicht * 0.5)
            {
                gekapseisd = true;
            }

            return gekapseisd;
        }

        public int SchipTotaalGewicht()
        {
            int totaalSchipGewicht = 0;
            
            foreach (var row in rows)
            {
                totaalSchipGewicht += row.KrijgTotaalRowGewicht();
            }

            return totaalSchipGewicht;
        }
        
        public void OutputTekst()
        {
            int i = 0;
            foreach (var row in rows)
            {
                i++;
                Console.WriteLine("Op row " + i + row.OutputTekst());
            }
        }
        

        
        
    }
}