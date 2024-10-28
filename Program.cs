using System.Linq.Expressions;
using System.Text.Json;

namespace oppgave_til_1_november;

class Program
{
    public static void Main()
    {
        // test for creating a text file
        try
        {
            string path = "test.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello!");
                    sw.WriteLine("My name is Inigo Montoya!");
                    sw.WriteLine("You killed my father!");
                    sw.WriteLine("Prepare to die!");
                }
            }
            string text = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(text))
            {
                Console.WriteLine(text);
            }
        }
        catch (IOException exception)
        {
            Console.WriteLine($"An error occured while attempting to write to the file test.txt {exception.Message}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"{exception.Message}\n");
        }

        Console.WriteLine("\n");

        // creates a new person.json document
        try
        {
            // the filepath for our person.json file --> tells the compiler that this is the filepath we'll be using
            string filePath = "person.json";

            // read from the data tht exists within the person.json file
            List<Person> persons = new List<Person>();
            if (!File.Exists(filePath))
            {
                string existingJSON = File.ReadAllText(filePath);
                Console.WriteLine($"Data already exists within the file person.json {File.ReadAllText(filePath)}");
                if (!string.IsNullOrWhiteSpace(existingJSON))
                {
                    persons = JsonSerializer.Deserialize<List<Person>>(existingJSON);
                }
            }
            else
            {
                string existingJSON = File.ReadAllText(filePath);
                Console.WriteLine($"Data already exists within the file person.json {File.ReadAllText(filePath)}");
                if (!string.IsNullOrWhiteSpace(existingJSON))
                {
                    persons = JsonSerializer.Deserialize<List<Person>>(existingJSON);
                }
            }

            // The questions that will appear in the terminal
            Console.WriteLine("What is your name?");
            string? name = Console.ReadLine();
            Console.WriteLine("How old are you?");
            string? ageInput = Console.ReadLine();
            int age;
            while (!int.TryParse(ageInput, out age))
            {
                Console.WriteLine("There was an error with the data submitted, please input your age using numbers.");
                ageInput = Console.ReadLine();
            }
            Console.WriteLine("Where are you from?");
            string? place = Console.ReadLine();
            Console.WriteLine("What position do you have in the story?");
            string? position = Console.ReadLine();

            // create a new object that uses the blueprint from the Person.cs class nd is formated with json
            var newPerson = new Person
            {
                Name = name,
                Age = age,
                Place = place,
                Position = position,
            };
            persons.Add(newPerson);
            Console.WriteLine($"Your name is {newPerson.Name}. You are {newPerson.Age}, you're from {newPerson.Place}, and you're the {newPerson.Position} in the Princess Bride.");
            // overwrites json and makes it pretty print
            string json = JsonSerializer.Serialize(persons, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        catch (IOException exception)
        {
            Console.WriteLine($"An error occured while attempting to write to the file test.txt {exception.Message}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"{exception.Message}\n");
        }

    }
}
