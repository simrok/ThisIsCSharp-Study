using System;
using UsualMethod;
using MyExtention;


namespace UsualMethod
{
    class Person    // static 클래스가 아니라면 객체를 만들어야 함 > Person person = new Person();
    {
        string name;

        void print()
        {
            Console.WriteLine(this.name);   // 확장메소드가 아니라 일반 클래스에서 객체 자신을 가리키는 this!
        }
    }

    public static class UsualInteger    // 확장 메소드 없이 그냥 메소드를 사용할 경우
    {
        public static int Square(int myInt) // this 쓰지 않고 그냥 일반적인 파라미터 형식으로
        {
            return myInt * myInt;
        }
        
        public static int Power(int myInt, int exponent) 
        {
            int result = myInt;
             for(int i=1;i<exponent;++i)
            {
                result = result * myInt;
            } 
             return result;
        }
    }
}

// 확장 메소드 예시
namespace MyExtention
{
    public static class IntegerExtention    // 메소드를 선언하기 위해
                                            // => 클래스를 하나 선언하고 그 안에 확장 메소드를 선언
                                            // 왜 클래스도 static?
                                            // 객체를 만들기 위한 클래스가 아니라 확장 메소드만 모아두는 클래스이기 때문
                                            // 객체를 만들지 않아도 되고 만들 이유도 없음!
    {
        public static int Square(this int myInt)    // 메소드는 static 한정자로 수식해야 한다
                                                    // 메소드의 첫 번째 매개변수는 반드시 this 키워드와 함께
                                                    // 확장하려는 클래스(형식)의 인스턴스여야 한다.
        {
            return myInt * myInt;
        }

        public static int Power(this int myInt, int exponent)   // 메소드는 static 한정자로 수식해야 한다
                                                                // 메소드의 첫 번째 매개변수는 반드시 this 키워드와 함께
                                                                // 확장하려는 클래스(형식)의 인스턴스여야 한다.
                                                                // 그 뒤에 따라오는 매개변수 목록이 실제로 확장 메소드를 호출할 때
                                                                // 입력되는 매개변수임
        {
            int result = myInt;
            for (int i = 1; i < exponent; i++)
                result = result * myInt;

            return result;
        }

       public static string Append(this string myString)
        {
            string hello = "Hello";
            return hello += myString;
            //return string.Concat(hello, myString);
        }
    }
}

namespace ExtentionMethod
{
    class MainApp
    {
        static void Run()
        {
            Console.WriteLine("===============일반적으로 메소드를 사용하는 방법================");
            Console.WriteLine($"3^2 : {UsualInteger.Square(3)}");
            Console.WriteLine($"3^4 : {UsualInteger.Power(3, 4)}");
            Console.WriteLine($"2^10 : {UsualInteger.Power(2, 10)}");

            Console.WriteLine("================확장 메소드================");
            Console.WriteLine($"3^2 : {3.Square()}");   // 3이 myInt로 들어 감.
                                                        // 즉 컴파일러가 자동으로 IntegerExtention.square(3)으로 바꿔줌
            Console.WriteLine($"3^4 : {3.Power(4)}");   // myInt = 3이 되고 IntegerExtention.Power(3, 4)로 바꿔줌
            Console.WriteLine($"2^2 : {2.Power(10)}");
            // this를 붙이는 이유
            // "이 메소드를 int의 멤버 메소드처럼 사용할 수 있게 해줘." 라는 의미
            // 예를 들어서 public static int Square(this int myInt)는
            // 컴파일러에세 "int에 Square()라는 멤버 메소드가 있는 것처럼 보여줘."라고 말하는 것과 같다.
            // 그래서 3.Square()처럼 사용 가능함

            // 착각하기 쉬운 부분!
            // 현재 객체 자신을 가리키는 this가 아니라!
            // 어떤 형식에 메소드를 확장할지 지정하는 것!!
            // 따라서 this 뒤에 int가 오면 int 형식에 확장 메소드를 추가하겠다는 것
            Console.WriteLine("================확장 메소드_VITAMIN QUIZ 7-2================");
            Console.WriteLine(" hello".Append());
        }
    }
}