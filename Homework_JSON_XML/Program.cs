using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Homework_JSON_XML;

public class Ingredient
{
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; }
}

public class Cocktail
{
    public string Name { get; set; } = string.Empty;
    public float Price { get; set; }
    public float Weight { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new();

    public void InputFromConsole()
    {
        Console.Write("Enter Cocktail: ");
        Name = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter Price: ");
        Price = float.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("Enter Weight: ");
        Weight = float.Parse(Console.ReadLine() ?? string.Empty);
        var flEnterIngredient = true;
        while (flEnterIngredient)
        {
            Console.Write("Enter Ingredient: ");
            var ingredient = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Weight: ");
            var weightIngredient = float.Parse(Console.ReadLine() ?? string.Empty);
            Ingredients.Add(new Ingredient { Name = ingredient, Weight = weightIngredient });
            Console.Write("Continue entering ingredients? Enter (Y) if you want continue entering ingredients: ");
            flEnterIngredient = (Console.ReadLine() ?? string.Empty).ToLower() == "y";
        }

    }

    public override string ToString()
    {
        return $"Cocktail: {Name}, Weight: {Weight}, Price: {Price}";
    }
}

public class XmlManager
{
    private Cocktail _data;

    public XmlManager(Cocktail cocktail)
    {
        _data = cocktail;
    }

    public void Save(string filename)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(Cocktail));
            using TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, _data);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in XML Save: {ex.Message}");
        }
    }

    public void Load(string filename)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(Cocktail));
            using TextReader reader = new StreamReader(filename);
            if (serializer.Deserialize(reader) is var tmp and Cocktail)
            {
                _data = (Cocktail)tmp;
                Console.WriteLine($"XML Data: {_data}");
            }
            else
            {
                Console.WriteLine("Error in XML Load: Data is not Cocktail");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in XML Load: {ex.Message}");
        }
    }
}

public class JsonManager
{
    private Cocktail _data;

    public JsonManager(Cocktail cocktail)
    {
        _data = cocktail;
    }

    public void Save(string filename)
    {
        try
        {
            var json = JsonConvert.SerializeObject(_data);
            File.WriteAllText(filename, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in JSON Save: {ex.Message}");
        }
    }

    public void Load(string filename)
    {
        try
        {
            var json = File.ReadAllText(filename);
            var tmp = JsonConvert.DeserializeObject<Cocktail>(json);
            if (tmp is not null)
            {
                _data = tmp;
                Console.WriteLine($"JSON Data: {_data}");
            }
            else
            {
                Console.WriteLine("Error in JSON Load: Data is not Cocktail");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in JSON Load: {ex.Message}");
        }
    }
}

internal class Program
{
    private static void Main()
    {
        var cocktail = new Cocktail();
        cocktail.InputFromConsole();

        var xmlManager = new XmlManager(cocktail);
        var jsonManager = new JsonManager(cocktail);

        xmlManager.Save("data.xml");
        jsonManager.Save("data.json");

        xmlManager.Load("data.xml");
        jsonManager.Load("data.json");
    }
}