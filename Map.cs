using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSim
{
    internal class Map
    {
        private string []names=new string[26] { "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hannah", "Isaac", "Jack", "Kathy", "Leo", "Mona", "Nancy", "Oscar", "Paul", "Quincy", "Rachel", "Steve", "Tracy", "Uma", "Victor", "Wendy", "Xander", "Yvonne", "Zach" };
        public Map() 
        {
            foodlist=one.reshuffleFood();
            daycounter = 0;
            bornblup = 0;
            refreshtime = 3;
        }
        private List<(int, int, int)> foodlist = new List<(int, int, int)>();
        private Food one=new Food();
        private List<Blup> blupList = new List<Blup>();
        private bool addableblub = true;
        private bool blupstillkicking = true;
        private (int,int,int) eaten;
        private int daycounter;
        private List<(int, int, int)> finds;
        private List<Blup> blupfinds;
        private int maxendurance;
        private int maxfood;
        private bool gonnaboink;
        private Blup bestparty;
        private Blup eatenblupy;
        Random rnd = new Random();
        private int bornblup;
        private List<Blup> upgraded;
        private (bool, Blup) ageingoutput;
        private Predator predator= new Predator("Jhonny");
        private int refreshtime;
        public void addBlup(Blup blup) 
        {  
            foreach(Blup bblup in blupList)
            {
                if (bblup.getPos() == blup.getPos())
                {
                    addableblub = blup.fight(bblup);
                }
            }
            if (addableblub) { blupList.Add(blup); }
        }
        public List<(int, int, int)> foodradar(int x, int y, int radius)
        {
            finds = new List<(int, int, int)>();
            foreach ((int, int, int) value in foodlist)
            {
                if ((value.Item1 >= x - radius && value.Item1 <= x + radius) && (value.Item2 >= y - radius && value.Item2 <= y + radius))
                {
                    finds.Add((value.Item1, value.Item2, value.Item3));
                }
            }
            return finds;
        }
        public List<Blup> blubradar(int x, int y, int radius)
        {
            blupfinds = new List<Blup>();
            foreach (Blup blupy in blupList)
            {
                if ((blupy.getPosx() >= x - radius && blupy.getPosx() <= x + radius) && (blupy.getPosy() >= y - radius && blupy.getPosy() <= y + radius))
                {
                    blupfinds.Add(blupy);
                }
            }
            return blupfinds;
        }
        public Blup bestParty(List<Blup> blups)
        {
            Blup best = null;
            foreach (Blup blup in blups)
            {
                maxfood = 0;
                if (maxfood < (blup.getEndurance() + blup.getSight())) { maxfood = blup.getEndurance() + blup.getSight(); bestparty = blup; }
            }
            return bestparty;
        }
        public bool day()
        {
            upgraded=new List<Blup> ();
            gonnaboink=false;
            maxfood = 0;
            daycounter++;
            if (daycounter % refreshtime == 0) { one.reshuffleFood(); }
            refreshtime++;
            Console.WriteLine(daycounter + ".day--------------------------------------------------------");
            maxendurance = 0;
            foreach (Blup blup in blupList)
            {
                if (maxendurance < blup.getEndurance()) { maxendurance = blup.getEndurance(); }
            }
            for (int i = 0; i < maxendurance; i++)
            {
                foreach (Blup blup in blupList)
                {
                    if (i < blup.getEndurance()) 
                    {
                        eaten = blup.move(foodradar(blup.getPosx(), blup.getPosy(), blup.getSight()),predator); 
                        foodlist.Remove(eaten);
                    }
                }
                if (i < predator.getEndurance())
                {
                    eatenblupy = predator.move(blubradar(predator.getPosx(),predator.getPosy(),predator.getSight()));
                    if (eatenblupy != null)
                    {
                        blupList.Remove(eatenblupy);
                        Console.WriteLine(eatenblupy.getName() + ":by predator upgradecount:" + Convert.ToInt32(eatenblupy.getUpgradecount()));
                    }
                }
            }
            for(int i = 0;i < blupList.Count(); i++)
            {
                ageingoutput = blupList[i].ageing();
                blupstillkicking = ageingoutput.Item1;
                if(ageingoutput.Item2!=null) { upgraded.Add(ageingoutput.Item2); }
                if (blupstillkicking == false) { blupList.Remove(blupList[i]); }
            }
            if (blupList.Count != 0 && blupList.Count!=1)
            {
                foreach(Blup blup in upgraded)
                {
                    gonnaboink = blup.gonnaboink(bestParty(blubradar(blup.getPosx(), blup.getPosy(), blup.getSexSight())));
                    bestparty = bestParty(blubradar(blup.getPosx(), blup.getPosy(), blup.getSexSight()));
                    //mutual agreement xd
                    if (gonnaboink && bestparty.gonnaboink(blup)) 
                    { 
                        Blup newchild = new Blup(names[rnd.Next(26)]); 
                        newchild.newBornGenetics(bestparty); 
                        blupList.Add(newchild); 
                        bornblup++; 
                    }
                }
            }
            foreach (Blup blup in blupList) { Console.WriteLine(blup.getName()+" "+blup.getPosx()+" "+blup.getPosy() + " " + blup.getFood()/*+" stats:" + blup.getEndurance()+ " " + blup.getSight()*/); }
            //Console.WriteLine(predator.getPosx() + " " + predator.getPosy());
            //if (blupList.Count == 1) Console.WriteLine("stats:" + blupList[0].getSight() + " " + blupList[0].getEndurance());
            //if (daycounter > 50) { /*foreach (Blup blup in blupList) { Console.WriteLine("stats:" + blup.getSight() + " " + blup.getEndurance()); };*/ return false; }
            if (blupList.Count == 0) return false;
            else return true;
        }
    }
}
