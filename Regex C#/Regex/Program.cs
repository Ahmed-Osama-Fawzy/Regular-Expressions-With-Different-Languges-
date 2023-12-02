using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

class RegexHelper
{
    private Dictionary<string, string> MyPatterns = new Dictionary<string, string>();
    public RegexHelper()
    {
        MyPatterns.Add("Name", "^[A-Za-z]+$");
        MyPatterns.Add("Mobile", @"(\+2)?0(10|11|12|15)[0-9]{8}$");
        MyPatterns.Add("Email", "\\w@(gmail|oulook|hotmail).(com|org|info|io|edu|eg)");
        MyPatterns.Add("FloatNumber", "");
        MyPatterns.Add("IntNumber", "");
        MyPatterns.Add("Address", "[0-9][a-zA-Z]");
        MyPatterns.Add("Normal Text", "");
        MyPatterns.Add("Spicail Text", "");
    }
    public bool Matches(string Text , string Type)
    {
        if (MyPatterns.Keys.Contains(Type))
        {
            Regex regex = new Regex(MyPatterns[Type]);
            return regex.IsMatch(Text);
        }
        else
        {
            return false;
        }
    }
}
class Program
{
    static void Main()
    {
        RegexHelper RH = new RegexHelper();
        Console.WriteLine(RH.Matches("AhmedOsama","Name"));
        Console.WriteLine(RH.Matches("01026301814","Mobile"));
        Console.WriteLine(RH.Matches("+201026301814","Mobile"));
        Console.WriteLine(RH.Matches("010263018143", "Mobile"));
        Console.WriteLine(RH.Matches("+2010263018114", "Mobile"));
        Console.WriteLine(RH.Matches("01826301814", "Mobile"));
        Console.WriteLine(RH.Matches("+201926301814", "Mobile"));
        Console.WriteLine(RH.Matches("ahmd.osama2611@gmail.com", "Email"));
        Console.WriteLine(RH.Matches("ahmd.osama2611@gmail", "Email"));
        Console.WriteLine(RH.Matches("ahmd.osama2611gmail", "Email"));
        Console.WriteLine(RH.Matches("ahmd.osama2611", "Email"));

    }
}