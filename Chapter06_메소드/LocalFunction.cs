using System;

namespace LocalFunction
{
    class MainApp
    {
        static string ToLowerString(string input)
        {
            var arr = input.ToCharArray();
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = ToLowerChar(i);
            }

            char ToLowerChar(int i)
            {
                if (arr[i] < 65 || arr[i] > 90)     // A ~ Z: 아스키코드 65 ~90
                    return arr[i];
                else
                    return (char)(arr[i] + 32); 
                    // 대문자 A ~ Z에 해당하면 +32해서 소문자(97~122)로 바꾸고 char로 형변환
                    // (char)로 형 변환하는 이유?
                    // char에 산술 연산을 하는 순간 int로 승격함
                    // 따라서 char로 형 변환이 필요함
            }

            return new string(arr);     // 다시 string으로
                                        // char[] arr = {'h', 'e', 'l', 'l', 'o'};
                                        // "hello"
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ToLowerString("Hello"));
            Console.WriteLine(ToLowerString("Good Morning."));
            Console.WriteLine(ToLowerString("This is C#."));
        }
    }
}