using System;

namespace This
{
    class Employee
    {
        private string Name;
        private string Position;

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetPosition(string Position)
        {
            this.Position = Position;
        }

        public string GetPosition()
        {
            return this.Position;
        }
    }

    // this() 생성자
    class MyClass
    {
        int a, b, c;

        public MyClass()
        {
            this.a = 5425;
            Console.WriteLine("MyClass()");
        }

        public MyClass(int b) : this()
        {
            this.b = b;
            Console.WriteLine($"MyClass({b}");
        }

        public MyClass(int b, int c) : this(b)
        {
            this.c = c;
            Console.WriteLine($"MyClass({c}");
        }

        public void PrintFields()
        {
            Console.WriteLine($"a:{a}, b:{b} c:{c}");
        }
    }

    // 한정자(Access Modifier)
    class WaterHeater
    {
        protected int temperature;

        public void SetTemperature(int temperature)
        {
            if (temperature < -5 || temperature > 42)
            {
                throw new Exception("Out of temperature range");
            }

            // temperature 필드는 protected로 수식됐으므로 외부에서 직접 접근할 수 없음
            // 이렇게 public 메소드를 통해 접근해야 함
            this.temperature = temperature;
        }

        internal void TurnOnWater()
        {
            Console.WriteLine($"Turn on water : {temperature}");
        }
    }

    // 상속으로 코드 재활용하기
    class Base
    {
        public void BaseMethod()
        {
            Console.WriteLine("BaseMethod");
        }

        public Base()
        {
            Console.WriteLine("Base()");
        }

        ~Base()
        {
            Console.WriteLine("~Base()");
        }
    }

    class Derived : Base 
    {
        // Derived 클래스는 Base 클래스를 상속했으므로 BaseMethod()를 가짐
        public Derived()
        {
            Console.WriteLine("Derived()");
        }

        ~Derived()
        {
            Console.WriteLine("~Derived()");
        }
    }

    // 메인
    class MainApp
    {
        static void Main(string[] args)
        {
            Employee pooh = new Employee();
            pooh.SetName("Pooh");
            pooh.SetPosition("Waiter");
            Console.WriteLine($"{pooh.GetName()} {pooh.GetPosition()}");

            Employee tigger = new Employee();
            tigger.SetName("Tigger");
            tigger.SetPosition("Cleaner");
            Console.WriteLine($"{tigger.GetName()} {tigger.GetPosition()}");

            Console.WriteLine("=================this() 생성자=================");
            MyClass a = new MyClass();
            a.PrintFields();
            Console.WriteLine();

            MyClass b = new MyClass(1);
            b.PrintFields();
            Console.WriteLine();

            MyClass c = new MyClass(10, 20);
            c.PrintFields();

            Console.WriteLine("=================한정자=================");
            try
            {
                WaterHeater heater = new WaterHeater();
                heater.SetTemperature(20);
                heater.TurnOnWater();

                heater.SetTemperature(-2);
                heater.TurnOnWater();

                heater.SetTemperature(50);  // Out of Temperature Range 출력
                heater.TurnOnWater();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("=================상속=================");
            Derived derived = new Derived();        
        }
    }
}