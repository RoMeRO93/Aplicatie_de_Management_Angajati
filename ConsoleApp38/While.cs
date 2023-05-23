using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bun venit în aplicatia de management al angajatilor!");
        // Introducerea informațiilor personale
        Console.WriteLine("Introduceti numele:");
        string nume = Console.ReadLine();

        Console.WriteLine("Introduceti varsta:");
        int varsta = int.Parse(Console.ReadLine());

        Console.WriteLine("Introduceti nivelul de educatie:");
        string educatie = Console.ReadLine();

        // Verificarea eligibilității pentru angajare în IT
        bool isEligibilIT = VerificareEligibilitateIT(varsta, educatie);

        // Adăugarea angajatului în sistem
        Angajat angajat = new Angajat(nume, varsta, educatie, isEligibilIT);
        AngajatManager.AdaugaAngajat(angajat);

        Console.WriteLine("Angajatul a fost adăugat cu succes in sistem!");

        // Afisarea listei de angajati
        Console.WriteLine("\nLista de angajati:");
        AngajatManager.AfiseazaAngajati();

        // Căutarea unui angajat după nume
        Console.WriteLine("\nIntroduceti numele angajatului cautat:");
        string numeCautat = Console.ReadLine();
        Angajat angajatCautat = AngajatManager.CautaAngajatDupaNume(numeCautat);

        if (angajatCautat != null)
        {
            Console.WriteLine($"Angajatul cu numele {angajatCautat.Nume} a fost gasit in sistem!");
        }
        else
        {
            Console.WriteLine("Angajatul cautat nu a fost gasit in sistem.");
        }
    }

    private static bool VerificareEligibilitateIT(int varsta, string educatie)
    {
        if (varsta >= 18 && educatie.ToLower() == "superior")
        {
            return true;
        }

        return false;
    }
}

internal class Angajat
{
    public string Nume { get; set; }
    public int Varsta { get; set; }
    public string Educatie { get; set; }
    public bool IsEligibilIT { get; set; }
    public Angajat(string nume, int varsta, string educatie, bool isEligibilIT)
    {
        Nume = nume;
        Varsta = varsta;
        Educatie = educatie;
        IsEligibilIT = isEligibilIT;
    }
}

internal class AngajatManager
{
    private static List<Angajat> angajati = new List<Angajat>();
    public static void AdaugaAngajat(Angajat angajat)
    {
        angajati.Add(angajat);
    }

    public static void AfiseazaAngajati()
    {
        foreach (var angajat in angajati)
        {
            Console.WriteLine($"Nume: {angajat.Nume}, Varsta: {angajat.Varsta}, Educatie: {angajat.Educatie}, Eligibil IT: {angajat.IsEligibilIT}");
        }
    }

    public static Angajat CautaAngajatDupaNume(string nume)
    {
        return angajati.FirstOrDefault(angajat => angajat.Nume.ToLower() == nume.ToLower());
    }
}
