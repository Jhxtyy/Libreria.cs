using System;
using System.Collections.Generic;

class Libro
{
    public string Titolo { get; set; }
    public string Autore { get; set; }
    public int AnnoPubblicazione { get; set; }

    public Libro(string titolo, string autore, int annoPubblicazione)
    {
        Titolo = titolo;
        Autore = autore;
        AnnoPubblicazione = annoPubblicazione;
    }

    public override string ToString()
    {
        return $"Titolo: {Titolo}\nAutore: {Autore}\nAnno di pubblicazione: {AnnoPubblicazione}\n";
    }
}

class Program
{
    static List<Libro> libreria = new List<Libro>();

    static void Main()
    {
        Console.WriteLine("Benvenuto nella libreria!");

        while (true)
        {
            Console.WriteLine("\nScegli un'opzione:");
            Console.WriteLine("1. Aggiungi un libro");
            Console.WriteLine("2. Cerca un libro per titolo");
            Console.WriteLine("3. Visualizza l'elenco dei libri");
            Console.WriteLine("4. Esci");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    AggiungiLibro();
                    break;
                case "2":
                    CercaLibro();
                    break;
                case "3":
                    VisualizzaElencoLibri();
                    break;
                case "4":
                    Console.WriteLine("Grazie per aver utilizzato la libreria!");
                    return;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }
    }

    static void AggiungiLibro()
    {
        Console.WriteLine("\nAggiungi un nuovo libro:");

        Console.Write("Titolo: ");
        string titolo = Console.ReadLine();

        Console.Write("Autore: ");
        string autore = Console.ReadLine();

        Console.Write("Anno di pubblicazione: ");
        int annoPubblicazione;

        while (!int.TryParse(Console.ReadLine(), out annoPubblicazione))
        {
            Console.WriteLine("Input non valido. Inserisci un anno valido: ");
        }

        Libro nuovoLibro = new Libro(titolo, autore, annoPubblicazione);
        libreria.Add(nuovoLibro);

        Console.WriteLine("Libro aggiunto con successo!");
    }

    static void CercaLibro()
    {
        Console.WriteLine("\nCerca un libro per titolo:");

        Console.Write("Inserisci il titolo del libro: ");
        string titoloCercato = Console.ReadLine();

        List<Libro> libriTrovati = libreria.FindAll(libro => libro.Titolo.Equals(titoloCercato, StringComparison.OrdinalIgnoreCase));

        if (libriTrovati.Count > 0)
        {
            Console.WriteLine($"\nSono stati trovati {libriTrovati.Count} libri con il titolo '{titoloCercato}':\n");
            foreach (Libro libro in libriTrovati)
            {
                Console.WriteLine(libro);
            }
        }
        else
        {
            Console.WriteLine("Nessun libro trovato con il titolo specificato.");
        }
    }

    static void VisualizzaElencoLibri()
    {
        Console.WriteLine("\nElenco dei libri disponibili:");

        if (libreria.Count > 0)
        {
            foreach (Libro libro in libreria)
            {
                Console.WriteLine(libro);
            }
        }
        else
        {
            Console.WriteLine("Nessun libro presente nella libreria.");
        }
    }
}