using System;

namespace DerivedInterface
{
    interface ILogger
    {
        void WriteLog(string message);
    }

    interface IFormattableLogger : ILogger
    {
        void WriteLog(string format, params Object[] args);
    }

    class ConsoleLogger2 : IFormattableLogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }

        public void WriteLog(string format, params Object[] args)
        {
            String message = String.Format(format, args);   // 서식 문자열(format string)에 값을 끼워 넣어
                                                            // 하나의 문자열을 만들어 주는 메서드
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            IFormattableLogger logger = new ConsoleLogger2();
            logger.WriteLog("The World is mine");
            logger.WriteLog("{0} + {1} = {2}", 1, 2, 3); // format, 인수가 여러 개(params Object[] args)
                                                         // format = "{0} + {1} = {2}"
                                                         // args = [1, 2, 3]
                                                         // 가 전달됨
        }
    }
}
