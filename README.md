# CSharpBasic

# yield

yield 는 컬렉션 데이터를 하나씩 리턴할 떄 사용함.

```c#
static IEnumerable<string> YieldString()
        {
            yield return "first";     //첫번째 루프에서 리턴됨
            yield return "second";    //두번째 루프에서 리턴됨
            yield return "thrid";     //세번쨰 루프에서 리턴됨
            yield break;              //Yield break문
        }
```
---
## Enumerator 인터페이스

yield를 사용하기 위해선 IEnumerator 인터페이스를 구현해야하며, IEnumerator 인터페이스는 
<li> Current : 현재 값
<li> MoveNext() : 다음 yield field로 이동
<li> Reset() : 리셋
 이렇게 세가지가 존재하며 Enumerator가 되기위해선 Current와 MoveNext()를 반드시 구현해야함
 
 ---
 ## 출력

<li> 루프문을 이용한 출력
<li> MoveNext()와 Current를 이용한 수동 출력

```c#
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
```


# 예외 처리

## try - catch - finally
<li> try : 예외가 발생할 수 있는 구간
<li> catch : try 구문에서 예외가 발생할 경우 처리(다중 catch 가능)
<li> finally : 예외와 상관없이 실행되는 구간(finally 없이 try - catch만 사용가능)

## throw
<li> 뒤에 인자가 없는 경우 : 호출한 상위 메소드에서 처리
<li> 뒤에 인자가 있는 경우 : 해당 클래스에서 예외를 처리 

```c#
namespace CSharpBasic
{
    public class ExceptionHandle
    {
        public void ExceptionHandler()
        {
            try //예외 예상 구간
            {

            }
            catch (FileNotFoundException e) //예외시 처리
            {
                Console.WriteLine(e);
                throw;                  //throw 뒤에 아무것도 없는 경우, 상위 호출 메소드에서 처리
            }
            catch (MyException e)       
            {
                throw new MyException();  //throw, 뒤에 있는 경우 해당 클래스에서 처리
            }
            finally             //예외랑 상관없이 실
            {
                Console.WriteLine("끝");
            }
        }
    }

    public class MyException : Exception //커스텀 예외 클래스
    {
        
    }
}
```