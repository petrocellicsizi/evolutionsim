using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSim
{
    internal class Predator
    {
        private string name;
        private int posx;
        private int posy;
        private int sight;
        private int endurance;
        private int strenght;
        private int movement;
        Random rnd=new Random();
        private int whichside;
        private int counter;
        private int min;
        private int minind;
        public Predator(string name) 
        { 
            this.name = name;
            posx = rnd.Next(101);
            posy = 0;
            sight = 10;
            endurance = 5;
            movement = 2;
        }
        public int getEndurance() { return endurance; }
        public int getPosx() { return posx; }
        public int getPosy() {  return posy; }
        public int getSight() { return sight;}
        public Blup move(List<Blup> blupinsight)
        {
            if (blupinsight.Count() == 0)
            {
                whichside = rnd.Next(2);
                if (whichside == 0 && posy != 0 && posy >= 50) { posy -= movement; }
                else if (whichside == 0 && posx != 99 && posx <= 50) { posx += movement; }
                else if (whichside == 1 && posy != 99 && posy < 50) { posy += movement; }
                else if (whichside == 1 && posx != 0 && posx > 50) { posx -= movement; }
                return null;
            }
            counter = -1;
            foreach (Blup find in blupinsight)
            {
                counter++;
                if (min > (Math.Abs(find.getPosx() - posx) + Math.Abs(find.getPosy() - posy))) { min = Math.Abs(find.getPosx() - posx) + Math.Abs(find.getPosy() - posy); minind = counter; }
            }
            if (blupinsight[counter].getPosx() < posx) { posx-=movement; }
            else if (blupinsight[counter].getPosx() > posx) { posx+=movement; }
            else if (blupinsight[counter].getPosy() < posy) { posy-=movement; }
            else if (blupinsight[counter].getPosy() > posy) { posy+=movement; }
            if (blupinsight[counter].getPosx() == posx && blupinsight[counter].getPosy() == posy) { return (blupinsight[counter]); }
            return null;
        } 
    }
}
