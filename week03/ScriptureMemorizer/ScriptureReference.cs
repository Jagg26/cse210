class ScriptureReference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    public ScriptureReference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = null;
    }

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        return _endVerse.HasValue ?
            $"{_book} {_chapter}:{_startVerse}-{_endVerse}" :
            $"{_book} {_chapter}:{_startVerse}";
    }

    public static ScriptureReference? Parse(string reference)
    {
        try
        {
            var bookAndVerses = reference.Split(' ');
            var book = string.Join(' ', bookAndVerses[..^1]);
            var verses = bookAndVerses[^1];

            var chapterAndVerse = verses.Split(':');
            int chapter = int.Parse(chapterAndVerse[0]);
            var versePart = chapterAndVerse[1];

            if (versePart.Contains('-'))
            {
                var verseRange = versePart.Split('-');
                return new ScriptureReference(book, chapter, int.Parse(verseRange[0]), int.Parse(verseRange[1]));
            }
            else
            {
                return new ScriptureReference(book, chapter, int.Parse(versePart));
            }
        }
        catch
        {
            return null;
        }
    }
}
