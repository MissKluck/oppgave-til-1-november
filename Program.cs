using System.Linq.Expressions;

namespace oppgave_til_1_november;

class Program
{
    public static void Main()
    {
        try
        {
         string path = "test.txt";
         if(!File.Exists(path))
         {
             using(StreamWriter sw = File.CreateText(path))
             {
                  sw.WriteLine("Hello!");
                  sw.WriteLine("My name is Inigo Montoya!");
                 sw.WriteLine("You killed my father!");
                 sw.WriteLine("Prepare to die!");
              }
         }
            string text = File.ReadAllText(path);
            if(!string.IsNullOrEmpty(text))
            {
              Console.WriteLine(text);
            }
        }
        catch(IOException exception)
        {
            Console.WriteLine($"An error occured while attempting to write to the file test.txt {exception.Message}");
        }
        catch(Exception exception)
        {
            Console.WriteLine($"{exception.Message}\n");
        }
        

    }
}
