using System;

class Base
{
    public virtual void SealMe() 
    {
    }
}

class Derived : Base
{
    public sealed override void SealMe()    // sealed override > 오버라이드한 메소드를 봉인 메소드로 만든다
    { 
    }
}
 
//class WantToOverride : Derived
//{
//    public override void SealMe()   // 'WantToOverride.SealMe()': 상속된 'Derived.SealMe()' 멤버는 봉인되어 있으므로 재정의할 수 없습니다.
//    {
//    }
//}


class MainApp
{
    static void Main(string[] args)
    {
    }
}