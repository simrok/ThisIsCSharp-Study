// 4. 프로퍼티 패턴
// GetNickname메소드에서 is 연산자를 switch식으로 변경한 version
using System;

class MainApp
{
    class Car
    {
        public string Model { get; set; }
        public DateTime ProduceAt { get; set; }
    }
    // 객체를 생성할 때
    // new Car() { Model = "Mustang", ProduceAt = new DateTime(1967, 11, 23) }
    // 즉, set이 호출됨
    // car.Model; 여기서는 get이 호출됨

    static string GetNickname(Car car)
    {
        // 여기에서 람다식의 타입은
        // Func<Car, string, string>
        // + 참고 +
        // 반환값이 없는 함수(void)는 Func가 아니라 Actionㅇ을 사용
        // Actionz<string> Print = (string message) => {Console.WriteLine(message);}
        var GenerateMessage = (Car car, string nickname) =>
            $"{car.Model} produced in {car.ProduceAt.Year} is {nickname}";  //ProduceAt.Year은 DateTime의 속성인 Year

        return car switch
        {
            { Model: "Mustang", ProduceAt.Year: 1967 } => GenerateMessage(car, "Unknown"),
            { Model: "Mustang", ProduceAt.Year: 1976 } => GenerateMessage(car, "Cobra 2"),
            _ => GenerateMessage(car, "Unknown")
        };
    }
    static void Run(string[] args)
    {
        Console.WriteLine(
            GetNickname(
                new Car() { Model = "Mustang", ProduceAt = new DateTime(1967, 11, 23) }));

        Console.WriteLine(
            GetNickname(
                new Car() { Model = "Mustang", ProduceAt = new DateTime(1976, 6, 7) }));

        Console.WriteLine(
            GetNickname(
                new Car() { Model = "Mustang", ProduceAt = new DateTime(2099, 12, 25) }));
    }
}