public class ReflectingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What could you learn from this experience?",
        "How can you keep this in mind for the future?"
    };

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    private string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        return _questions[new Random().Next(_questions.Count)];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine($"> {GetRandomPrompt()}");
        ShowSpinner(5);
    }

    private void DisplayQuestions()
    {
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.WriteLine($"> {GetRandomQuestion()}");
            ShowSpinner(5);
            elapsed += 5;
        }
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Consider the following:");
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }
}