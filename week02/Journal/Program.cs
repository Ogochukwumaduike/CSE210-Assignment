using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                string[] prompts =
                {
                    "What was the strongest emotion I felt today?",
                    "If I had one thing I could do over today, what would it be?"
                };

                Random random = new Random();
                int index = random.Next(prompts.Length);

                Console.WriteLine();
                Console.WriteLine(prompts[index]);
                Console.Write("> ");

                string response = Console.ReadLine();

                string date = DateTime.Now.ToString("yyyy-MM-dd");

                Entry newEntry = new Entry();

                newEntry._date = date;
                newEntry._prompt = prompts[index];
                newEntry._response = response;

                journal.AddEntry(newEntry);

                Console.WriteLine();
                Console.WriteLine("Entry added successfully!");
            }
            else if (choice == "2")
            {
                Console.WriteLine();

                if (journal._entries.Count == 0)
                {
                    Console.WriteLine("There are no journal entries to display.");
                }
                else
                {
                    journal.DisplayAll();
                }
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename to load: ");
                string filename = Console.ReadLine();

                try
                {
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded successfully!");
                }
                catch (Exception)
                {
                    Console.WriteLine("There was a problem loading the file.");
                }
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename to save: ");
                string filename = Console.ReadLine();

                try
                {
                    journal.SaveToFile(filename);
                    Console.WriteLine("Journal saved successfully!");
                }
                catch (Exception)
                {
                    Console.WriteLine("There was a problem saving the file.");
                }
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1-5.");
            }
        }
    }
}