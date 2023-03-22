using laba_3;
using Newtonsoft.Json;
using System;

class Program
{
    static void Main(string[] args)
    {
        Polynomial m = new Polynomial();

        Console.WriteLine("\tPolynomial \n\t2a + 3b^2");

        Console.WriteLine("\n Enter a value for a : ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("\n Enter a value for b : ");
        int b = int.Parse(Console.ReadLine());
        m.GeneratePol(a, b);

        Console.WriteLine("Whether the monomial belongs to the polynomial");
        int c = int.Parse(Console.ReadLine());

        m.FindPol(c);
        m.Sum();
        m.Difference();
        m.Product();
        m.Division();
        m.Remainder();
        // Зберігаємо об'єкт у файл JSON
        SaveToJsonFile("polynomial.json", m);

        // Завантажуємо об'єкт з JSON файлу
        Polynomial loadedPoly = LoadFromJsonFile("polynomial.json");
        Console.WriteLine($"Loaded polynomial: {loadedPoly}");

    }
    // Збереження об'єкта у файл JSON
    public static void SaveToJsonFile(string fileName, Polynomial poly)
    {
        string json = JsonConvert.SerializeObject(poly);
        File.WriteAllText(fileName, json);
    }

    // Завантаження об'єкта з файлу JSON
    public static Polynomial LoadFromJsonFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<Polynomial>(json);
        }
        else
        {
            throw new FileNotFoundException("File not found", fileName);
        }
    }

}

