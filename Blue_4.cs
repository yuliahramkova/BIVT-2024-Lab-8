using System;
using System.Globalization;
using System.Linq;

namespace Lab_8;

public class Blue_4 : Blue
{
    private int _output;

    public int Output => _output;

    public Blue_4(string input) : base(input)
    {
        _output = 0;
    }

    public override void Review()
    {
        if (string.IsNullOrEmpty(_input))
            return;
        
        bool wasDigit = false; int num = 0;
        foreach (char symb in _input)
        {
            if (Char.IsDigit(symb) && !wasDigit)
            {
                num = (int)symb-48;
                wasDigit = true;
            }
            else if (Char.IsDigit(symb) && wasDigit)
            {
                num*=10; num += (int)symb-48;
            }
            else if (!Char.IsDigit(symb) && wasDigit)
            {
                _output+=num;
                num = 0;
                wasDigit = false;
            }
        }
    }
    public override string ToString()
    {
        return $"{_output}";
    }
}