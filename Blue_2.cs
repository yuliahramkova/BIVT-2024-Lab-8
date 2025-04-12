using System;
using System.Linq;

namespace Lab_8;
public class Blue_2 : Blue
{
    private string _output;
    private string _delete;

    public string Output => _output;

    public Blue_2(string input, string delete) : base(input)
    {
        _delete = delete;
        _output = "";
    }

    private static void ToDelete(ref string[] strs, int ind)
    {
        if (strs == null || strs.Length == 0 || ind < 0 || ind >= strs.Length)
            return;

        if (strs[ind].Contains("\"") && !strs[ind].Contains('.') && !strs[ind].Contains(','))
        {
            strs[ind] = "\"\"";
            return;
        }
        else if (strs[ind].Contains("\"") &&strs[ind].Contains('.'))
        {
            strs[ind] = "\"\".";
            return;
        }
        else if (strs[ind].Contains("\"") &&strs[ind].Contains(','))
        {
            strs[ind] = "\"\",";
            return;
        }

        string[] newStrs = new string[strs.Length-1];
        Array.Copy(strs, newStrs, ind);
        if (strs[ind].Contains('.') && ind != 0)
            newStrs[ind-1] += ".";
        else if (strs[ind].Contains(",") && ind != 0)
            newStrs[ind-1] += ",";
        Array.Copy(strs, ind+1, newStrs, ind, strs.Length-ind-1);
        strs = newStrs;
    }
    public override void Review()
    {
        if (string.IsNullOrEmpty(_input) || string.IsNullOrEmpty(_delete))
            return;
        _output = _input;
        if (!_input.Contains(_delete))
            return;

        string[] strings = _input.Split(" ");
        for (int i = 0; i<strings.Length; i++)
        {
            if (strings[i].Contains(_delete))
                ToDelete(ref strings, i);
        }
        _output = string.Join(" ", strings);
    }
    public string ToString()
    {
        if (string.IsNullOrEmpty(_output))
            return null;
        return _output;
    }
}