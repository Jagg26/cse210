class Scripture
{
    private ScriptureReference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords()
    {
        int countToHide = 3;
        var notHiddenWords = _words.Where(w => !w.IsHidden()).ToList();
        for (int i = 0; i < countToHide && notHiddenWords.Count > 0; i++)
        {
            int index = _random.Next(notHiddenWords.Count);
            notHiddenWords[index].Hide();
            notHiddenWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return _reference.ToString() + "\n" + text;
    }
} 