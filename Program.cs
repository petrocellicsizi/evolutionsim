namespace EvolutionSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            Blup egyes = new Blup("bobi");
            Blup kettes = new Blup("peti");
            Blup harmas = new Blup("topi");
            Blup negyes = new Blup("marci");
            Blup otos = new Blup("polyák");
            Blup hatos = new Blup("bogi");
            Blup hetes = new Blup("ákos");
            Blup nyolcas = new Blup("nóri");
            Blup kilences = new Blup("dani");
            map.addBlup(harmas);
            map.addBlup(kettes);
            map.addBlup(egyes);
            map.addBlup(negyes);
            map.addBlup(hatos);
            map.addBlup(hetes);
            map.addBlup(nyolcas);
            map.addBlup(kilences);
            map.addBlup(otos);
            Blup tizes = new Blup("emese");
            map.addBlup(tizes);
            bool a = true;
            while (a) { a=map.day(); }          
        }
    }
}
