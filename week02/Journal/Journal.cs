public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach(Entry newEntry in _entries)
        {
            newEntry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach(Entry newEntry in _entries)
            {
                outputFile.WriteLine($"{newEntry._date}|{newEntry._promptText}|{newEntry._entryText}");
            }
        }
    }
    
    public void LoadFromFile(string file)
    {
        string[] lines = File.ReadAllLines(file);

        _entries.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry newEntry = new Entry();
            newEntry._date = parts[0];
            newEntry._promptText = parts[1];
            newEntry._entryText = parts[2];

            _entries.Add(newEntry);
        }
    }
}