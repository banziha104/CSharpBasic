using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace CSharpBasic
{
    public class BasicMain
    {
        static void Main(string[] args)
        {
             YieldBasic yieldBasic = new YieldBasic();
            yieldBasic.YieldInteractionForEach();
        }
    }

    public class YieldBasic
    {
        static IEnumerable<string> YieldString()
        {
            yield return "first";     //첫번째 루프에서 리턴됨
            yield return "second";    //두번째 루프에서 리턴됨
            yield return "thrid";     //세번쨰 루프에서 리턴됨
            yield break;              //Yield break문
        }

        private int[] data = {1, 2, 3, 4, 5}; //데이터 배열 정의

        public IEnumerator GetEnumerator() //  yield를 사용하기 위해 IEnumerator 인터페이스 구현
        {
            int i = 0;
            while (i < data.Length)
            {
                yield return data[i];
                i++;
            }
        }

        public void YieldInteractionForEach()  //루프를 이용한 인터랙션
        {
            var yieldBasic = new YieldBasic();
            foreach (var item in yieldBasic)
            {
                Console.WriteLine(item);
            }
        }

        public void YieldInteractionMoveNext() //수동을 이용한 인터랙션
        {
            var yieldBasic = new YieldBasic();
            IEnumerator it = yieldBasic.GetEnumerator();
            it.MoveNext();
            Console.WriteLine(it.Current);
            it.MoveNext();
            Console.WriteLine(it.Current);
        }
    }
}