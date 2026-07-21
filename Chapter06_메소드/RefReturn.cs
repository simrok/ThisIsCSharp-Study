using RefReturn;
using System;


// 메소드의 결과를 참조로 반환하기
// 메소드의 결과를 참조로 반환하느 참조 반환값

namespace RefReturn
{
    class Product
    {
        private int price = 100;

        public ref int GetPrice()   // ref 키워드로 메소드를 한정함
        {
            return ref price;       // return 문을 사용할 때 ref 키워드를 반환할 필드나 객체 앞에 붙여줌
        }

        public void PrintPrice()
        {
            Console.WriteLine($"Price: {price}");
        }
    }

    class Output
    {
        public void Divide1(int a, int b, ref int c, ref int d)
        {
            c = a / b;
            d = a % b;
        }
        public void Divide2(int a, int b, out int c, out int d)
        {
            c = a / b;
            d = a % b;
        }
    }
}

class MainApp
{
    static void Main(string[] argg)
    {
        Product carrot = new Product();
        ref int refLocalPrice = ref carrot.GetPrice();  // 1. ref 키워드로 참조로 넘겨받기
        int normalLocalPrice = carrot.GetPrice();       // 2. ref 키워드 없이 평범하게 호출

        carrot.PrintPrice();
        Console.WriteLine($"Ref Local Price: {refLocalPrice}");
        Console.WriteLine($"Normal Local Price: {normalLocalPrice}");

        refLocalPrice = 200;

        carrot.PrintPrice();
        Console.WriteLine($"Ref Local Price: {refLocalPrice}");
        Console.WriteLine($"Normal Local Price : {normalLocalPrice}");

        Console.WriteLine("=================출력 전용 매개 변수========================");
        Output output = new Output();
        int a = 20; int b = 3; int c = 0; int d = 0;

        output.Divide1(a, b, ref c, ref d);
        Console.WriteLine("Quotient: {0}, Reminder {1}", c, d);

        Console.WriteLine("=================출력 전용 매개 변수 OUT1========================");

        int e = 20; int f = 3; int g; int h;
        output.Divide2(e, f, out g, out h);
        Console.WriteLine("Quotient: {0}, Reminder {1}", g, h);

        Console.WriteLine("=================출력 전용 매개 변수 OUT2========================");
        // out 변수는 호출할 때 매개변수 목록 안에서 즉석으로 선언하면 됨
        output.Divide2(e, f, out int quotient, out int remainder);
        Console.WriteLine("Quotient: {0}, Reminder {1}", quotient, remainder);
    }
}