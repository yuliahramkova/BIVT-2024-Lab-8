using System;
using System.Linq;

namespace Lab_8;

public class Blue_3 : Blue
{
    private (char, double)[] _output;

    public (char letter, double percent)[] Output => _output;

    private int CountOfWords
    {
        get
        {
            if (string.IsNullOrEmpty(Input) || Input.Length == 0)
                return 0;
            return Input.Split(" ").Count(str => str.Any(sym => Char.IsLetter(sym)) && !str.Any(sym => Char.IsDigit(sym)));
        }
    }

    public Blue_3(string input) : base(input) 
    {
        _output = null;
    }

    private void Add(char ch)
    {
        if (_output == null)
            return;
        (char, double)[] newOutput = new (char, double)[_output.Length+1];
        Array.Copy(_output, newOutput, _output.Length);
        newOutput[_output.Length] = (ch, 1);
        _output = newOutput;
        // Console.Write($"{ch} ");
    }
    public override void Review()
    {
        if (string.IsNullOrEmpty(Input))
            return;

        string[] strs = Input.Split(" ");
        _output = new (char, double)[0];
        foreach (string str in strs)
        {
            if (!Char.IsLetter(str[0]) && str[0] != '(' && str[0] != '\"')
                continue;

            bool isFound = false;
            for (int i = 0; i<_output.Length; i++)
            {
                if (Char.ToLower(str.First(p => Char.IsLetter(p))) == _output[i].Item1)
                {
                    _output[i].Item2++;
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
                Add(Char.ToLower(str.First(p => Char.IsLetter(p))));
        }
        for (int i = 0; i<_output.Length; i++)
        {
            _output[i].Item2 /= CountOfWords;
            _output[i].Item2 *= 100;
        }

        (char,double)[] newOutput = _output.OrderByDescending( pair => pair.Item2).ThenBy(pair => pair.Item1).ToArray();
        _output = newOutput;
    }

    public override string ToString()
    {
        if (_output == null)
            return null;
        return string.Join(Environment.NewLine, _output.Select(p => $"{p.Item1} - {p.Item2:F4}"));
    }
}