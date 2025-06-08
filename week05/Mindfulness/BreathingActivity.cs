public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly.";
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);
            elapsed += 4;
            if (elapsed >= _duration) break;

            Console.Write("\nBreathe out... ");
            ShowCountDown(6);
            elapsed += 6;
        }
        DisplayEndingMessage();
    }
}