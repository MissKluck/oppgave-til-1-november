using System;
using System.IO;

public class IOHandler
{
    public void ReadJSONFile(string filePath)
    {
        try
        {
            string jsonData = File.ReadAllText(filePath);
            Console.WriteLine("Contents of the JSON file:");
            Console.WriteLine(jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reding from the JSON file: {ex.Message}");
        }
    }
}