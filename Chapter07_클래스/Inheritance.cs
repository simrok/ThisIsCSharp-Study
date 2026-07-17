using System;

namespace Inheritance
{

    // 상속으로 코드 재활용하기
    class Base
    {
        public void BaseMethod()
        {
            Console.WriteLine("BaseMethod");
        }

        public Base()
        {
            Console.WriteLine("Base()");
        }

        ~Base()
        {
            Console.WriteLine("~Base()");
        }
    }

    class Derived : Base
    {
        // Derived 클래스는 Base 클래스를 상속했으므로 BaseMethod()를 가짐
        public Derived()
        {
            Console.WriteLine("Derived()");
        }

        ~Derived()
        {
            Console.WriteLine("~Derived()");
        }
    }

    // 메인
    class MainApp
    {
        static void Run()
        {
            Console.WriteLine("=================상속=================");
            Derived derived = new Derived();
        }
    }
}