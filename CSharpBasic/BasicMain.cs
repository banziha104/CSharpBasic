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
        }
    }

    public class YieldBasic
    {
        static IEnumerable<string> yieldString()
        {
            yield return "first";     //첫번째 루프에서 리턴됨
            yield return "second";    //두번째 루프에서 리턴됨
            yield return "thrid";     //세번쨰 루프에서 리턴됨
            yield break;              //Yield break문
        }

        private int[] data = {1, 2, 3, 4, 5}; //데이터 배열 정의

        public IEnumerator GetEnumerator() // 
        {
            int i = 0;
            while (i < data.Length)
            {
                yield return data[i];
                i++;
            }
        }

        public void InteractionForeach()
        {
            var yieldBasic = new YieldBasic();
            
        }
    }
}