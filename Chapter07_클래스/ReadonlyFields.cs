using System;

class Configuration 
{ 
	private readonly int min;	// 읽기 전용 필드는 생성자 안에서만 초기화할 수 있음
	private readonly int max;

	public Configuration(int v1, int v2)
	{
		min = v1;   // readonly는 생성자 안에서 한 번 값을 지정하면, 그 후로는 값을 변경할 수 없는 것이 특징
		min = v2;   // 생성자에서는 값 변경 가능
		min = v1 + v2;	// 생성자에서는 값 변경 가능
    }

	//public void changemax(int newmax)
	//{
	//	max = newmax;   // 읽기 전용 필드의 값을 생성자가 아닌 곳에서 초기화하면 컴파일 에러 발생!
	//       // 에러 메세지: 읽기 전용 필드에는 할당할 수 없습니다.
	//		// 단, 필드가 정의된 형식의 생성자 또는 초기값 전용 setter나 변수 이니셜라이저에서는 예외입니다.
	//}

    public void PrintFields()
	{
		Console.WriteLine(min); Console.WriteLine(max);
	}
}

class MainApp
{
	static void Run()
	{
		Configuration c = new Configuration(10, 100);
		c.PrintFields();
	}
}
