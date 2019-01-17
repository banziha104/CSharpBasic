# Delegate 

> 메소드를 파라미터 등 변수로 전달하는 방법

```c#
using System;

namespace ConsoleApplication1
{

    
    internal class Program
    {
        public static void Main(string[] args)
        {
            DelegateTest delegateTest = new DelegateTest();
            delegateTest.GetDelegate()("이영준"); // Delegate 사용
            delegateTest.PerformDelegate(delegateTest.ProgramDelegate,"이영준2");
            delegateTest.PerformDelegate(delegate(string s) { Console.WriteLine(s+"를 무명메서드로 출력"); }, "이영준3");  // 무명 메서드 사용
            delegateTest.PerformDelegate(str => // 람다식 사용
            {
                Console.WriteLine(str+"을 람다식으로 출력");
            },"이영준4");
        }

    }

    class DelegateTest
    {
        public delegate void MyDelegation(string s); // Delegate 정의
        
        private void ImplementDelegate(string s) // MyDelegation을 구현
        {
            Console.WriteLine(s+"를 출력했습니다");
        }

        
        public void ProgramDelegate(string s) //외부의 딜리게이션 구현
        {
            Console.WriteLine(s+"는 외부에서 받아온 데이터");
        }
        
        public void PerformDelegate(MyDelegation m, string s)
        {
            m(s);
        }
        public MyDelegation GetDelegate() // Delegate를 반환
        {
            return new MyDelegation(ImplementDelegate);
        }
    }

    class AnonymousMethod
    {
        
        
    }
}
```