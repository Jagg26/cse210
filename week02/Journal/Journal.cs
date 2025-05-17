using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("Date,Prompt,Response");

            foreach (Entry entry in _entries)
            {
                string date = EscapeForCsv(entry._date);
                string prompt = EscapeForCsv(entry._promptText);
                string response = EscapeForCsv(entry._entryText);

                outputFile.WriteLine($"{date},{prompt},{response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = ParseCsvLine(line);

            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _promptText = parts[1],
                    _entryText = parts[2]
                };
                _entries.Add(entry);
            }
        }
    }

    private string EscapeForCsv(string value)
    {
        if (value.Contains("\""))
        {
            value = value.Replace("\"", "\"\"");
        }

        if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
        {
            value = $"\"{value}\"";
        }

        return value;
    }

    private string[] ParseCsvLine(string line)
    {
        var result = new List<string>();
        bool inQuotes = false;
        string current = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (inQuotes)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    current += c;
                }
            }
            else
            {
                if (c == ',')
                {
                    result.Add(current);
                    current = "";
                }
                else if (c == '"')
                {
                    inQuotes = true;
                }
                else
                {
                    current += c;
                }
            }
        }

        result.Add(current);
        return result.ToArray();
    }
}
