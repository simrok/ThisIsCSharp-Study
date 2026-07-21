using System;

// 1. 선언 패턴
// : 주어진 식이 특정 형식(예: int, string 등)과 일치하는지를 평가
// 1) 식이 주어진 형식과 일치하는지 테스트
// 2) 테스트가 성공하면 식을 주어진 형식으로 변환
class MainApp {
	static void Main(string[] args)
	{
		object foo = 23;
		if (foo is int bar) // 1. foo가 int인 경우 2. foo를 int 형식으로 변환하여 변수 bar에 할당
		{
			Console.WriteLine(bar);
		}
	}
}