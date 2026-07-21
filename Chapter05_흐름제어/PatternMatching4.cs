using System;

// 4. 프로퍼티 패턴
// 식의 속성이나 필드가 패턴과 일치하는지를 검사
// 입력된 식이 int, double 같은 기본 데이터 형식이 아닌 경우에 유용하게 사용 가능

// 프로퍼티
// {get;set;}은 다음과 같은 코드와 같은 의미이다.
//class Car
//{
//	private string model;

//	public string Model
//	{
//		get					// get은 값을 읽을 때 실행됨
//		{
//			return model;
//		}

//		set					// set은 값을 저장할 때 실행됨
//		{
//			model = value;
//		}
//	}
//}

// 프로퍼티를 사용하는 이유는?
// public string Model; 처럼 쓰면 누구나 아무 값이나 넣을 수 있음.
// 하지만 프로퍼티는 값을 검사할 수 있음
//private int speed;

//public int Speed
//{
//	get
//	{
//		return speed;
//	}

//	set
//	{
//		if (value < 0)
//			speed = 0;
//		else
//			speed = value;
//	}
//}


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

        if (car is Car { Model: "Mustang", ProduceAt.Year: 1967 })  // 객체  Car { Model: "Mustang", ProduceAt.Year: 1967 }
            return GenerateMessage(car, "Fastback");
        else if (car is Car { Model: "Mustang", ProduceAt.Year: 1976 })
            return GenerateMessage(car, "Cobra 2");
        else
            return GenerateMessage(car, "Unknown");
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