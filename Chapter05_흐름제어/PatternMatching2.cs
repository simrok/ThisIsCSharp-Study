using Systsem;
// 2. 형식 패턴(Type Pattern)
// 1) 예제1
object foo = 23;
if (foo is int)
{
    Console.WriteLine(foo);
}

// 2) 예제2
class Preschooler { }
class Underage { }
class Adult { }
class Senior { }

internal class MainApp
{
    static int CalculateFee(object visitor)
    {
        return visitor switch
        {
            Underage => 100,
            Adult => 500,
            Senior => 200,
            _ => throw new ArgumentException(
                $"Prohibited age: {visitor.GetType()}", nameof(visitor)),
        };
    }
    static void Main(string[] args)
    {
        Console.WriteLine($"Fee for a senior: {CalculateFee(new Senior())}");
        Console.WriteLine($"Fee for a adult: {CalculateFee(new Adult())}");
        Console.WriteLine($"Fee for a underage: {CalculateFee(new Underage())}");
        Console.WriteLine($"Fee for a preschooler: {CalculateFee(new Preschooler())}");
        // Unhandled exception. System.ArgumentException: Prohibited age: Preschooler (Parameter 'visitor')
        //	at MainApp.CalculateFee(Object visitor) in C: \Users\MBC - 501 - 29\Desktop\ThisIsCSharpStudy\ThisIsCSharpStudy\PatternMatching.cs:line 36
        //	at MainApp.Main(String[] args) in C: \Users\MBC - 501 - 29\Desktop\ThisIsCSharpStudy\ThisIsCSharpStudy\PatternMatching.cs:line 45
    }
}
