using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bun venit in aplicatia de management al angajatilor!");

        Console.WriteLine("Introduceti numele:");
        string nume = Console.ReadLine();

        Console.WriteLine("Introduceti varsta:");
        int varsta = int.Parse(Console.ReadLine());

        Console.WriteLine("Introduceti nivelul de educatie:");
        string educatie = Console.ReadLine();

        bool isEligibilIT = AngajatManager.VerificareEligibilitateIT(varsta, educatie);

        Angajat angajat = new Angajat(nume, varsta, educatie, isEligibilIT);
        AngajatManager.AdaugaAngajat(angajat);

        Console.WriteLine("Angajatul a fost adaugat cu succes in sistem!");

        Console.WriteLine("\nLista de angajati:");
        AngajatManager.AfiseazaAngajati();

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

        Console.WriteLine("\nIntroduceti numele angajatului de sters:");
        string numeSters = Console.ReadLine();
        AngajatManager.StergeAngajat(numeSters);

        Console.WriteLine("\nIntroduceti numele angajatului de actualizat:");
        string numeActualizat = Console.ReadLine();
        AngajatManager.ActualizeazaAngajat(numeActualizat);

        int numarAngajati = AngajatManager.NumarAngajati();
        Console.WriteLine($"\nNumarul total de angajati: {numarAngajati}");
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

    public static void StergeAngajat(string nume)
    {
        Angajat angajat = CautaAngajatDupaNume(nume);
        if (angajat != null)
        {
            angajati.Remove(angajat);
            Console.WriteLine($"Angajatul cu numele {angajat.Nume} a fost sters din sistem.");
        }
        else
        {
            Console.WriteLine("Angajatul cautat nu a fost gasit in sistem.");
        }
    }

    public static void ActualizeazaAngajat(string nume)
    {
        Angajat angajat = CautaAngajatDupaNume(nume);
        if (angajat != null)
        {
            Console.WriteLine("Introduceti noile informatii:");

            Console.WriteLine("Introduceti noul nume:");
            angajat.Nume = Console.ReadLine();

            Console.WriteLine("Introduceti noua varsta:");
            angajat.Varsta = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti noul nivel de educatie:");
            angajat.Educatie = Console.ReadLine();

            angajat.IsEligibilIT = VerificareEligibilitateIT(angajat.Varsta, angajat.Educatie);

            Console.WriteLine("Angajatul a fost actualizat cu succes!");
        }
        else
        {
            Console.WriteLine("Angajatul cautat nu a fost gasit in sistem.");
        }
    }

    public static int NumarAngajati()
    {
        return angajati.Count;
    }

    public static bool VerificareEligibilitateIT(int varsta, string educatie)
    {
        if (varsta >= 18 && educatie.ToLower() == "superior")
        {
            return true;
        }

        return false;
    }
}
