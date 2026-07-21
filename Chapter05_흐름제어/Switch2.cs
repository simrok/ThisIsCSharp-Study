//Switch문과 패턴 매칭
using System;

namespace Switch2
{
    class MainApp
    {
        static void Run()
        {
            object obj = null;

            string s = Console.ReadLine();
            if (int.TryParse(s, out int out_i)) // C#7에서는
                                                // int out_i; int.TryParse(s, out out_i)
                                                // 이런 식으로 코드가 길었었는데
                                                // C#7 이후로는
                                                // int.TryParse(s, out int ou_i)로 
                                                // 간단하게 표현 가능해졌음.
                obj = out_i;
            else if (float.TryParse(s, out float out_f))
                obj = out_f;
            else
                obj = s;
            
            switch (obj)
            {
                case int:
                    Console.WriteLine((int)obj);
                    break;
                case float:
                    Console.WriteLine((float)obj);
                    break;
                default:
                    Console.WriteLine(obj);
                    break;
            }
        }
    }
}