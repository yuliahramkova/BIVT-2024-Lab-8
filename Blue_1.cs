using System;
using System.Linq;

namespace Lab_8;

public class Blue_1 : Blue
{
    private string[] _output;
    
    public string[] Output => _output;

    public Blue_1(string input) : base(input) 
    {
        _output = new string[0];
    }

    private static void Add(ref string[] strings, string str)
    {
        if (strings == null)
            return;
        
        string[] newStrings = new string[strings.Length+1];
        Array.Copy(strings, newStrings, strings.Length);
        newStrings[strings.Length] = str;
        strings = newStrings;
    }
    public override void Review()
    {
        if (string.IsNullOrEmpty(_input))
            return;
        _output = _input.Split(" ");
        // for (int i = 0; i<_output.Length; i++)
        // {
            // while (_output[i].Length > 50)
            // {
                // Add(ref _output, _output[i].Substring(50), i+1);
                // _output[i] = _output[i].Substring(0,50);
            // }
        // }
    }
    public override string ToString()
    {
        if (_output == null || string.IsNullOrEmpty(_input))
            return null;
        
        string[] res = new string[0];
        int counter = 0;
        for (int i = 0; i<_output.Length; )
        {
            string p = "";
            counter = _output[i].Length;
            while (counter <= 50)
            {
                p += _output[i++] + " ";
                if (i != _output.Length)
                    counter += _output[i].Length+1;
                else 
                    break;
            }
            Add(ref res,p);
        }
        string ans = string.Join("\n", res);
        return ans;
    }
}