using System;
using System.IO;

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