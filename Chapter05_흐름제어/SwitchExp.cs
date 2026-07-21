using System;
using System.Diagnostics.CodeAnalysis;

namespace SwitchExp
{
    class MainApp
    {
        static void Run ()
        {
            Console.WriteLine("점수를 입력하세요.");
            int score = Convert.ToInt32(Console.ReadLine());    // Convert.ToInt32() static 메서드임 
                                                                // Convert.ToInt32()
                                                                // Convert.ToDouble()
                                                                // Convert.ToBoolean()
                                                                // Convert.ToChar()
                                                                // Convert.ToString()
            // Convert.ToInt32("123")과 int.Parse("123")과의 차이
            // 둘 다 문자열을 정수로 바꿀 수 있지만
            // null을 넣으면 차이가 있다.
            // int.Parse()는 null을 넣으면 예외발생
            // Convert.ToInt32()는 0반환
            // +) int.TryParse(s, out int out_i)    // Switch2.cs 참고!

            Console.WriteLine("재수강인가요? (y/n)");
            string line = Console.ReadLine();
            bool repeated = (line == "y" ? true : false);

            // Switch식
            // 조건식 + switch 키워드
            // case:를 => 로 바꿔고
            // break;는 불필요
            // 각 케이스는 콤마로 구분
            // default 키워드는 _로 바꿈(이를 '무시 패턴'이라고 함)
            string grade = (int)(Math.Truncate(score / 10.0) * 10) switch
            {
                100 when repeated == true => "A",   // 아래 코드랑 순서 바뀌면 안됨
                100 => "A+",
                90 when repeated == true => "B+",
                90 => "A",
                80 => "B",
                70 => "C",
                60 => "D",
                _ => "F"
            };

            Console.WriteLine($"학점 : {grade}");
        }
    }
}