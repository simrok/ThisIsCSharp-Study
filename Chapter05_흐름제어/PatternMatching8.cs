// 8. var 패턴
// null을 포함한 모든 식의 패턴 매칭을 성공시키고, 그 식의 결과를 변수에 할당함
// 어떤 식의 결과를 임시 변수에 할당한 뒤 추가적인 연산을 수행하고자 할 때 유용하게 사용할 수 있음
using System;

Console.WriteLine("====================var 패턴 예제====================");

class MainApp {
	static void Main(string[] args)
	{
		// 모든 과목이 60점이 넘고, 평균이 60점 이상인 경우에만 Pass
		var IsPassed =		// bool값이 들어감
			(int[] scores) 
			=> scores.Sum() / scores.Length is var average	// 결과는 true
			&& Array.TrueForAll(scores, (score) => score >= 60)	// 결과는 bool
			&& average >= 60;	// 결과는 bool

		int[] scores1 = { 90, 80, 60, 80, 70 };
		Console.WriteLine($"{string.Join(",", scores1)}: Pass:{IsPassed(scores1)}");
	
		int[] scores1 = { 90, 80, 59, 80, 70 };
		Console.WriteLine($"{string.Join(",", scores2)}: Pass:{IsPassed(scores2)}");
	}
}

// 기본 람다식
// var	IsPassed = (int[] scores) => 하나의 식
// 그렇게 때문에 is var average를 안쓰면
// var IsPassed = (int[] scores) => { int average =  ... ... }

// scores.Length is var average
// : 식 계산해서 그 결과를 변수에 저장하고 true 반환
// 예를 들어서
// x is var value 이면
// var value = x
// 하지만!!!!! is 연산자의 결과는 bool이다!
// 잠시 부가적으로 average = scores.Sum() / scores.Length 이라는 변수를 하나 만들어 줌.
// 또한 is var은 항상 true를 반환

// Array.TrueForAll
// 배열(Array)의 모든 요소(True For All)가 조건을 만족하는지 검사하는 메서드
// 형식은?
// Array.TrueForAll<T>(T[] array, Predicate<T> match)
// T[] array는 검사할 배열
//  Predicate<T>: 각 요소를 검사하는 함수
// 여기서 (score) => score >= 60는 람다함수

// 예를 들어서
// 90 >= 60 ✔

// 80 >= 60 ✔

// 60 >= 60 ✔

// 80 >= 60 ✔

// 70 >= 60 ✔

// 모두 참이므로 true 반환