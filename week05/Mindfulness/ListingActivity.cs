public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by listing items.";
    }

    private void GetRandomPrompt()
    {
        var rand = new Random();
        Console.WriteLine($"> {_prompts[rand.Next(_prompts.Count)]}");
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }
        return items;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("List as many responses as you can:");
        GetRandomPrompt();
        ShowCountDown(3);
        var responses = GetListFromUser();
        Console.WriteLine($"\nYou listed {responses.Count} items.");
        DisplayEndingMessage();
    }
}