using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSim
{
    internal class Food
    {
        public Food() { }
        Random rnd = new Random();
        private List<(int,int,int)> foodlist=new List<(int, int, int)>();
        int foodcount;
        int b, c, d;
        public List<(int, int, int)> reshuffleFood()
        {
            foodcount = rnd.Next(500);
            for (int i = 0; i < foodcount; i++)
            {
                b = rnd.Next(98)+1;
                c = rnd.Next(98)+1;
                d = rnd.Next(4)+1;
                if (foodlist.Contains((b, c, d))) { }
                else { foodlist.Add((b, c, d)); }
            }
            return foodlist;
        }
    }
}
