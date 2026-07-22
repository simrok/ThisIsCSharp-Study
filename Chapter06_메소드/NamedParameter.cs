// 명명된 인수
using System;

namespace NamedParameter
{
    class MainApp
    {
        static void PrintProfile(string name, string phone)
        {
            Console.WriteLine($"Name: {name}, Phone: {phone}");
        }

        static void Main(string[] args)
        {
            PrintProfile(name: "박찬호", phone: "010-123-1234");
            PrintProfile(phone: "010-123-1234", name: "박찬호");
            PrintProfile("박찬호", phone: "010-123-1234");
            PrintProfile(name: "박찬호","010-123-1234");
        }
    }
}