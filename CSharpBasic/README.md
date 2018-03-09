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

---
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

---
# 네임스페이스 

많은 클래스들을 편리하게 관리/사용하기 위해 네임스페이스 사용
클래스들은 대개 네임스페이스 안에서 정의됨
네임 스페이스를 사용하는 두가지 방법
<li> using을 이용해 사용할 네임스페이스를 불러오는 방법

```c#
using System;
Console.WriteLine("첫번쨰 방법")
```

<li> 클래스명 앞에 네임스페이스를 전부 적는 방법

```c#
System.Console.WriteLine("두번째 방법")
```

전체 코드
```c#
using System;
namespace CSharpBasic
{
    public class NamespaceBasic
    {
        static void NamespaceExample()
        {
              Console.WriteLine("첫번쨰 방법"); // using을 이용해 사용하고자 하는 네임스페이스를 설정
//            System.Console.WriteLine("두번째 방법"); 
        }
    }
}
```

---
## 구조체

클래스는 reference type이며
구조체는 value type 임

```c#
using System;

namespace CSharpBasic
{
    public class StructExample
    {
        // 구조체 정의
        struct MyPoint
        {
            public int X;
            public int Y;

            public MyPoint(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                return string.Format("({0}, {1})", X, Y);
            }
        }

        static void Main(string[] args)
        {
            // 구조체 사용
            MyPoint pt = new MyPoint(10, 12);
            Console.WriteLine(pt.ToString());
        }
    }
}
```

---
## 클래스
클래스는 Reference Type을 정의하는데 사용됨. 
클래스 멤버
<li> 메서드 : 실제 행동을 일으키는 블럭
<li> 필드 : 데이터를 저장하는 블럭
<li> 프로퍼티 : 클래스의 내부 데이터를 외부에서 사용할 수 있게 하거나, 외부에서 내부 데이터를 사용할수 있게함
<li> 이벤트 : 객체 내부의 특정 상태 혹은 이벤트를 외부로 전달하는데 이용됨

```c#
using System;

namespace CSharpBasic
{
    public class ClassExample
    {
        // 필드
        private string name;
        private int age;

        // 이벤트 
        public event EventHandler NameChanged;

        // 생성자 (Constructor)
        public ClassExample()
        {
            name = string.Empty;
            age = -1;
        }

        // 속성
        public string Name
        {
            get { return this.name; }
            set 
            {
                if (this.name != value)
                {
                    this.name = value;
                    if (NameChanged != null)
                    {
                        NameChanged(this, EventArgs.Empty);
                    }
                }                
            }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        // 메서드
        public string GetCustomerData()
        {
            string data = string.Format("Name: {0} (Age: {1})", 
                this.Name, this.Age);
            return data;
        }
    }
}
```

---
# Nullable 타입
정수 부동자릿수 구조체 등의 Value Type은 Null을 가질 수 없음. 하지만 필요한 경우가 존재하며,
자료형 뒤에 ?를 붙여주면 nullable 타입으로 선언가능

```c#
int? i = null;
bool? b = null;
int[]? a = new int?[100]
```

## Nullable<T> 타입
HasValue 속성과 실제값을 나타내는 Value로 이루어짐.
```c#
if(!a.Hasvalue) //값이 없다면
    throw new ArgumentException();
else            //값이 있다면
    a = 10;
```
 
 ?? 연산자는 ?? 앞의 파라미터가 NULL인 경우 연산자 뒤에 값을 할당할 떄 사용
 ```c#
 a = 10 ?? 5; // null이 아닌경우 10 , null인 경우 5
````

## 정적 Nullable 클래스
<li> Compare() : nullable 객체간 비교
<li> Equal() : nullable 객체 간에 동일한 값을 가지고 있는지 를 찾음

```c#
void NullableTest()
{
    int? a = null;
    int? b = 0;            
    int result = Nullable.Compare<int>(a, b);
    Console.WriteLine(result); //결과 -1

    double? c = 0.01;
    double? d = 0.0100;
    bool result2 = Nullable.Equals<double>(c, d);
    Console.WriteLine(result2); //결과 true
}
```
---
# 메소드
 클래스내에서 일련의 코드 블럭을 실행시키는 함수를 메서드라 부름
 Pass by Value가 기본.

 ## Ref 키워드
 Pass by Reference로 호출하기 위해선 ref 키워드를 사용
 
 ```c#
static double GetData(ref int a, ref double b)
{ return ++a * ++b; }

```
 ## Out 키워드
 Ref 와 비슷하지만 초기화할 필요는 없
```c#
static bol GetData(out int a, out int b)
return true;
```

 ## Optional 파라미터
 맨 마지막에 반드시 놓아야 하며 파라미터가 디폴트 값을 가진 경우에 사용
 ```c#
    int Calc(int a, int b, string calcType = "+")
    {
        switch (calcType)
        {
            case "+":
                return a + b;
            case "-":
                return a - b;
            case "*":
                return a * b;
            case "/":
                return a / b;
            default:
                throw new ArithmeticException();
        }
    }
```

## Params
파라미터의 갯수를 알 수 없는 경우에 사용, 맨 마지막에 위치해야함
```c#
//메서드
 int Calc(params int[] values)

//사용
int s = Calc(1,2,3,4);
s = Calc(6,7,8,9,10,11);
```

---
# 이벤트
클래스 내의 특정한 일이 일어났음을 외부의 이벤트 가입자들에게 알려주는 기능을 함
```c#
// 클래스 내의 이벤트 정의
class MyButton
{
   public string Text;
   // 이벤트 정의
   public event EventHandler Click;

   public void MouseButtonDown()
   {
      if (this.Click != null)
      {
         // 이벤트핸들러들을 호출
         Click(this, EventArgs.Empty);
      }
   }
}

// 이벤트 사용
public void Run()
{
   MyButton btn = new MyButton();
   // Click 이벤트에 대한 이벤트핸들러로
   // btn_Click 이라는 메서드를 지정함
   btn.Click += new EventHandler(btn_Click);
   btn.Text = "Run";
   //....
}

void btn_Click(object sender, EventArgs e)
{
   MessageBox.Show("Button 클릭");
}
```

### Property

자바에서 캡슐화하는 것. 대문자로 시작함

```c#
    private int experience;
    
    public int Exprience
    {
     get{
        retrun experience;
     }
     set{
        experience = value;
     }
    }
```

### Ternary Operater 

삼항 연산자

```c#
message = health > 0 ? "Plyer is Alive" : "Dead"
```

### Member Hiding 

```c#
new float someValue = 5f; // 멤버앞에 new 연산자를 붙여서 숨김
```

### Extension method
해당 클래스에 직접적으로 수정할 수 없을 때, 확장 메소드를 이용해 붙어넣는 방

```c#
public static class ExtensionMethods  // 스태틱으로 선언해야함
{
    public static void ResetTransfromation(this Transform trans) //파라미터로 this 클래스 변수를 넣어
    {
        Debug.lod("extion");
        trans.position = Vector3.zero;
    }
}

public class SomeClass : MonoBehaviour
{
    void Start(){
        transfrom.ResetTransfromation();
    }
}
```

### Coroutines

```c#
public class CoroutinesExample : MonoBehaviour
{
    public float smoothing = 1f;
    public Transform target;
    
    
    void Start ()
    {
        StartCoroutine(MyCoroutine(target));
    }
    
    
    IEnumerator MyCoroutine (Transform target) // IEnumerator를 사
    {
        while(Vector3.Distance(transform.position, target.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
            
            yield return null;  // null을 리턴함으로써 무한루프
        }
        
        print("Reached the target.");
        
        yield return new WaitForSeconds(3f); // 몇초마다 시작할지
        
        print("MyCoroutine is now finished.");
    }
}
```

프로퍼티와의 사용

```c#
using UnityEngine;
using System.Collections;

public class PropertiesAndCoroutines : MonoBehaviour
{
    public float smoothing = 7f;
    public Vector3 Target
    {
        get { return target; }
        set
        {
            target = value;
            
            StopCoroutine("Movement");
            StartCoroutine("Movement", target);
        }
    }
    
    
    private Vector3 target;

    
    IEnumerator Movement (Vector3 target)
    {
        while(Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);
            
            yield return null;
        }
    }
}
```

```c#
using UnityEngine;
using System.Collections;

public class ClickSetPosition : MonoBehaviour
{
    public PropertiesAndCoroutines coroutineScript;
    
    void OnMouseDown ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        Physics.Raycast(ray, out hit);
        
        if(hit.collider.gameObject == gameObject)
        {
            Vector3 newTarget = hit.point + new Vector3(0, 0.5f, 0);
            coroutineScript.Target = newTarget;
        }
    }
}

```

### Quaternions

회전과 관련됨 , x,y,z,w 를 파라미터로 받음

```c#

```