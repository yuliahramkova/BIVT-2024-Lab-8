using System;
using System.Linq;

namespace Lab_8;

public abstract class Blue
{
    protected string _input;

    public string Input => _input;

    public Blue(string input)
    {
        if (!string.IsNullOrEmpty(input))
            _input = input;
    }

    public abstract void Review();
    public abstract string ToString();
}