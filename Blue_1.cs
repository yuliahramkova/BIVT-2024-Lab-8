using System;
using System.Linq;

namespace Lab_8;

public class Blue_1 : Blue
{
    private string[] _output;
    
    public string[] Output => _output;

    public Blue_1(string input) : base(input) 
    {
        _output = null;
    }

    private static void Add(ref string[] strings, string str)
    {
        if (strings == null || string.IsNullOrEmpty(str))
            return;
        
        string[] newStrings = new string[strings.Length+1];
        Array.Copy(strings, newStrings, strings.Length);
        newStrings[strings.Length] = str;
        strings = newStrings;
    }
    public override void Review()
    {
        if (string.IsNullOrEmpty(Input))
        {
            _output = null;
            return;
        }

        _output = Input.Split(" ");
        string[] res = new string[0];
        int counter = 0;
        for (int i = 0; i<_output.Length; )
        {
            string p = "";
            counter = _output[i].Length;
            while (counter <= 50)
            {
                p += _output[i++]+" ";
                if (i != _output.Length)
                {
                    counter += _output[i].Length+1;
                }
                else 
                    break;
            }
            
            Add(ref res,p.Substring(0, p.Length-1));
        }
        _output = res;
    }
    public override string ToString()
    {
        if (_output == null || _output.Length == 0)
            return string.Empty;
        return string.Join(Environment.NewLine, _output);
    }
}