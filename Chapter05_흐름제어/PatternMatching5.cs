using System;

// 5. 관계 패턴 
class MainApp
{
    static int IsParsed(double score) => score switch
    {
        < 60 => "F",
        >= 60 and < 70 => "D".
        >= 70 and < 80 => "C",
        _ => "A",
    };

    static void main(string[] args) { Console.WriteLine(IsParsed(88)); }
}