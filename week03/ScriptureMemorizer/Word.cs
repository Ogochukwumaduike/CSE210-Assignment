using System;

class Word
{
    public string text;
    private bool _isHidden;

    public Word(string wordText)
    {
        text = wordText;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', text.Length);
        }

        return text;
    }
}