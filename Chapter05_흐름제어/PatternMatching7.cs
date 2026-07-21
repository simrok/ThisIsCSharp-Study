// 7. 위치 패턴
// 식의 결과를 분해하고(DeConstruct)하고, 분해된 값들이 내장된 복수의 패턴과 일치하는지를 검사
// 위치 패턴 안에 내장되는 패턴에는 형식 패턴, 상수 패턴 등 어떤 패턴이든 올 수 있음
// 단, 분해된 값들과 내장되 패턴의 개수, 순서가 일치해야 한다는 점에는 주의해야 함

using System;

Console.WriteLine("====================위치패턴 예제2====================");
struct Audience
{
	public bool IsCitizen { get; init; }
	public int Age { get; init; }
	// set은 언제든 값을 바꿀 수 있지만
	// init은 객체를 생성할 때만 값을 설정할 수 있는 프로퍼티    
	// 읽기 전용에 가까운 객체를 만들 때 유용함 


	public Audience(bool isCitizen, int age)
	{
		// 생성자라서 값을 넣을 수 있음
		IsCitizen = isCitizen;
		Age = age;
	}

	// 위치 패턴의 핵심
	// 이 객체를 여러 값으로 분해하는 방법을 정의하는 함수
	public void Deconstruct(out bool isCitizen, out int age)
	{
		isCitizen = IsCitizen;
		age = Age;
	}
	// 예를 들어 Audience audience = new Audience(true, 20);이 있을 때
	// var (citizen, age) = audience; 이런 문법이 가능함
	// 왜냐하면 컴파일러가 audience.Deconstruct(out citizen, out age);를 호출하기 때문임
}

class MainApp {
	static void Main(string[] args)
	{
		Console.WriteLine("====================위치패턴 예제1====================");
		Tuple<string, int> itemPrice = new Tuple<string, int>("expresso", 3000);

		if (itemPrice is ("express", < 5000))
		{
			Console.WriteLine("The coffee is affordable.");
		}

		Console.WriteLine("====================위치패턴 예제2====================");
		var CalulateFee = (Audience audience) => audience switch
		{
			(true, < 19) => 100,
			(true, _) => 200,
			(false, < 19) => 200,
			(false, _) => 400,
		};

		var a1 = new Audience(true, 10);    // 컴파일러가 audience.Deconstruct()를 호출해서
											// 예를 들어 (true, 10)과 (true, 19)를 비교함
		Console.WriteLine($"내국인: {a1.IsCitizen} 나이: {a1.Age} 요금: {CalulateFee(a1)}");


		var a2 = new Audience(false, 33);
		Console.WriteLine($"내국인: {a2.IsCitizen} 나이: {a2.Age} 요금: {CalulateFee(a2)}");
	}
}
// 위치 패턴은 프로퍼티 이름을 보는 것이 아니라 Deconstruct()가 반환하는 값의 순서를 기준으로 비교함
// 그래서 Deconstruct의 매개변수 순서를 바꾸면 위치 패턴의 의미도 함께 바뀜