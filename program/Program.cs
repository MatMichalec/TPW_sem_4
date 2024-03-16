using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj pierwszą liczbę:");
        int pierwszaLiczba = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Podaj drugą liczbę:");
        int drugaLiczba = Convert.ToInt32(Console.ReadLine());

        int wynik = pierwszaLiczba * drugaLiczba;
        Console.WriteLine($"Wynik mnożenia: {wynik}");

        Console.ReadLine();
    }
}

