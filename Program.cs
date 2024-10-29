using System.Linq.Expressions;
using System.Text.Json;

namespace oppgave_til_1_november;

class Program
{
    public static void Main()
    {
        // Oppgave 1
        // test for creating a text file
        try
        {
            // creates a path to the file test.txt
            string path = "test.txt";
            // checks if the file exists
            if (!File.Exists(path))
            {
                // creates the file if it doesn't exist and then writes text into the file using StreamWriter
                using (StreamWriter sw = File.CreateText(path)) // File.CreateText(path) is the code that creates the file if it doesn't already exist
                {
                    sw.WriteLine("Hello!");
                    sw.WriteLine("My name is Inigo Montoya!");
                    sw.WriteLine("You killed my father!");
                    sw.WriteLine("Prepare to die!");
                }
            }
            // reads the content of the test.txt file
            string text = File.ReadAllText(path);
            // checks if there is any text in the file, and if there is it writes it out in the console
            if (!string.IsNullOrEmpty(text))
            {
                Console.WriteLine(text);
            }
        }
        // if an error relating to file access or any other errors occurs, an error message is printed to the terminal
        catch (IOException exception)
        {
            Console.WriteLine($"An error occured while attempting to write to the file test.txt {exception.Message}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"{exception.Message}\n");
        }

        Console.WriteLine("\n");

        // Oppgave 2
        // creates or updates a new person.json document with user information
        try
        {
            // sets the filepath for out person.json file 
            string filePath = "person.json";

            // creates a list of Person objects which will hold all persons data
            List<Person>? persons = new List<Person>();

            // checks if the person.json file exists
            if (!File.Exists(filePath))
            {
                // reads the existing JSON data from person.json if the file exists
                string existingJSON = File.ReadAllText(filePath);
                Console.WriteLine($"Data already exists within the file person.json {File.ReadAllText(filePath)}");

                // checks if the file's content isn't null or void, and if it contains data, deserializes it into a list of Person objects 
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

            // prompts the user to enter information that will be added to the person.json file
            Console.WriteLine("What is your name?");
            string? name = Console.ReadLine();
            Console.WriteLine("How old are you?");
            string? ageInput = Console.ReadLine();
            int age;

            // checks that the age entered if a number, and prompts the user to re-enter data if not
            while (!int.TryParse(ageInput, out age))
            {
                Console.WriteLine("There was an error with the data submitted, please input your age using numbers.");
                ageInput = Console.ReadLine();
            }
            Console.WriteLine("Where are you from?");
            string? place = Console.ReadLine();
            Console.WriteLine("What position do you have in the story?");
            string? position = Console.ReadLine();

            // creates a new Person object based on the user input
            var newPerson = new Person
            {
                Name = name,
                Age = age,
                Place = place,
                Position = position,
            };

            // adds the new Person object to the persons list
            persons?.Add(newPerson);
            Console.WriteLine($"Your name is {newPerson.Name}. You are {newPerson.Age}, you're from {newPerson.Place}, and you're the {newPerson.Position} in the Princess Bride.");

            // we serialize the object to JSON and use WriteIndented to make it pretty print
            string json = JsonSerializer.Serialize(persons, new JsonSerializerOptions { WriteIndented = true });
            // writes the JSON data to person.js, overwriting the existing content
            File.WriteAllText(filePath, json);
        }
        catch (IOException exception)
        {
            Console.WriteLine($"An error occured while attempting to write to the file person.json: {exception.Message}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"{exception.Message}\n");
        }

    }
}
