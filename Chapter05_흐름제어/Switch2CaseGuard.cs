using System;
using System.Net.Mail;

namespace Switch2CaseGuard
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
                case float f when f >= 0:   // obj가 float 형식이며 0보다 크거나 같은 경우
                                            // float인지 검사한 후 그 값을 새 변수 f에 저장함
                    Console.WriteLine(f + "는 양의 float 형식입니다.");
                    break;
                case float: // 위의 조건을 만족하지 않은 경우 실행; 즉, float && !(f>=0)
                    Console.WriteLine((float)obj + "는 음의 float 형식입니다.");  // obj가 float 형식이며 0보다 작은 경우
                    break;
                default:
                    Console.Write(obj);
                    break;
            }
        }
    }
}