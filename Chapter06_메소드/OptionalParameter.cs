// 선택적 매개변수
using System;

namespace OptionalParameter
{
    class MainApp
    {
        static void PrintProfile(string name, string phone = " ")  //  phone을 " "으로 기본값을 설정
        {
            Console.WriteLine($"Name: {name}, Phone: {phone}");
        }

        static void Main(string[] args)
        {
            PrintProfile("중근");
            PrintProfile("관순", "010-123-1234");
            PrintProfile(name: "봉길");
            PrintProfile(name: "동주", phone:"010-123-1234");
        }
    }
}