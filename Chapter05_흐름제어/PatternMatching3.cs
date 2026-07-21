using System;

// 3. 상수 패턴
// 식이 특정 상수와 일치하는지를 검사
// 정수 리터럴과 문자열 리터럴 뿐 아니라 null과 enum 등 모든 상수와 매칭 가능
class MainApp
{
    static void Run(string[] args)
    {
        // 람다식
        // GetCountryCode: 함수처럼 사용 할 수 있는 람다식을 저장하는 변수
        // 예시
        // var Add = (int a, int b) => a + b;
        // Console.WriteLine(Add(3, 5));
        // (string nation): 람다식의 매개변수(Parameter)
        // 일반 메서드라면 int GetCountryCode(string nation)
        // => : 람다 연산자. "~를 반환한다."

        // 왜 var 타입?
        // 람다식의 실제 타입은
        // Func(입력, 출력>이다.
        // 아래의 코드에서의 타입은 Func<string, int> 이다.
        // 입력: string, 출력: int
        // 따라서 Func<string, int> GetCountryCode도 가능!
        // 하지만 타입이 길기 때문에 대부분 var을 사용함
        var GetCountryCode = (string nation) => nation switch
        {
            "KR" => 82,
            "US" => 1,
            "UK" => 44,
            _ => throw new ArgumentException("Not supported Code")
        };

        Console.WriteLine(GetCountryCode("KR"));    // 람다식을 일반 함수 호출처럼 사용함!
        Console.WriteLine(GetCountryCode("US"));
        Console.WriteLine(GetCountryCode("UK"));
    }
}

// if (obj is null) {}
// if (obj is not null) {}