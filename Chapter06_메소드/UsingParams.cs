using System;
// 문서 자동 정렬:ctrl + k +d
// 줄 위치 이동: alt + 위아래 방향키

namespace UsingParams
{
    class MainApp
    {
        static int Sum(params int[] args)
        {
            Console.Write("Summing... ");

            int sum = 0;

            for (int i = 0; i < args.Length; ++i)
            {
                if (i > 0)
                    Console.Write(", ");

                Console.Write(args[i]);

                sum += args[i];
            }
            Console.WriteLine();

            return sum;
        }

        static void Main(string[] args)
        {
            int sum = Sum(3, 4, 5, 6, 7, 8, 9, 10);

            Console.WriteLine($"Sum : {sum}");
        }
    }
}