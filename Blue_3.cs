using System;
using System.Linq;

namespace Lab_8;

public class Blue_3 : Blue
{
    private (char, double)[] _output;

    public (char, double)[] Output
    {
        get
        {
            if (_output == null)
                return null;
            (char, double)[] newOutput = new (char, double)[_output.Length];
            Array.Copy(_output, newOutput, _output.Length);
            return newOutput;
        }
    }
    private int CountOfWords
    {
        get
        {
            if (string.IsNullOrEmpty(_input) || _input.Length == 0)
                return 0;
            return _input.Split(" ").Count(str => Char.IsLetter(str[0]));
        }
    }

    public Blue_3(string input) : base(input) 
    {
        _output = Array.Empty<(char, double)>();
    }

    private void Add(char ch)
    {
        if (_output == null)
            return;
        (char, double)[] newOutput = new (char, double)[_output.Length+1];
        Array.Copy(_output, newOutput, _output.Length);
        newOutput[_output.Length] = (ch, 1);
        _output = newOutput;
    }
    public override void Review()
    {
        if (string.IsNullOrEmpty(_input) || _input.Length == 0 || _output == null)
                return;
        string[] strs = _input.Split(" ");
        foreach (string str in strs)
        {
            if (!Char.IsLetter(str[0]))
                continue;
            bool isFound = false;
            for (int i = 0; i<_output.Length; i++)
            {
                if (Char.ToLower(str[0]) == _output[i].Item1)
                {
                    _output[i].Item2++;
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
                Add(Char.ToLower(str[0]));
        }
        for (int i = 0; i<_output.Length; i++)
        {
            _output[i].Item2 /= CountOfWords;
            _output[i].Item2 *= 100;
        }

        (char,double)[] newOutput = _output.OrderByDescending( pair => pair.Item2).ThenBy(pair => pair.Item1).ToArray();
        _output = newOutput;
    }

    public string ToString()
    {
        if (_output == null)
            return null;
        
        return string.Join("\n", _output.Select(p => $"{p.Item1} - {p.Item2:F4}"));
    }
}