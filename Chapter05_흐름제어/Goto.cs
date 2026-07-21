using System;

namespace Goto
{
    class MainApp
    {
        static void Run(string[] args)
        {
            Console.Write("종료 조건(숫자)을 입력하세요: ");

            string input = Console.ReadLine();

            // int inputNumber = Convert.ToInt32(input);
            if (!int.TryParse(input, out int inputNumber))  // bool 값 리턴. 정수를 입력하지 않을 경우 출 
            {
                Console.WriteLine("숫자를 입력하세요. 프로그램 종료");
                return;
            }

            int exitNumber = 0;

            for(int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        if (exitNumber++ == inputNumber)  // 반복 횟수 == 콘솔 입력 번호
                            goto EXIT_FOR;
                        Console.WriteLine(exitNumber);
                    }
                }
            }

            goto EXIT_PROGRAM;

        EXIT_FOR:   // 레이블의 위치는 왼쪽에 있는 것이 권장됨
            Console.WriteLine("\nExit nested for...");

        EXIT_PROGRAM:
                Console.Write("Exit program...");   // 콘솔에 입력한 수 > 반복 횟수를 넘어서면
        }
    }
}