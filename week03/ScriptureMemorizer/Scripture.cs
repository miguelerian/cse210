using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string w in text.Split(" "))
            _words.Add(new Word(w));
    }

    public void HideRandomWords(int numberToHide)
    {
        int count = 0;

        while (count < numberToHide)
        {
            int i = _random.Next(_words.Count);

            if (!_words[i].IsHidden())
            {
                _words[i].Hide();
                count++;
            }
        }
    }

    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText() + "\n";

        foreach (Word w in _words)
            text += w.GetDisplayText() + " ";

        return text;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
            if (!w.IsHidden()) return false;

        return true;
    }
}