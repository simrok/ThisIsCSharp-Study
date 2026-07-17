using System;

namespace MethodHiding
{
    class Base
    {
        public void MyMethod()
        {
            Console.WriteLine("Base.MyMethod()");
        }
    }

    class Derived : Base
    {
        public new void MyMethod()  // new 키워드 사용해서 메소드 숨기기
        {
            Console.WriteLine("Derived MyMethod()");
        }
    }

    class MainApp
    {
        static void Run()
        {
            Base baseObj = new Base();  // Base의 메소드 실행
            baseObj.MyMethod();

            Derived derivedObj = new Derived();     // Derived의 메소드 실행
            derivedObj.MyMethod();

            Base baseOrDerived = new Derived();     // Derived의 메소드는 숨겨지고 Base의 메소드 실행!
            baseOrDerived.MyMethod();
        }
    }
}