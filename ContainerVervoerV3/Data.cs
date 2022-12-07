using System;
using System.Collections.Generic;

namespace ContainerVervoerV3
{
    public class Data
    {
        public List<Container> containers = new List<Container>();

        public void GeefData()
        {
            containers.AddRange(MaakContainers(ContainerSoort.Gekoeld, 20));
            containers.AddRange(MaakContainers(ContainerSoort.Normaal, 1000));
            containers.AddRange(MaakContainers(ContainerSoort.Waardevol, 10));

            Schip schip = new Schip(containers, 200, 20, 3000000, 5, 2);
        }
        
        public List<Container> MaakContainers(ContainerSoort soort, int amount)
        {
            List<Container> containerList = new List<Container>();
            Random rand = new Random();

            for (int i = 0; i < amount; i++)
            {
                Container container = new Container(soort, rand.Next(4000, 30000));
                containerList.Add(container);
            }
            return containerList;
        }
    }
}