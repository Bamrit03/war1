using System;

class Unit
{
    public string Nimi { get; set; }
    public int Hyokkaysvoima { get; set; }
    public int Osumapisteet { get; set; }

    public Unit(string nimi, int hyokkaysvoima, int osumapisteet)
    {
        Nimi = nimi;
        Hyokkaysvoima = hyokkaysvoima;
        Osumapisteet = osumapisteet;
    }

    public void Hyokkaa(Unit toinenUnit)
    {
        Random rnd = new Random();
        int vahinko = rnd.Next(1, Hyokkaysvoima + 1);
        toinenUnit.Osumapisteet -= vahinko;
        Console.WriteLine($"{Nimi} attacks {toinenUnit.Nimi}, dealing {vahinko} damage.");
    }
}

class Program
{
    static void Taistelu(Unit unit1, Unit unit2)
    {
        Console.WriteLine($"Battle begins. {unit1.Nimi} against {unit2.Nimi}.");

        while (unit1.Osumapisteet > 0 && unit2.Osumapisteet > 0)
        {
            unit1.Hyokkaa(unit2);
            if (unit2.Osumapisteet <= 0)
            {
                Console.WriteLine($"{unit2.Nimi} is defeated!");
                Console.WriteLine($"{unit1.Nimi} is victorious!");
                break;
            }

            unit2.Hyokkaa(unit1);
            if (unit1.Osumapisteet <= 0)
            {
                Console.WriteLine($"{unit1.Nimi} is defeated!");
                Console.WriteLine($"{unit2.Nimi} is victorious!");
                break;
            }
        }
    }

    static void Main()
    {
        Unit humanWarrior = new Unit("Human warrior", 20, 100);
        Unit skeletonWarrior = new Unit("Skeleton warrior", 15, 80);

        Taistelu(humanWarrior, skeletonWarrior);
    }
}

