using System;

namespace This
{
    // this() 생성자
    class MyClass
    {
        int a, b, c;

        public MyClass()
        {
            this.a = 5425;
            Console.WriteLine("MyClass()");
        }

        public MyClass(int b) : this()      // 여기서 this()는 MyClass()를 호출함
        {
            this.b = b;
            Console.WriteLine($"MyClass({b}");
        }

        public MyClass(int b, int c) : this(b)  // 여기서 this(b)는 MyClass(int)를 호출함
        {
            this.c = c;
            Console.WriteLine($"MyClass({c}");
        }

        public void PrintFields()
        {
            Console.WriteLine($"a:{a}, b:{b} c:{c}");
        }
    }

    // 메인
    class MainApp
    {
        static void Run()
        {
            Employee pooh = new Employee();
            pooh.SetName("Pooh");
            pooh.SetPosition("Waiter");
            Console.WriteLine($"{pooh.GetName()} {pooh.GetPosition()}");

            Employee tigger = new Employee();
            tigger.SetName("Tigger");
            tigger.SetPosition("Cleaner");
            Console.WriteLine($"{tigger.GetName()} {tigger.GetPosition()}");
        }
    }
}