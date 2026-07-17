using System;

namespace AccessModifier
{
    // 한정자(Access Modifier)
    class WaterHeater
    {
        protected int temperature;  // protected 한정자

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

    // 메인
    class MainApp
    {
        static void Run()
        {
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
        }
    }
}