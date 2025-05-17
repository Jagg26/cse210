using System;

class Program
{
    static void Main(string[] args)

    // Extension for full credit (100%):
    // This program saves and loads the journal in a CSV format compatible with Excel,
    // properly escaping commas, quotation marks, and newlines as required by the CSV standard.
    // Implemented in the SaveToFile and LoadFromFile methods of the Journal class.
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Entry newEntry = new Entry
                    {
                        _date = DateTime.Now.ToString("yyyy-MM-dd"),
                        _promptText = prompt,
                        _entryText = response
                    };
                    myJournal.AddEntry(newEntry);
                    break;

                case "2":
                    myJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.");
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded.");
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}